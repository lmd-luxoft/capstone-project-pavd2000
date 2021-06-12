using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract.Dto
{
    public class CashModel : AccountModel
    {
        public CashModel()
        {
            Type = AccountType.Cash;
        }
        public int Banknotes { get; set; }
        public int Monets { get; set; }
    }
}