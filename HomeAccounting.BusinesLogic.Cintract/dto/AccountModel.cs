using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract.Dto
{
    public class AccountModel
    {
        public AccountModel()
        {
            Type = AccountType.Simple;
        }
        public  int Id { get; set; }
        public string Title { get; set; }
        public decimal Balance { get; set; }
        public DateTime CreationDate { get; set; }
        public AccountType Type { get; set; }
    }

    public enum AccountType
    {
        Simple, Deposit, Property, Cash
    }
}
