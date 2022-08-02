import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/helpers/ValidatorField';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {
  form: FormGroup = this.formBuilder.group({});

  constructor(
    private formBuilder: FormBuilder,
    private toastr: ToastrService
  ) { }

  public ngOnInit(): void {
    this.validationForm();
  }

  get f(): any {
    return this.form.controls;
  }

  public validationForm() {
    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.ValidaSenhas('password', 'confirmPass')
    };

    this.form = this.formBuilder.group({
      nome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]],
      ultimoNome: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]],
      email: ['', [Validators.required, Validators.email]],
      user: ['', [Validators.required, Validators.minLength(3), Validators.maxLength(20)]],
      password: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(15)]],
      confirmPass: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(15)]]
    }, formOptions);
  }

  public confirm(): void {
    this.toastr.success('Usuário cadastrado com sucesso', 'Atenção');
  }

  public formValidator(campo: FormControl): any {
    return {'is-invalid': campo.errors && campo.touched};
  }
}
