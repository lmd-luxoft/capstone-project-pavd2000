using HomeAccounting.BusinesLogic.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.EF.Domain
{
    public class Deposit : Account
    {
        public string NumberOfBankAccount { get; set; }
        public decimal Percent { get; set; }
        public PercentType PercentType { get; set; }
        public Bank Bank { get; set; }
    }
}