using HomeAccounting.BusinesLogic.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract
{
    public interface IAccountingService
    {
        void CreateAccount(AccountModel account);
        AccountModel GetAccountById(int id);
        void UpdateAccount(AccountModel account);
        void DeleteAccountById(int id);
        List<AccountModel> SelectByFilter(AccountModelFilter filter);

    }
}
