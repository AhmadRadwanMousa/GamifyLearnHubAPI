using Dapper;
using GamifyLearnHub.Core.Common;
using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Repositroy
{
    public class PaymentRepository:IPaymentRepository
    {
        private readonly IDbContext _dbContext;
        public PaymentRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreatePayment(Payment payment)
        {
            var p = new DynamicParameters();
            p.Add("Payment_Date",payment.Paymentdate,dbType:DbType.DateTime,direction:ParameterDirection.Input);
            p.Add("User_Id", payment.Userid,dbType:DbType.Int32,direction:ParameterDirection.Input);
            p.Add("Created_Id",dbType:DbType.Int32,direction:ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("Payment_Package.CreatePayment",p,commandType:CommandType.StoredProcedure);
            return p.Get<int>("Created_Id");
        }

        public async Task<int> DeletePayment(int paymentId)
        {
            var p = new DynamicParameters();
            p.Add("id", paymentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RowsAffected",  dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _dbContext.Connection.ExecuteAsync("Payment_Package.DeletePayment",p,commandType:CommandType.StoredProcedure);
            return p.Get<int>("RowsAffected");
        }

        public async Task<Payment> GetPaymentById(int paymentId)
        {
            var p = new DynamicParameters();
            p.Add("id", paymentId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result= await _dbContext.Connection.QueryAsync<Payment>("Payment_Package.GetPaymentById", p,commandType:CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> UpdatePayment(Payment payment)
        {
            var p = new DynamicParameters();
            p.Add("Payment_Date", payment.Paymentdate, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("User_Id", payment.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("Created_Id", dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("RowsAffected", dbType: DbType.Int32, direction: ParameterDirection.Output);
            await _dbContext.Connection.QueryAsync<Payment>("Payment_Package.UpdatePayment",p,commandType:CommandType.StoredProcedure);
            return p.Get<int>("RowsAffected");
        }
    }
}
