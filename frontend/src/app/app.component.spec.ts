import { Component, OnInit } from '@angular/core';
import { CinemaService } from './services/cinema.service';
import { ActorService } from './services/actor.service';
import { FilmService } from './services/film.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  cinemas: any[] = [];
  actori: any[] = [];
  filme: any[] = [];

  constructor(
    private cinemaService: CinemaService,
    private actorService: ActorService,
    private filmService: FilmService
  ) {}

  ngOnInit(): void {
    this.loadCinemas();
    this.loadActori();
    this.loadFilme();
  }

  loadCinemas() {
    this.cinemaService.getCinemas().subscribe(data => {
      this.cinemas = data;
    });
  }

  loadActori() {
    this.actorService.getActori().subscribe(data => {
      this.actori = data;
    });
  }

  loadFilme() {
    this.filmService.getFilme ().subscribe(data => {
      this.filme = data;
    });
  }
}