using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract
{
    /// <summary>
    /// Тип счета. Активы = Пассивы + Капитал
    /// </summary>
    public enum AccountTypes
    {
        // Активы (тип дебит)
        Assets,
        // Пассивы (Обязательства) (тип кредит)
        Liabilities,
        // Собственный капитал (тип кредит)
        Equity,
        // Доходы (тип дебит)
        Income,
        // Расходы (тип кредит)
        Expenses

    }
}
