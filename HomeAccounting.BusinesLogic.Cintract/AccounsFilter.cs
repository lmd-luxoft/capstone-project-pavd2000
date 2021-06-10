using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract
{
    /// <summary>
    /// Фильтр для выбора счетов
    /// </summary>
    public class AccounsFilter
    {
        public AccountTypes AccountType { get; set; }
    }
}
