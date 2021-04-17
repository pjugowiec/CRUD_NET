import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';

@Component({
	selector: 'app-login-page',
	templateUrl: './login-page.component.html',
	styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

	private _loginForm: FormGroup;
	private _langWord: string = 'Lang';

	constructor(
		private _builder: FormBuilder,
		private _translate: TranslateService,
		private _router: Router
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
		// TODO po dodaniu autoryzacji wykonać wysyłke na serwer
		// this._loginForm.get('username').value;
		// this._loginForm.get('password').value;
		this._router.navigateByUrl('employee')
	}

	private createForm() {
		this._loginForm = this._builder.group({
			username: ['', [Validators.required]],
			password: ['', [Validators.required]]
		});
	}

}
