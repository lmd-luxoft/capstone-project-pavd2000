using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract
{
    public class Account
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }

    }
}
