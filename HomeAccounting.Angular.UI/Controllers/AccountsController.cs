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
    public class AccountsController : ControllerBase
    {

        private readonly ILogger<AccountsController> _logger;
        private readonly IAccountingService _accountsService;

        public AccountsController(ILogger<AccountsController> logger, IAccountingService accountsService)
        {
            _logger = logger;
            _accountsService = accountsService;
        }

        [HttpGet]
        public IEnumerable<AccountModel> Get()
        {
            return _accountsService.SelectByFilter(new AccountModelFilter());
        }

        [HttpGet("{id:int}")]
        public AccountModel Get(int id)
        {
            return _accountsService.GetAccountById(id);
        }

        [HttpPost("{id:int}")]
        public void Post(AccountModel model)
        {
             _accountsService.UpdateAccount(model);
        }
    }
}
