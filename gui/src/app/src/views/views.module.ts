import { LoginPageComponent } from './common/login-page/login-page.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { MaterialModule } from 'src/app/material.module';
import { RestModule } from './../services/rest.module';
import { NgModule } from '@angular/core';

@NgModule({
    declarations: [
        LoginPageComponent
    ],
    imports: [
        MaterialModule,
        CommonModule,
        RestModule,
        ReactiveFormsModule,
        FormsModule,
        TranslateModule.forChild()
    ],
    entryComponents: [
    ]
})
export class ViewsModule { }
