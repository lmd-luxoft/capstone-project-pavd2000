using HomeAccounting.BusinesLogic.Contract;
using HomeAccounting.BusinesLogic.Contract.Dto;
using HomeAccounting.BusinesLogic.EF.ApplicationLogic;
using HomeAccounting.CompositionRoot;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System;
using System.Linq;

namespace HomeAccounting.Tests
{
    public class AccountingServiceTests
    {
        IServiceProvider _serviceProvider;
        IAccountingService _accountingService;
        IDbContextFactory<DomainContext> _contextFactory;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            var app = new EfApplicationBuilder(services);
            app.Buid();
            _serviceProvider = services.BuildServiceProvider();
            _accountingService = _serviceProvider.GetRequiredService<IAccountingService>();
            _contextFactory = _serviceProvider.GetRequiredService<IDbContextFactory<DomainContext>>();
        }

        [Test]
        public void CreateSimpleAccountTest()
        {
            var accountModel = new AccountModel()
            {
                Title = "test",
                CreationDate = DateTime.Now,
                Balance = 12.34M
            };
            _accountingService.CreateAccount(accountModel);
            Assert.IsTrue(accountModel.Id > 0);
        }

        [Test]
        public void CreatePropertyTest()
        {
            var accountModel = new PropertyModel()
            {
                Title = "PropertyTest",
                CreationDate = DateTime.Now,
                Balance = 23.45M,
                Location = "Test Location",
                BasePrice = 34.56M,
                PropertyType = PropertyType.Movable
            };
            _accountingService.CreateAccount(accountModel);
            Assert.IsTrue(accountModel.Id > 0);
        }

        [Test]
        public void CrudCashTest()
        {
            var accountModel = new CashModel()
            {
                Title = "CashTest",
                CreationDate = DateTime.Now,
                Balance = 12.34M,
                Banknotes = 5,
                Monets = 6
            };
            _accountingService.CreateAccount(accountModel);
            Assert.IsTrue(accountModel.Id > 0);

            var accountModel2 = (CashModel) _accountingService.GetAccountById(accountModel.Id);
            Assert.NotNull(accountModel2);
            accountModel2.Monets = 7;
            _accountingService.UpdateAccount(accountModel2);

            var accountModel3 = (CashModel)_accountingService.GetAccountById(accountModel2.Id);
            Assert.AreEqual(7, accountModel3.Monets);

            _accountingService.DeleteAccountById(accountModel3.Id);

            var accountModel4 = _accountingService.GetAccountById(accountModel3.Id);
            Assert.Null(accountModel4);
        }

        [Test]
        public void CreateDepositTest()
        {
            var accountModel = new DepositModel()
            {
                Title = "DepositTest",
                CreationDate = DateTime.Now,
                Balance = 12.34M,
                NumberOfBankAccount = "0000000000000000000",
                Bank= new BankModel()
                {
                    BIK = "044525555",
                    Title = "ÏÑÁ"
                },
                Percent = 0.05M,
                PercentType = PercentType.Fixed
            };
            _accountingService.CreateAccount(accountModel);
            Assert.IsTrue(accountModel.Id > 0);
        }
        
        [Test]
        public void DbContextTest()
        {
            using(var ctx = _contextFactory.CreateDbContext())
            {
                var account = ctx.Accounts.FirstOrDefault(x => x.Id == 14);
                Assert.NotNull(account);
            }
        }

        [Test]
        public void SelectByFilterTest()
        {
            var accouts = _accountingService.SelectByFilter(new AccountModelFilter());
            Assert.True(accouts.Count > 0);
        }

    }
}