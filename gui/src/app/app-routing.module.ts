import { LoginPageComponent } from './src/views/common/login-page/login-page.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EmployeePageComponent } from './src/views/employee-page/employee-page.component';

const routes: Routes = [
  { path: '', component: LoginPageComponent },
  { path: 'employee', component: EmployeePageComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
