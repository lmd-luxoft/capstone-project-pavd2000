using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract.Dto
{
    public class DepositModel : AccountModel
    {
        public DepositModel()
        {
            Type = AccountType.Deposit;
        }
        public string NumberOfBankAccount { get; set; }
        public decimal Percent { get; set; }
        public PercentType PercentType { get; set; }
        public BankModel Bank { get; set; }
    }
}