using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract
{
    /// <summary>
    /// Баланс
    /// </summary>
    public class Balance
    {
        public DateTime Date { get; set; }
        public AccountTypes AccountType { get; set; }
        public Account Account { get; set; }
        public decimal Sum { get; set; }
        public CurrencyTypes Currency { get; set; }

    }
}
