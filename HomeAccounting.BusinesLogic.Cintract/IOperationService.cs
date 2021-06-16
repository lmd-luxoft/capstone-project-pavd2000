using HomeAccounting.BusinesLogic.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HomeAccounting.BusinesLogic.Contract
{
    public interface IOperationService
    {
        Task Create(OperationModel operationModel);
        Task Update(OperationModel operationModel);
        Task DeleteById(int id);
        Task<OperationModel> GetById(int id);
        Task<List<OperationModel>> SelectByFilter(OperationModelFilter filter);

        Task<decimal> AccountBalanceReport(int accountId);
    }
}
