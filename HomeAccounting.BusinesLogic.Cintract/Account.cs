using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract
{
    /// <summary>
    /// Счет
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Тип счета
        /// </summary>
        public AccountTypes Type { get; set; }

        /// <summary>
        /// Валюта
        /// </summary>
        public CurrencyTypes Currency { get; set; }

        /// <summary>
        /// Название счета
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Может ли счет участвовать в проводках
        /// </summary>
        public bool IsVirtual { get; set; }

        /// <summary>
        /// Родительский счет
        /// </summary>
        public Account ParentAccount { get; set; }

    }
}
