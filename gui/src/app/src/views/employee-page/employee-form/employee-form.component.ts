import { EmployeeRestSerivce } from './../../../services/rest/employee-rest.service';
import { UserModify } from '../../../model/external/UserModify';
import { EmployeeModify } from '../../../model/external/EmployeeModify';
import { AddressModify } from '../../../model/external/AddressModify';
import { Component, Inject, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.scss']
})
export class EmployeeFormComponent implements OnInit {

  private readonly _isEditMode: boolean;
  private _personalInfoForm: FormGroup;
  private _addressForm: FormGroup;
  private _userForm: FormGroup;
  private _hidePassword: boolean = true;
  private _employeeToFill: EmployeeModify;

  constructor(@Inject(MAT_DIALOG_DATA) data:
    {
      editMode: boolean,
      employee?: EmployeeModify
    },
    private _dialogRef: MatDialogRef<EmployeeFormComponent>,
    private _snackBarService: MatSnackBar,
    private _formBuilder: FormBuilder,
    private _translateService: TranslateService,
    private _employeeRestService: EmployeeRestSerivce) {

    this._isEditMode = data.editMode;
    this.checkIfExistIfYesAssign(data.employee);

  }

  get isEditMode(): boolean {
    return this._isEditMode;
  }

  get personalInfoForm(): FormGroup {
    return this._personalInfoForm;
  }

  get addressForm(): FormGroup {
    return this._addressForm;
  }

  get userForm(): FormGroup {
    return this._userForm;
  }

  get hidePassword(): boolean {
    return this._hidePassword;
  }

  set setHidePassword(value: boolean) {
    this._hidePassword = value;
  }

  ngOnInit() {
    this.createForms();
    if (this._isEditMode) { this.fillForms() }

  }

  private fillForms(): void {
    console.log(this._employeeToFill)
    this.fillPersonalForm();
    this.fillAddressForm();
    this.fillUserForm();
  }

  public clearForms(): void {
    this.createForms();
    this._snackBarService.open(this._translateService.instant('GENERAL.INFO.FORM_CLEAR'), 'ok', { duration: 3000 });
  }

  public checkIfFormsAreValid(): boolean {
    return this._personalInfoForm.valid && this._addressForm.valid && this._userForm.valid;
  }

  public save(): void {
    let employee: EmployeeModify = {
      name: this._personalInfoForm.get('name').value,
      surname: this._personalInfoForm.get('surname').value,
      dateBirth: this._personalInfoForm.get('dateBirth').value,
      address: this.collectDataFromAddressForm(),
      user: this.collectDataFromUserForm()
    };
    if (this._isEditMode) {
      employee.address.id = this._employeeToFill.address.id;
      employee.user.id = this._employeeToFill.user.id;
      this.sendToUpdate(employee);
    } else {
      this.sendToCreate(employee);
    }
    this._dialogRef.close(true);
  }

  public personalHasError(alias: string, error: string): boolean {
    return this._personalInfoForm.controls[alias] && this._personalInfoForm.controls[alias].hasError(error);
  }

  public addressHasError(alias: string, error: string): boolean {
    return this._addressForm.controls[alias] && this._addressForm.controls[alias].hasError(error);
  }

  public userHasError(alias: string, error: string): boolean {
    return this._userForm.controls[alias] && this._userForm.controls[alias].hasError(error);
  }

  public exit(): void {
    this._dialogRef.close(false);
  }

  private collectDataFromAddressForm(): AddressModify {
    const address: AddressModify = {
      street: this._addressForm.get('street').value,
      number: this._addressForm.get('number').value,
      city: this._addressForm.get('city').value
    };
    return address;
  }

  private collectDataFromUserForm(): UserModify {

    let user: UserModify;
    if (this._isEditMode) {
      user = {
        login: this._userForm.get('username').value,
        password: null,
        email: this._userForm.get('email').value
      };
    } else {
      user = {
        login: this._userForm.get('username').value,
        password: this._userForm.get('password').value,
        email: this._userForm.get('email').value
      };
    }

    return user;
  }

  private createForms() {
    this._personalInfoForm = this._formBuilder.group({
      name: ['', Validators.required],
      surname: ['', Validators.required],
      dateBirth: ['', Validators.required]
    });

    this._addressForm = this._formBuilder.group({
      street: ['', Validators.required],
      number: ['', Validators.required],
      city: ['', Validators.required]
    });

    if (this._isEditMode) {
      this._userForm = this._formBuilder.group({
        username: ['', [Validators.required, Validators.minLength(6)]],
        email: ['', [Validators.required, Validators.email]]
      });
    } else {
      this._userForm = this._formBuilder.group({
        username: ['', [Validators.required, Validators.minLength(6)]],
        password: ['', [Validators.required, Validators.minLength(8)]],
        email: ['', [Validators.required, Validators.email]]
      });
    }
  }

  private fillPersonalForm(): void {
    this._personalInfoForm.get('name').setValue(this._employeeToFill.name);
    this._personalInfoForm.get('surname').setValue(this._employeeToFill.surname);
    this._personalInfoForm.get('dateBirth').setValue(this._employeeToFill.dateBirth);
  }

  private fillAddressForm(): void {
    this._addressForm.get('street').setValue(this._employeeToFill.address.street);
    this._addressForm.get('city').setValue(this._employeeToFill.address.city);
    this._addressForm.get('number').setValue(this._employeeToFill.address.number);
  }

  private fillUserForm(): void {
    this._userForm.get('username').setValue(this._employeeToFill.user.login);
    this._userForm.get('email').setValue(this._employeeToFill.user.email);
  }

  private checkIfExistIfYesAssign(employee: EmployeeModify): void {
    if (employee) {
      this._employeeToFill = employee;
    }
  }

  private sendToUpdate(employee: EmployeeModify): void {
    this._employeeRestService.queryPut(employee, this._employeeToFill.id).subscribe((response) => {
      this._snackBarService.open(this._translateService.instant('GENERAL.INFO.SAVE_SUCCES'), 'ok', { duration: 3000 });
    },
      (error) => {
        this._snackBarService.open(this._translateService.instant('GENERAL.COMMON_ERROR.PROBLEM_WITH_SAVE'), 'ok', { duration: 3000 });
      });
  }

  private sendToCreate(employee: EmployeeModify): void {
    this._employeeRestService.queryPost(employee).subscribe((response) => {
      this._snackBarService.open(this._translateService.instant('GENERAL.INFO.SAVE_SUCCES'), 'ok', { duration: 3000 });
    },
      (error) => {
        this._snackBarService.open(this._translateService.instant('GENERAL.COMMON_ERROR.PROBLEM_WITH_SAVE'), 'ok', { duration: 3000 });
      });
  }
}
