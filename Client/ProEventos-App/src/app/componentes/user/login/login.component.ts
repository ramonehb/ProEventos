import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { ActivatedRoute, Router } from '@angular/router';
import {Login} from '@app/models/Login';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  login = {} as Login;
  form: FormGroup = this.formBuilder.group({});

  constructor(
    private formBuilder: FormBuilder,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.validacao();
  }

  get l(): any {
    return this.form.controls;
  }

  public formValidator(campo: FormControl | AbstractControl): any {
    return { 'is-invalid': campo.errors && campo.touched };
  }

  public validacao(): void {
    this.form = this.formBuilder.group({
      email: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(30)]]
    });
  }
  public EntrarSistema(login: Login): void {

  }
}
