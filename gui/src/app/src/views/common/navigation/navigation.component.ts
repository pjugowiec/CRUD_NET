import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { Router } from '@angular/router';

type Language = 'en' | 'pl';

@Component({
	selector: 'app-navigation',
	templateUrl: './navigation.component.html',
	styleUrls: ['./navigation.component.scss']
})
export class NavigationComponent {

	private _langsToChoose: Language;


	constructor(
		private _translate: TranslateService,
		private _router: Router
	) {
		_translate.setDefaultLang('pl');
	}

	get langsToChoose(): Language {
		return this._langsToChoose;
	}

	changeLang(choose: Language) {
		switch (choose) {
			case 'en':
				console.log(choose)
				this._translate.use('en');
				break;
			case 'pl':
				this._translate.use('pl');
				break;
		}
	}

	tryLogout() {
		this._router.navigateByUrl('');
	}
}
