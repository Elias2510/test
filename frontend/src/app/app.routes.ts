// app.routes.ts

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component'; // Asigură-te că importă corect HomeComponent

const routes: Routes = [
  { path: '', component: HomeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes), HomeComponent],
  exports: [RouterModule] // Elimină exportul lui HomeComponent din aici
})
export class AppRoutingModule { }

export { routes }; // Exportă variabila 'routes' separat