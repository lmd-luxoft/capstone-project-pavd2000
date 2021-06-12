using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.EF.Domain
{
    public class PropertyPriceChange : Entity
    {
        public DateTime RegistrationDate { get; set; }
        public decimal Delta { get; set; }
    }
}