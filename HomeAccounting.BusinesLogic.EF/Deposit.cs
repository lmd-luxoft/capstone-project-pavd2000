using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.EF
{
    public class Deposit : Account
    {
        public string NumberOfBankAccount
        {
            get => default;
            set
            {
            }
        }

        public decimal Percent
        {
            get => default;
            set
            {
            }
        }

        public PercentType Type
        {
            get => default;
            set
            {
            }
        }

        public Bank Bank
        {
            get => default;
            set
            {
            }
        }
    }
}