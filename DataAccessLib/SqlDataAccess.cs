using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;

namespace DataAccessLib
{
    public class SqlDataAccess : IDataAccess
    {
        public string ConnectionString { get; set; }

        public List<T> LoadData<T, U>(string query, U parameters)
        {
            using (IDbConnection conn = new SqlConnection())
            {
                return conn.Query<T>(query, parameters).ToList();
            }
        }

        public void SaveData<U>(string query, U parameters)
        {
            using (IDbConnection conn = new SqlConnection())
            {
                conn.Execute(query, parameters);
            }

        }
    }
}
