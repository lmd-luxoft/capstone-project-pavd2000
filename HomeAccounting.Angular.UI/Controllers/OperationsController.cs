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
    [Route("[controller]")]
    public class OperationsController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IOperationService _operationService;

        public OperationsController(ILogger<WeatherForecastController> logger, IOperationService operationService)
        {
            _logger = logger;
            _operationService = operationService;
        }

        [HttpGet]
        public IEnumerable<OperationModel> Get()
        {
            return _operationService.SelectByFilter(new OperationModelFilter());
        }
    }
}
