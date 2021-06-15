using HomeAccounting.DataSource.Contract;
using System;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Linq;

namespace HomeAccounting.DataSource
{
    public class RepositoryBaseSql : IRepository
    {

        private string _connectionString = "Server=pvd;Database=Education;User Id=test;Password=test;";
        public void AddAccount(DbAccount account)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                db.Execute("insert into Accounts (creationdate, title) values (@CreationDate, @Title)", account);
            }
        }

        public DbAccount GetAccountById(int id)
        {
            using (var db = new SqlConnection(_connectionString))
            {
                return  db.Query< DbAccount>($"select * from accounts where Id = {id}").FirstOrDefault();
            }
        }
    }
}
