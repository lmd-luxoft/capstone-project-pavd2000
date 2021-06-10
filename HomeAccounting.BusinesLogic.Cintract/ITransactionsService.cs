using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract
{
    /// <summary>
    /// Работаем с проводками
    /// </summary>
    public interface ITransactionsService
    {
        void Add(Transaction account);
        void Delete(Transaction account);

        void Update(Transaction account);

        List<Transaction> SelectByFilter(TransactionsFilter accountsFilter);
    }
}
