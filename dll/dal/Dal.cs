using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Configuration;
using System.Data;

namespace dal
{
    
    public class Dal
    {
        private DbConnection con;
        private DbCommand com;
        private DbProviderFactory factory;
        public Dal(string conStrName)
        {
            string provider = ConfigurationManager.ConnectionStrings[conStrName].ProviderName;
            factory = DbProviderFactories.GetFactory(provider);

            con = factory.CreateConnection();
            com = factory.CreateCommand();

            con.ConnectionString = ConfigurationManager.ConnectionStrings[conStrName].ConnectionString;
            com.Connection = con;
        }
        public void Open()
        {
            con.Open();
            
        }

        public void Close()
        {
            con.Close();
        }

        public void ExecuteNonQuery(string sql)
        {
            com.CommandText = sql;
            com.ExecuteNonQuery();
        }
        public DbDataReader ExecuteReader(string sql, params DbParameter[] parameters)
        {
            com.CommandText = sql;
            com.Parameters.AddRange(parameters);
            DbDataReader reader = com.ExecuteReader();
            com.Parameters.Clear();
            return reader;
        }
        public DbParameter CreateParameter(string name, object value)
        {
            DbParameter p = factory.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            return p;
        }
        public DbParameter CreateParameter(string name, object value, DbType type)
        {
            DbParameter p = factory.CreateParameter();
            p.ParameterName = name;
            p.Value = value;
            p.DbType = type;
            return p;
        }
    }
}
