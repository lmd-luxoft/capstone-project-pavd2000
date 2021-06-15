import { AccountModel } from './AccountModel';
export class OperationModel {
  Id: number;
  ExecutionDate: Date;
  Amount: number;
  FromAccount: AccountModel;
  ToAccount: AccountModel;
}

