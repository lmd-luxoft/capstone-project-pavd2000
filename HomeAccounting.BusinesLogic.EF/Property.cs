using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.EF
{
    public class Property : Account
    {
        public int BasePrice
        {
            get => default;
            set
            {
            }
        }

        public string Location
        {
            get => default;
            set
            {
            }
        }


        public PropertyType Type
        {
            get => default;
            set
            {
            }
        }

        public IEnumerable<PropertyPriceChange> PropertyPriceChanges
        {
            get => default;
            set
            {
            }
        }
    }
}