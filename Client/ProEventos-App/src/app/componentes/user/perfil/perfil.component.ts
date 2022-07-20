import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.scss']
})
export class PerfilComponent implements OnInit {
  form: FormGroup = this.formBuilder.group({});

  constructor(
    private formBuilder: FormBuilder,
    private toatrs: ToastrService
  ) { }

  public ngOnInit(): void {
    this.validationForm();
  }

  get f(): any{
    return this.form.controls;
  }

  public validationForm(): void {
    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.ValidaSenhas('password', 'confirmPass')
    };

    this.form = this.formBuilder.group({
      // titulo: ['', Validators.required],
      nome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]],
      ultimoNome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]],
      email: ['', [Validators.required, Validators.email]],
      telefone: ['', [Validators.required, Validators.minLength(11), Validators.maxLength(20)]],
      // funcao: ['', Validators.required],
      descricao: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(25)]],
      password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(15)]],
      confirmPass: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(15)]]
    }, formOptions);
  }

  public confirm(): void {
    this.toatrs.success('Perfil cadastrado com sucesso', 'Atenção');
  }

  public resetForm(): void{
    this.form.reset();
  }
}
