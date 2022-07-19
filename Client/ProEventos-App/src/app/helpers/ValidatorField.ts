import { AbstractControl, FormGroup } from "@angular/forms";

export class ValidatorField {
  static ValidaSenhas(controlName: string, matchingControlName: string): any{
    return (group: AbstractControl) => {
      const formGroup = group as FormGroup;
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];

      if (matchingControl.errors && !matchingControl.errors.senhasIguais){
        return null;
      }

      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({senhasIguais: true})
      } else {
        matchingControl.setErrors(null)
      }

      return null;
    };
  }
}
