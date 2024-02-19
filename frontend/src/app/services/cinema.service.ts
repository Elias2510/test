import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CinemaService {
  private apiUrl = 'https://localhost:7161/api/Cinema/actor-filme'; // Adresa API

  constructor(private http: HttpClient) { }

  getCinemas(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
}