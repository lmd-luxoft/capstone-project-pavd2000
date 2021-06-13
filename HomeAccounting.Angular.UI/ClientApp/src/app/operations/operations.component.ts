import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AccountModel } from '../models/AccountModel';
import { OperationModel } from '../models/OperationModel';

@Component({
  selector: 'app-operations',
  templateUrl: './operations.component.html'
})
export class OperationsComponent {
  public operations: OperationModel[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<OperationModel[]>(baseUrl + 'operations').subscribe(result => {
      this.operations = result;
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

    return 'zzzz';
  }

}
