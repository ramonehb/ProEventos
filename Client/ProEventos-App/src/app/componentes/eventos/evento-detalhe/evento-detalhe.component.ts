import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { Evento } from '@app/models/Evento';
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
  form: FormGroup = this.formBuilder.group({});

  get f(): any {
    return this.form.controls;
  }

  get bsConfig(): any {
    return {
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY hh:mm a',
      containerClass: 'theme-default',
      showWeekNumbers: false,
    };
  }

  constructor(
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private localeService: BsLocaleService,
    private router: ActivatedRoute,
    private eventoService: EventoService,
    private spinner: NgxSpinnerService
  ) {
    this.localeService.use(Constants.LocalProject);
  }

  ngOnInit(): void {
    this.carregaEvento();
    this.validation();
  }

  public carregaEvento(): void {
    const eventoId = this.router.snapshot.paramMap.get('id');

    if (eventoId != null){
      this.spinner.show();
      this.eventoService.getEventoById(+eventoId).subscribe(
        (evento: Evento) => {
          this.evento = {...evento};
          this.form.patchValue(this.evento);
        },
        (erro: any) => {
          this.spinner.hide();
          console.error(erro);
          this.toastr.error('Erro ao tentar carregar Evento.');
        },
        () => this.spinner.hide()
      );
    }
  }

  public validation(): void {
    this.form = this.formBuilder.group({
      tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      local: ['', [Validators.required, Validators.maxLength(50), Validators.minLength(4)]],
      dataEvento: ['', Validators.required],
      qtdPessoas: ['', [Validators.required, Validators.max(120000)]],
      telefone: ['', [Validators.required, Validators.minLength(11)]],
      email: ['', [Validators.required, Validators.email]],
      imagemURL: ['', Validators.required],
    });
  }

  public resetForm(): void {
    this.form.reset();
  }

  public confirm(): void {
    this.toastr.success('Evento adicionado com sucesso', 'Atenção');
  }

  public formValidator(campo: FormControl): any {
    return {'is-invalid': campo.errors && campo.touched};
  }
}
