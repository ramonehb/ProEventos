import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Lote } from '@app/models/Lote';
import { Observable } from 'rxjs';
import { take } from 'rxjs/operators';

@Injectable()
export class LoteService {

  private baseURL = 'https://localhost:5001/api/lotes';

  constructor(private http: HttpClient) { }

  public getLotesByEventoId(eventoId: number): Observable<Lote[]>{
    return this.http
      .get<Lote[]>(`${this.baseURL}/${eventoId}`)
      .pipe(take(1));
  }

  public saveLote(eventoId: number, lotes: Lote[]): Observable<Lote[]>{
    return this.http
      .put<Lote[]>(`${this.baseURL}/${eventoId}`, lotes)
      .pipe(take(1));
  }

  public deleteEvento(id: number): Observable<any>{
    return this.http
      .delete(`${this.baseURL}/${id}`)
      .pipe(take(1));
  }
}
