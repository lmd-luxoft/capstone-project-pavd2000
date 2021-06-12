using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.EF.Domain
{
    public class Cash : Account
    {
        public int Banknotes { get; set; }
        public int Monets { get; set; }
    }
}