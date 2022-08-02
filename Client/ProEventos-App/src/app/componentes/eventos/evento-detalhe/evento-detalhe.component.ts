import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Constants } from '@app/util/constants';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-evento-detalhe',
  templateUrl: './evento-detalhe.component.html',
  styleUrls: ['./evento-detalhe.component.scss']
})
export class EventoDetalheComponent implements OnInit {

  form: FormGroup = this.formBuilder.group({});

  get f(): any {
    return this.form.controls;
  }

  get bsConfig(): any {
    return {
      isAnimated: true,
      adaptivePosition: true,
      dateInputFormat: 'DD/MM/YYYY hh:mm a',
      containerClass: 'theme-default',
      showWeekNumbers: false
    };
  }
  constructor(
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private localeService: BsLocaleService
  ) {
    this.localeService.use(Constants.LocalProject);
  }

  ngOnInit(): void {
    this.validation();
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
