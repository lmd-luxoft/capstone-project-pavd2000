using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract.Dto
{
    public class BankModel
    {
        public int Id { get; set; }
        public string BIK { get; set; }
        public string Title { get; set; }
        public string CorrAccount { get; set; }
    }
}