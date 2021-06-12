using System;

namespace HomeAccounting.BusinesLogic.EF.Domain
{
    public class Account : Entity
    {
        public DateTime CreationDate { get; set; }
        public decimal Balance { get; set; }
        public string Title { get; set; }
    }
}