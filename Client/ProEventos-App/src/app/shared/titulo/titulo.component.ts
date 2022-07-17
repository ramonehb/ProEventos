import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {
  @Input() titulo = '';
  @Input() subtitulo = 'Desde 2022';
  @Input() iconClass = 'fa fa-user';
  @Input() botaoListar = false;

  constructor() { }

  public ngOnInit(): void {
  }

}
