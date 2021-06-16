using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.BusinesLogic.Contract
{
    public interface ISendEmailService
    {
        Task SendEmail(string email, string body);
    }
}
