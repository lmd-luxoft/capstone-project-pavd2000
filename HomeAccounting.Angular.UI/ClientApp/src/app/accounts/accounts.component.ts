import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AccountModel } from '../models/AccountModel';
import { OperationModel } from '../models/OperationModel';

@Component({
  selector: 'app-accounts',
  templateUrl: './accounts.component.html'
})
export class AccountsComponent {
  public accounts: AccountModel[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<AccountModel[]>(baseUrl + 'api/accounts').subscribe(result => {
      this.accounts = result;
    }, error => console.error(error));
  }

  TypeDescription(type: number): string {
    if (type == 0) {
      return 'Simple'
    }
    if (type == 1) {
      return 'Deposit'
    }
    if (type == 2) {
      return 'Property'
    }
    if (type == 3) {
      return 'Cash'
    }
    return '';
  }

}
