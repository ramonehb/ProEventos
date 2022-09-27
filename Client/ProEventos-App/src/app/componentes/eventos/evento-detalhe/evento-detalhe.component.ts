import { Component, OnInit, TemplateRef } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Evento } from '@app/models/Evento';
import { Lote } from '@app/models/Lote';
import { EventoService } from '@app/services/evento.service';
import { Constants } from '@app/util/constants';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-evento-detalhe',
  templateUrl: './evento-detalhe.component.html',
  styleUrls: ['./evento-detalhe.component.scss']
})
export class EventoDetalheComponent implements OnInit {

  evento = {} as Evento;
  metodo = 'post';
  novo = true;
  form: FormGroup = this.formBuilder.group({});

  constructor(
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private localeService: BsLocaleService,
    private routerActive: ActivatedRoute,
    private eventoService: EventoService,
    private spinner: NgxSpinnerService,
    private router: Router
  ) {
    this.localeService.use(Constants.LocalProject);
  }

  ngOnInit(): void {
    this.carregaEvento();
    this.validacao();
  }

  get lotes(): FormArray {
    return this.form.get('lotes') as FormArray;
  }
  get f(): any {
    return this.form.controls;
  }

  get modoEditar(): boolean {
    return this.novo === false;
  }

  get bsConfig(): any {
    return {
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY hh:mm a',
      containerClass: 'theme-default',
      showWeekNumbers: false,
    };
  }

  public adicionarLote(): void {
    this.lotes.push(this.criarLote({id: 0} as Lote));
  }

  public criarLote(lote: Lote): FormGroup {
    return this.formBuilder.group({
      id: [lote.id],
      nome: [lote.nome, Validators.required],
      quantidade: [lote.quantidade, Validators.required],
      preco: [lote.preco, Validators.required],
      dataInicio: [lote.dataInicio],
      dataFim: [lote.dataFim],
    });
  }

  public carregaEvento(): void {
    const eventoId = this.routerActive.snapshot.paramMap.get('id');

    if (eventoId != null) {
      this.metodo = 'put';
      this.novo = false;
      this.spinner.show();

      this.eventoService.getEventoById(+eventoId).subscribe(
        (evento: Evento) => {
          this.evento = { ...evento };
          this.form.patchValue(this.evento);
        },
        (erro: any) => {
          console.error(erro);
          this.toastr.error('Erro ao tentar carregar Evento.');
        }
      ).add(this.spinner.hide());
    }
  }

  public validacao(): void {
    this.form = this.formBuilder.group({
      tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local: ['', [Validators.required, Validators.maxLength(50), Validators.minLength(4)]],
      dataEvento: ['', Validators.required],
      qtdPessoas: ['', [Validators.required, Validators.max(120000)]],
      telefone: ['', [Validators.required, Validators.minLength(8)]],
      email: ['', [Validators.required, Validators.email]],
      imagemURL: ['', Validators.required],
      lotes: this.formBuilder.array([])
    });
  }

  public resetarForm(): void {
    this.form.reset();
  }

  public salvarAlteracao(evento: Evento): void {
    this.spinner.show();

    if (this.form.valid) {
      this.evento = (this.novo) ? { ... this.form.value } : { id: this.evento.id, ... this.form.value };

      this.eventoService[this.metodo](this.evento).subscribe(
        (eventoRetorno: Evento) => {
          this.router.navigate([`eventos/detalhe/${eventoRetorno.id}`]);
          this.toastr.success(this.novo ? 'Evento cadastro com sucesso' : 'Evento atualizado com sucesso', 'Sucesso');
        },
        (erro: any) => {
          console.log(`Erro: ${erro}`);
          this.toastr.error(this.novo ? 'Erro ao cadastrar evento' : 'Erro ao atualizar evento', 'Atenção');
        }
      ).add(this.spinner.hide());
    }
  }

  public formValidator(campo: FormControl | AbstractControl): any {
    return { 'is-invalid': campo.errors && campo.touched };
  }
}
