using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;



namespace dappercrudapi.Model
{
    public class ProductRepository
    {
        private string connectionString;
        public ProductRepository()
        {
            connectionString = @"Persist Security info=False;User ID=sa;password=123;Initial Catalog=DAPPERDB; 
            Data Source=ASHRAFULDESKTOP\SQL2014;Connection Timeout = 100000;";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public void Add(Product prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Products (Nome,Quantidade,Price) VALUES(@Nome,@Quantidade,@Price)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, prod);
            }
        }
        public IEnumerable<Product> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * FROM Products";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery);
            }
        }
        public Product GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * FROM Products Where ProductID=@Id";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM Products Where ProductID=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }
        public void Update(Product prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Products SET Nome=@Nome,Quantidade=@Quantidade,Price=@Price where
                ProductId=@Product_ID";
                dbConnection.Open();
                dbConnection.Query(sQuery, prod);
            }
        }
    }
}