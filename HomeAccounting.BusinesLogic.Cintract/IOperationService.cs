using HomeAccounting.BusinesLogic.Contract.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeAccounting.BusinesLogic.Contract
{
    public interface IOperationService
    {
        void CreateOperation(OperationModel account);
    }
}
