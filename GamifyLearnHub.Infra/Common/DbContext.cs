using GamifyLearnHub.Core.Common;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Common
{
    public class DbContext : IDbContext
    {
        private readonly  DbConnection _connection;  
        private readonly IConfiguration _configuration;
        private bool _disposed = false;
        public DbContext(IConfiguration configuration)
        {
            _configuration=configuration;
            _connection = new OracleConnection(_configuration.GetConnectionString("DbConnectionString"));
            _connection.Open();
        }

        public DbConnection Connection
        {
            get
            {
              
                if (_connection.State!=ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection; 
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_connection != null)
                    {
                        _connection.Close();
                        _connection.Dispose();
                    }
                }
                _disposed = true;
            }
        }
        ~DbContext()
        {
            Dispose(false);
        }
    }
}
