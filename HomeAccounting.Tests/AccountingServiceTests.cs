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
        IOperationService _operationService;
        IDbContextFactory<DomainContext> _contextFactory;

        [SetUp]
        public void Setup()
        {
            var services = new ServiceCollection();
            var app = new EfApplicationBuilder(services);
            app.Buid();
            _serviceProvider = services.BuildServiceProvider();
            _accountingService = _serviceProvider.GetRequiredService<IAccountingService>();
            _operationService = _serviceProvider.GetRequiredService<IOperationService>();
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
                    Title = "ПСБ"
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
        public void SelectAccountsByFilterTest()
        {
            var accouts = _accountingService.SelectByFilter(new AccountModelFilter());
            Assert.True(accouts.Count > 0);
        }


        [Test]
        public void OperationCrudTest()
        {
            var accountModel1 = new AccountModel()
            {
                Title = "For Operation Account 1",
                CreationDate = DateTime.Now,
                Balance = 12.34M,
                Type = AccountType.Simple
            };
            _accountingService.CreateAccount(accountModel1);
            Assert.IsTrue(accountModel1.Id > 0);

            var accountModel2 = new AccountModel()
            {
                Title = "For Operation Account 2",
                CreationDate = DateTime.Now,
                Balance = 23.45M,
                Type = AccountType.Simple
            };
            _accountingService.CreateAccount(accountModel2);
            Assert.IsTrue(accountModel2.Id > 0);

            var operationModel = new OperationModel
            {
                FromAccount = accountModel1,
                ToAccount = accountModel2,
                Amount = 7.65M,
                ExecutionDate = DateTime.Now
            };

            _operationService.Create(operationModel);

            Assert.IsTrue(operationModel.Id > 0);

            var operationModel2 = _operationService.GetById(operationModel.Id);
            Assert.NotNull(operationModel2);

            var list = _operationService.SelectByFilter(new OperationModelFilter());
            Assert.IsTrue(list.Count > 0);

            _operationService.DeleteById(operationModel.Id);

            var operationModel3 = _operationService.GetById(operationModel.Id);
            Assert.Null(operationModel3);
        }

        [Test]
        //[Ignore("Использовать для массовой генерации проводок")]
        public void CreateOperationsTest()
        {
            for (int i = 0; i < 10; i++)
            {
                var accountModel1 = new CashModel()
                {
                    Title = "CashTest",
                    CreationDate = DateTime.Now,
                    Balance = 12.34M,
                    Banknotes = 5,
                    Monets = 6
                };

                _accountingService.CreateAccount(accountModel1);
                Assert.IsTrue(accountModel1.Id > 0);

                var accountModel2 = new DepositModel()
                {
                    Title = "DepositTest",
                    CreationDate = DateTime.Now,
                    Balance = 12.34M,
                    NumberOfBankAccount = "0000000000000000000",
                    Bank = new BankModel()
                    {
                        BIK = "044525555",
                        Title = "ПСБ"
                    },
                    Percent = 0.05M,
                    PercentType = PercentType.Fixed
                };
                _accountingService.CreateAccount(accountModel2);
                Assert.IsTrue(accountModel2.Id > 0);

                var accountModel3 = new PropertyModel()
                {
                    Title = "PropertyTest",
                    CreationDate = DateTime.Now,
                    Balance = 23.45M,
                    Location = "Test Location",
                    BasePrice = 34.56M,
                    PropertyType = PropertyType.Movable
                };
                _accountingService.CreateAccount(accountModel3);
                Assert.IsTrue(accountModel3.Id > 0);

                var operationModel = new OperationModel
                {
                    FromAccount = accountModel1,
                    ToAccount = accountModel2,
                    Amount = 1M,
                    ExecutionDate = DateTime.Now
                };

                _operationService.Create(operationModel);

                var operationModel2 = new OperationModel
                {
                    FromAccount = accountModel2,
                    ToAccount = accountModel1,
                    Amount = 1M,
                    ExecutionDate = DateTime.Now
                };
                _operationService.Create(operationModel2);
                Assert.IsTrue(operationModel2.Id > 0);

                var operationModel3 = new OperationModel
                {
                    FromAccount = accountModel3,
                    ToAccount = accountModel1,
                    Amount = 1M,
                    ExecutionDate = DateTime.Now
                };

                _operationService.Create(operationModel3);

                var operationModel4 = new OperationModel
                {
                    FromAccount = accountModel2,
                    ToAccount = accountModel3,
                    Amount = 1M,
                    ExecutionDate = DateTime.Now
                };
                _operationService.Create(operationModel4);

                var list = _operationService.SelectByFilter(new OperationModelFilter());
                Assert.IsTrue(list.Count > 0);
            }
        }



    }
}