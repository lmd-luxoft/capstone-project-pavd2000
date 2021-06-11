using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract.dto
{
    public class AccountModel
    {
        public string Title { get; set; }
        public decimal Amount { get; set; }

        public Object[] Params { get; set; }

        public AccountType Type { get; set; }
    }

    public enum AccountType
    {
        Simple, Deposit, Property, Cash
    }
}
