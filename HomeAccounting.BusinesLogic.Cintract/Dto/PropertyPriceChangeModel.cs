using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract.Dto
{
    public class PropertyPriceChangeModel
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public decimal Delta { get; set; }
    }
}