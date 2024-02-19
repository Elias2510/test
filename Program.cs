//empty

using test.Contextapp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddHttpClient("PostMan")
    .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
    {
        ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
        {
            // Always return true to ignore SSL certificate errors (for development/testing only)
            return true;
        }
    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("corsapp",
        builder =>
        {
            builder.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
        });
});


// Add services to the container.


builder.Services.AddControllers();


builder.Services.AddDbContext<Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("perm")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddScoped<INewsRepository, NewsRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseRouting();

app.UseCors("corsapp");  // Make sure this is placed here, after UseRouting and before UseAuthorization

app.UseAuthorization();

app.MapControllers();

app.Run();