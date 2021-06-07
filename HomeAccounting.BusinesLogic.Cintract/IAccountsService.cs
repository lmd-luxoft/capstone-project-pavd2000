using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract
{
    /// <summary>
    /// Работаем со счетами
    /// </summary>
    public interface IAccountsService
    {
        void Add(Account account);
        void Delete(Account account);

        void Update(Account account);

        List<Account> SelectByFilter(AccounsFilter accountsFilter);

        Balance GetBalance(DateTime date, AccountTypes accountType);

        Balance GetBalance(DateTime date, Account account);


    }
}
