using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract.Dto
{
    public class OperationModel
    { 
        public int Id { get; set; }
        public DateTime ExecutionDate { get; set; }
        public decimal Amount { get; set; }
        public AccountModel FromAccount { get; set; }
        public AccountModel ToAccount { get; set; }
    }
}