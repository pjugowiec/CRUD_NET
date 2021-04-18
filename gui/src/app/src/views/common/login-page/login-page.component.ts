import { MatSnackBar } from '@angular/material/snack-bar';
import { LoginForm } from './../../../model/external/LoginForm';
import { LoginRestSerivce } from './../../../services/rest/login-rest.service';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { take } from 'rxjs/operators';

@Component({
	selector: 'app-login-page',
	templateUrl: './login-page.component.html',
	styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

	private _loginForm: FormGroup;
	private _langWord: string = 'Lang';
	private _isLoadingResults: boolean;

	constructor(
		private _builder: FormBuilder,
		private _translate: TranslateService,
		private _router: Router,
		private _loginRestService: LoginRestSerivce,
		private _snackBarService: MatSnackBar
	) { }

	get translate(): TranslateService {
		return this._translate;
	}

	get loginForm(): FormGroup {
		return this._loginForm;
	}

	get langWord(): string {
		return this._langWord;
	}

	get isLoadingResults(): boolean {
		return this._isLoadingResults;
	}

	public loginHasError(alias: string, error: string): boolean {
		return this._loginForm.controls[alias] && this._loginForm.controls[alias].hasError(error);
	}

	public ngOnInit() {
		this.createForm();
	}

	public changeLang(value: string) {
		this._translate.use(value);
	}

	public tryLogin() {
		this._isLoadingResults = true;
		this._loginRestService.queryPost(this.collectDataFromLoginFrom())
			.pipe(take(1))
			.subscribe(response => {
				this._isLoadingResults = false;
				this._router.navigateByUrl('employee');
				this._snackBarService.open(this._translate.instant('LOGIN_PANEL.SUCCESS'), 'ok', { duration: 3000 });
			}, (error) => {
				this._isLoadingResults = false;
				this._snackBarService.open(this._translate.instant('LOGIN_PANEL.ERROR'), 'ok', { duration: 3000 });
			});
	}

	private collectDataFromLoginFrom(): LoginForm {
		const loginForm: LoginForm = {
			login: this._loginForm.get('username').value,
			password: this._loginForm.get('password').value
		};
		return loginForm;
	}

	private createForm() {
		this._loginForm = this._builder.group({
			username: ['', [Validators.required]],
			password: ['', [Validators.required]]
		});
	}

}
