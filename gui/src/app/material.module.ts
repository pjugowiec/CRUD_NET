import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { MatIconModule } from '@angular/material/icon';
import { MatDialogModule } from '@angular/material/dialog';
import { MatInputModule } from '@angular/material/input';
import { MatTableModule } from '@angular/material/table';
import { MatFormField, MatFormFieldModule } from '@angular/material/form-field';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSelect, MatSelectModule } from '@angular/material/select';


const material = [
    MatButtonModule,
    MatToolbarModule,
    MatDialogModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatTableModule,
    MatInputModule,
    MatIconModule,
    MatCardModule,
    MatSnackBarModule,
    MatSelectModule,
    MatCheckboxModule,
    MatMenuModule,
    MatDatepickerModule
]
@NgModule({
    imports: [material],
    exports: [material]
})
export class MaterialModule { }