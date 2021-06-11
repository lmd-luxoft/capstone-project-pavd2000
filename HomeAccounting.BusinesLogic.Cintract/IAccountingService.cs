using HomeAccounting.BusinesLogic.Contract.dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract
{
    public interface IAccountingService
    {
        void CreateAccount(AccountModel account);
    }
}
