import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ActorService {
  private apiUrl = 'https://localhost:7161/api/Actor'; // Adresa API

  constructor(private http: HttpClient) { }

  getActori(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }
}