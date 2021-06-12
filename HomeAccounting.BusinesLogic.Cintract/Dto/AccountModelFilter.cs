using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract.Dto
{
    public class AccountModelFilter
    {
        public int Page { get; set; } = 1;
        public int OnPage { get; set; } = 100;

    }
}
