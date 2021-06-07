using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract
{
    /// <summary>
    /// Проводка
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Счет по дебету (куда)
        /// </summary>
        public Account DebetAccount { get; set; }

        /// <summary>
        /// Счет по кредиту (откуда)
        /// </summary>
        public Account CreditAccount { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public decimal Sum { get; set; }

        /// <summary>
        /// Валюта
        /// </summary>
        public CurrencyTypes Currency { get; set; }

        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }


    }
}
