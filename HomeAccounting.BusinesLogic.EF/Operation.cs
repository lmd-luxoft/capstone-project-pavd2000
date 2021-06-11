using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.EF
{
    public class Operation : Entity
    {
        public System.DateTime ExecutionDate
        {
            get => default;
            set
            {
            }
        }

        public decimal Amount
        {
            get => default;
            set
            {
            }
        }

        public IEnumerable<Account> Accounts
        {
            get => default;
            set
            {
            }
        }
    }
}