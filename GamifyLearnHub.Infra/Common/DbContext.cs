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
        private  DbConnection _connection;  
        private readonly IConfiguration _configuration;
        public DbContext(IConfiguration configuration)
        {
            _configuration=configuration;
        }

        public DbConnection Connection
        {
            get
            {
                if (_connection == null) {
                    _connection = new OracleConnection(_configuration.GetConnectionString("DbConnectionString"));
                    _connection.Open();
                }
                else if (_connection.State!=ConnectionState.Open)
                {
                    _connection.Open();
                }
                return _connection; 
            }
        }
    }
}
