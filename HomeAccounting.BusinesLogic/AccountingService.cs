//using HomeAccounting.BusinesLogic.Contract;
//using HomeAccounting.DataSource.Contract;
//using System;
//using System.Collections.Generic;
//using System.Text;


//namespace HomeAccounting.BusinesLogic
//{
//    public class AccountingService : IAccounting
//    {
//        public IRepository _repo;

//        public AccountingService(IRepository repo)
//        {
//            _repo = repo;
//        }


//        public void CreateAccount(Account account)
//        {

//            DbAccount dto = MapEnityToDto(account);
//            _repo.AddAccount(dto);
//        }

//        private static DbAccount MapEnityToDto(Account account)
//        {
//            return new DbAccount()
//            {
//                Id = account.Id,
//                Title = account.Title,
//                CreationDate = account.CreationDate


//            };

//        }
//        public Account GetAccountById(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public void SaveAccount(Account account)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
