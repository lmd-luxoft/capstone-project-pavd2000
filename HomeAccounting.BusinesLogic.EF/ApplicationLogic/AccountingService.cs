using HomeAccounting.BusinesLogic.Contract;
using HomeAccounting.BusinesLogic.Contract.dto;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.EF.ApplicationLogic
{
    public class AccountingService : IAccountingService
    {
        DomainContext _ctx;
        public AccountingService(DomainContext ctx)
        {
            _ctx = ctx;
        }

        public void CreateAccount(AccountModel account)
        {
            Account newAccount = null;
            switch(account.Type)
            {
                case AccountType.Simple:
                    newAccount = CreateSimpleAccount(account);
                    break;

                case AccountType.Cash:
                    newAccount = CreateCash(account);
                    break;
                case AccountType.Property:
                    newAccount = CreateProperty(account);
                    break;
                case AccountType.Deposit:
                    newAccount = CreateDeposit(account);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("bad type account");

            }
        }

        private Account CreateDeposit(AccountModel account)
        {
            var bOld = _ctx.Banks.Where(p => p.BIK == (string)account.Params[0]).FirstOrDefault();

            var d = new Deposit
            {
                Balance = account.Amount,
                CreationDate = DateTime.Now,
                Bank = new Bank()
                {
                    BIK = (string)account.Params[0],
                    CorrAccount = (string)account.Params[1],
                    Title = (string)account.Params[2],
                },
                Title = account.Title,
                Percent = (decimal)account.Params[3]
            };
            _ctx.Deposites.Add(d);
            return d;
        }

        private Account CreateProperty(AccountModel account)
        {
            return  new Property()
            {
                Balance = account.Amount,
                CreationDate = DateTime.Now,
                Location = "Moscow",
                Title = account.Title,
                Type = (PropertyType)account.Params[0]
            };
        }

        private Account CreateCash(AccountModel account)
        {
            throw new NotImplementedException();
        }

        private Account CreateSimpleAccount(AccountModel account)
        {
            throw new NotImplementedException();
        }
    }
}
