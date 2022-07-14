import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()
export class EventoService {

  private baseURL = 'https://localhost:5001/api/eventos';
  constructor(private http: HttpClient) { }

  getEvento(){
    return this.http.get(this.baseURL)
  }
}
