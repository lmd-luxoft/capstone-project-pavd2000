using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.EF.Domain
{
    public class Operation : Entity
    {
        public DateTime ExecutionDate { get; set; }
        public decimal Amount { get; set; }
        public Account FromAccount { get; set; }
        public Account ToAccount { get; set; }
    }
}