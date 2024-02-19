import { Component, OnInit } from '@angular/core';
import { CinemaService } from '../services/cinema.service';
import { ActorService } from '../services/actor.service';
import { FilmService } from '../services/film.service';
import { NgFor, NgIf } from '@angular/common';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-home',
  standalone : true,
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  imports: [NgFor, NgIf,RouterModule,HttpClientModule],
  providers: [CinemaService,FilmService,ActorService,CinemaService]
})
export class HomeComponent implements OnInit {
  cinemas: any[] = [];
  actori: any[] = [];
  filme: any[] = [];
  sunt_logat: boolean = false;
  constructor(
    private cinemaService: CinemaService,
    private actorService: ActorService,
    private filmService: FilmService
  ) { }

  ngOnInit(): void {
    this.loadCinemas();
    this.loadActori();
    this.loadFilme();
  }

  loadCinemas(): void {
    this.cinemaService.getCinemas().subscribe(
      (response: any) => {
        this.cinemas = response;
      },
      (error: any) => {
        console.error('Error loading cinemas:', error);
      }
    );
  }
  

  loadActori(): void {
    this.actorService.getActori().subscribe(
      (response: any) => {
        this.actori = response;
      },
      (error: any) => {
        console.error('Eroare la încărcarea actorilor:', error);
      }
    );
  }

  loadFilme(): void {
    this.filmService.getFilme().subscribe(
      (response: any) => {
        this.filme = response;
      },
      (error: any) => {
        console.error('Eroare la încărcarea filmelor:', error);
      }
    );
  }
}