using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract
{
    /// <summary>
    /// Фильтр для выбора проводок
    /// </summary>
    public class TransactionsFilter
    {
        public AccountTypes CreditAccountType { get; set; }
        public AccountTypes DebetAccountType { get; set; }

        public Account CreditAccount { get; set; }

        public Account DebetAccount { get; set; }
    }
}
