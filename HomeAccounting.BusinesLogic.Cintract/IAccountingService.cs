using HomeAccounting.BusinesLogic.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.BusinesLogic.Contract
{
    public interface IAccountingService
    {
        Task CreateAccount(AccountModel account);
        Task UpdateAccount(AccountModel account);
        Task DeleteAccountById(int id);
        Task<AccountModel> GetAccountById(int id);
        Task<List<AccountModel>> SelectByFilter(AccountModelFilter filter);

    }
}
