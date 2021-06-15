import { Component, Inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { AccountModel } from '../models/AccountModel';
import { OperationModel } from '../models/OperationModel';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-account-edit',
  templateUrl: './account.edit.component.html'
})
export class AccountEditComponent {
  public account: AccountModel;
  id: number;
  constructor(private http: HttpClient, private activateRoute: ActivatedRoute, @Inject('BASE_URL')  private baseUrl: string) {
    this.id = activateRoute.snapshot.params['id'];
    if (this.id != 0) {
      http.get<AccountModel>(baseUrl + 'api/accounts/' + this.id).subscribe(result => {
        this.account = result;
      }, error => console.error(error));
    }
    else {
      this.account = new AccountModel();
    }
  }

  Save(): void {
    this.http.post<AccountModel>(this.baseUrl + 'api/accounts/' + this.id, this.account).subscribe(result => {
      console.log("saved");
    }, error => console.error(error));
  } 

  

}
