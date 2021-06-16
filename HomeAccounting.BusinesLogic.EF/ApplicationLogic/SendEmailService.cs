using HomeAccounting.BusinesLogic.Contract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.BusinesLogic.EF.ApplicationLogic
{
    public class SendEmailService : ISendEmailService
    {
        public async Task SendEmail(string email, string body)
        {
            await Task.Delay(10000);
        }
    }
}
