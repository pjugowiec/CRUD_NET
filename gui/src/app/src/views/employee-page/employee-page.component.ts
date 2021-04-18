import { ConfirmDialogComponent } from './../common/confirm-dialog/confirm-dialog.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { TranslateService } from '@ngx-translate/core';
import { take } from 'rxjs/operators';
import { Employee } from '../../model/external/Employee';
import { EmployeeRestSerivce } from '../../services/rest/employee-rest.service';
import { EmployeeFormComponent } from './employee-form/employee-form.component';

@Component({
  selector: 'app-employee-page',
  templateUrl: './employee-page.component.html',
  styleUrls: ['./employee-page.component.scss']
})
export class EmployeePageComponent implements OnInit {

  @ViewChild(MatSort, { static: true }) sort: MatSort;
  private _displayedColumns: string[] = [
    'lp',
    'name',
    'surname',
    'age',
    'username',
    'isActive',
    'countOfProjects',
    'action'
  ];

  private _dataSource: MatTableDataSource<Employee>;
  private _isLoadingResults: boolean = true;

  constructor(
    private _employeeRestService: EmployeeRestSerivce,
    private _dialog: MatDialog,
    private _snackBarService: MatSnackBar,
    private _translate: TranslateService) { }

  get displayedColumns() {
    return this._displayedColumns;
  }

  get dataSource() {
    return this._dataSource;
  }

  get isLoadingResults(): boolean {
    return this._isLoadingResults;
  }

  public ngOnInit(): void {
    this.getData();
  }

  public applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this._dataSource.filter = filterValue.trim().toLowerCase();

    if (this._dataSource.paginator) {
      this._dataSource.paginator.firstPage();
    }
  }

  public openEditForm(id: number): void {
    this._isLoadingResults = true;
    this._employeeRestService.queryGetOne(id).subscribe((response) => {
      this._isLoadingResults = false;
      this._dialog.open(EmployeeFormComponent, {
        data: {
          editMode: true,
          employee: response
        }
      }).afterClosed().subscribe((response: boolean) => {
        if (response) {
          this.getData();
        }
      });
    }, (error) => {
      this._snackBarService.open(this._translate.instant('GENERAL.COMMON_ERROR.PROBLEM_WITH_GET'), 'ok', { duration: 3000 });
    });

  }

  public openAddForm(): void {
    this._dialog.open(EmployeeFormComponent, {
      data: {
        editMode: false
      }
    }).afterClosed().subscribe((response: boolean) => {
      if (response) {
        this.getData();
      }
    });
  }

  public openDeleteForm(id: number): void {
    this._dialog.open(ConfirmDialogComponent, {
      data: {
        title: 'EMPLOYEE_PAGE.CONFIRM_DELETE.DELETE_EMPLOYEE',
        message: 'EMPLOYEE_PAGE.CONFIRM_DELETE.DELETE_EMPLOYEE_MESSAGE',
        onConfirm: this._employeeRestService.queryDelete(id),
        error: 'EMPLOYEE_PAGE.CONFIRM_DELETE.ERROR'
      }
    }).afterClosed()
      .subscribe((response) => {
        this._translate
          .get('GENERAL.INFO.DELETE_SUCCESS')
          .subscribe((res: string) => {
            this._snackBarService.open(res, 'ok', { duration: 3000 });
          });

        this.getData();

      });
  }

  private getData(): void {
    this._isLoadingResults = true;
    this._employeeRestService
      .queryGetAll()
      .pipe(take(1))
      .subscribe(
        (response) => {
          this._isLoadingResults = false;
          this._dataSource = new MatTableDataSource(response);
          this._dataSource.sort = this.sort;
        },
        (error) => {
          this._isLoadingResults = false;
          this._translate
            .get('GENERAL.COMMON_ERROR.PROBLEM_WITH_GET')
            .subscribe((res: string) => {
              this._snackBarService.open(res, 'ok', { duration: 3000 });
            });
        }
      );
  }

}
