import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AccountModel } from '../models/AccountModel';
import { OperationModel } from '../models/OperationModel';

@Component({
  selector: 'app-account-edit',
  templateUrl: './account.edit.component.html'
})
export class AccountEditComponent {
  public account: AccountModel;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    //http.get<AccountModel[]>(baseUrl + 'accounts').subscribe(result => {
    //  this.accounts = result;
    //}, error => console.error(error));
  }

  

}
