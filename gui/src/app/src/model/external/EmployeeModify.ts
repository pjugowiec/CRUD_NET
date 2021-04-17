import { AddressModify } from './AddressModify';
import { UserModify } from './UserModify';

export class EmployeeModify {
    id?: number;
    name: string;
    surname: string;
    dateBirth: Date;
    user: UserModify;
    address: AddressModify;
}