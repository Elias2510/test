import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FilmService {
  private apiUrl = 'https://localhost:7161/api/Film'; // Adresa API

  constructor(private http: HttpClient) { }

  getFilme(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
}