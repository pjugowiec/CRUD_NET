import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { TranslateService } from '@ngx-translate/core';
import { Observable, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';

@Component({
    selector: 'app-confirm-dialog',
    templateUrl: './confirm-dialog.component.html',
    styleUrls: ['./confirm-dialog.component.scss']
})
export class ConfirmDialogComponent {

    private readonly _title: string;
    private readonly _message: string;
    private readonly _error: string;
    private readonly _confirmButtonLabel: string;
    private readonly _isRegular: boolean;
    private readonly _onConfirm: Observable<any>;
    private readonly _destroyed = new Subject();
    private readonly _onError: (error) => void;

    constructor(@Inject(MAT_DIALOG_DATA) data:
        {
            title: string,
            message: string,
            confirmButtonLabel?: string,
            onConfirm: Observable<any>,
            error: string,
            isRegular?: boolean;
            onError: (error) => void;
        },
        private _dialogRef: MatDialogRef<ConfirmDialogComponent>,
        private _snackBarService: MatSnackBar) {

        this._title = data.title;
        this._message = data.message;
        this._confirmButtonLabel = data.confirmButtonLabel;
        this._onConfirm = data.onConfirm;
        this._error = data.error;
        this._isRegular = !!data.isRegular;
        this._onError = data.onError;
    }


    get message(): string {
        return this._message;
    }

    get title(): string {
        return this._title;
    }

    get confirmButtonLabel(): string {
        return this._confirmButtonLabel;
    }

    get isRegular() {
        return this._isRegular;
    }

    onCancel() {
        this._dialogRef.close(false);
    }

    onConfirm() {
        if (this._onConfirm) {
            this._onConfirm.pipe(takeUntil(this._destroyed)).subscribe(
                () => this._dialogRef.close(true),
                (error) => {
                    if (this._onError) {
                        this._onError(error);
                    } else {
                        this._snackBarService.open(this._error, 'Ok', { duration: 3000 });
                    }
                }
            );
        } else {
            this._dialogRef.close(false);
        }
    }
}
