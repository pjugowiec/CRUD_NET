import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { TranslateService } from '@ngx-translate/core';
import { EmployeeRestSerivce } from '../../services/rest/employee-rest.service';

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

  private _dataSource: MatTableDataSource<any>;

  constructor(
    private _employeeRestService: EmployeeRestSerivce,
    private _dialog: MatDialog,
    private _snackBarService: MatSnackBar,
    private _translate: TranslateService,) { }

  get displayedColumns() {
    return this._displayedColumns;
  }

  get dataSource() {
    return this._dataSource;
  }

  public ngOnInit(): void {
  }

  public applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this._dataSource.filter = filterValue.trim().toLowerCase();

    if (this._dataSource.paginator) {
      this._dataSource.paginator.firstPage();
    }
  }

}
