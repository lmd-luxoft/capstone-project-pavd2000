using HomeAccounting.BusinesLogic.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract
{
    public interface IOperationService
    {
        void Create(OperationModel operationModel);
        void Update(OperationModel operationModel);
        void DeleteById(int id);
        OperationModel GetById(int id);
        List<OperationModel> SelectByFilter(OperationModelFilter filter);

        decimal AccountBalanceReport(int accountId);
    }
}
