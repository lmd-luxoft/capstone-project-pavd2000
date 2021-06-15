using HomeAccounting.BusinesLogic.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract
{
    public interface IAccountingService
    {
        void CreateAccount(AccountModel account);
        void UpdateAccount(AccountModel account);
        void DeleteAccountById(int id);
        AccountModel GetAccountById(int id);
        List<AccountModel> SelectByFilter(AccountModelFilter filter);

    }
}
