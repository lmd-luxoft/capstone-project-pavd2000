using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract
{
    public interface IAccounting
    {
        void CreateAccount(Account account);
        Account GetAccountById(int id);
        void SaveAccount(Account account);

    }
}
