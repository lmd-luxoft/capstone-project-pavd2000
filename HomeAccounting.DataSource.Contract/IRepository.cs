using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.DataSource.Contract
{
    public interface IRepository
    {
        void AddAccount(DbAccount account);
        DbAccount GetAccountById(int id);
    }
}
