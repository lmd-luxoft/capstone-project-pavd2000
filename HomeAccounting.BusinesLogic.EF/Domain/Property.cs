using HomeAccounting.BusinesLogic.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.EF.Domain
{
    public class Property : Account
    {
        public decimal BasePrice { get; set; }
        public string Location { get; set; }
        public PropertyType Type { get; set; }
        public IEnumerable<PropertyPriceChange> PropertyPriceChanges { get; set; }
    }
}