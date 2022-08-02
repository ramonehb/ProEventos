import { Component, OnInit, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Evento } from '@app/models/Evento';
import { EventoService } from '@app/services/evento.service';

@Component({
  selector: 'app-evento-lista',
  templateUrl: './evento-lista.component.html',
  styleUrls: ['./evento-lista.component.scss']
})
export class EventoListaComponent implements OnInit {

  modalRef?: BsModalRef;
  config = {
    keyboard: true
  };
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  public eventoNome = '';
  public eventoId = 0;
  private filtroListado = '';

  public exibirImg = true;
  public widthImg = true;
  public heigthImg = 42;
  public marginImg = 2;

  public get filtro(): string {
    return this.filtroListado;
  }
  public set filtro(value: string) {
    this.filtroListado = value;
    this.eventosFiltrados = this.filtro ? this.filtrarEventos(this.filtro) : this.eventos;
  }

  public filtrarEventos(filtrarPor: string): Evento[] {
    filtrarPor = filtrarPor.toLocaleLowerCase();

    return this.eventos.filter(
      (evento: any) => evento.tema.toLocaleLowerCase().indexOf(filtrarPor) !== -1 ||
        evento.local.toLocaleLowerCase().indexOf(filtrarPor) !== -1
    );
  }
  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router
  ) { }

  public ngOnInit(): void {
    this.spinner.show();
    this.carregarEventos();
  }

  public alterarImagem(): void {
    this.exibirImg = !this.exibirImg;
  }

  public carregarEventos(): void {
    this.eventoService.getEventos().subscribe({
      next: (eventos: Evento[]) => {
        this.eventos = eventos;
        this.eventosFiltrados = eventos;
      },
      error: (error: any) => {
        this.spinner.hide();
        this.toastr.error('Erro ao Carregar os Eventos', 'Erro!');
        console.log(error);
      },
      complete: () => this.spinner.hide()
    });
  }

  public openModal(eventoId: number, eventoTema: string, event: any, template: TemplateRef<any>): void {
    event.stopPropagation();
    this.eventoId = eventoId;
    this.eventoNome = eventoTema;
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  public confirm(): void {
    this.modalRef?.hide();
    this.spinner.show();

    this.eventoService.deleteEvento(this.eventoId).subscribe(
      (result: any) => {
        if (result.mensagem === 'Deletado'){
          this.toastr.success('Evento excluído com sucesso.', 'Atenção');
          console.log('Deletado');
          this.spinner.hide();
          this.carregarEventos();
        }
      },
      (erro: any) => {
        console.error(`Erro: ${erro}`);
        this.toastr.error('Erro ao tentar deletar evento.', 'Atenção');
        this.spinner.hide();
      },
      () => this.spinner.hide()
    );


  }

  public decline(): void {
    this.modalRef?.hide();
  }

  public detalheEvento(id: number): void {
    this.router.navigate([`eventos/detalhe/${id}`]);
  }
}
