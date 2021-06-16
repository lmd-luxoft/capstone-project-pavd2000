using HomeAccounting.BusinesLogic.Contract;
using HomeAccounting.BusinesLogic.Contract.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeAccounting.Angular.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OperationsController : ControllerBase
    {

        private readonly ILogger<OperationsController> _logger;
        private readonly IOperationService _operationService;

        public OperationsController(ILogger<OperationsController> logger, IOperationService operationService)
        {
            _logger = logger;
            _operationService = operationService;
        }

        [HttpGet]
        public async Task<IEnumerable<OperationModel>> Get()
        {
            return await _operationService.SelectByFilter(new OperationModelFilter());
        }
    }
}
