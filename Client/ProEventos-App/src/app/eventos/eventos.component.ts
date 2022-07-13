import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = [];
  public eventosFiltrados: any = [];
  private _filtro : string = '';

  exibirImg: boolean = true;
  widthImg : number = 55;
  heigthImg : number = 42;
  marginImg : number = 2;

  public get filtro() : string {
    return this._filtro;
  }
  public set filtro(value: string) {
    this._filtro = value;
    this.eventosFiltrados = this.filtro ? this.filtrarEventos(this.filtro) : this.eventos;
  }

  public filtrarEventos(filtrarPor : string) : any {
    filtrarPor = filtrarPor.toLocaleLowerCase();

    return this.eventos.filter(
      (evento : any ) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
       evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }
  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos();
  }

  public alterarImagem(){
    this.exibirImg = !this.exibirImg;
  }

  public getEventos(): void {
    this.http.get('https://localhost:5001/api/eventos').subscribe(
      response => {
        this.eventos = response;
        this.eventosFiltrados = response;
      },
      error => console.log(error)
    );
  }
}