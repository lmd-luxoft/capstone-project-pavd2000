using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract.Dto
{
    public class PropertyModel : AccountModel
    {
        public PropertyModel()
        {
            Type = AccountType.Property;
        }

        public decimal BasePrice { get; set; }
        public string Location { get; set; }
        public PropertyType PropertyType { get; set; }
        public List<PropertyPriceChangeModel> PropertyPriceChanges { get; set; }
    }
}