import { NavigationComponent } from './common/navigation/navigation.component';
import { ConfirmDialogComponent } from './common/confirm-dialog/confirm-dialog.component';
import { LoginPageComponent } from './common/login-page/login-page.component';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { MaterialModule } from 'src/app/material.module';
import { RestModule } from './../services/rest.module';
import { NgModule } from '@angular/core';
import { EmployeePageComponent } from './employee-page/employee-page.component';

@NgModule({
    declarations: [
        LoginPageComponent,
        ConfirmDialogComponent,
        NavigationComponent,
        EmployeePageComponent
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
        ConfirmDialogComponent
    ]
})
export class ViewsModule { }
