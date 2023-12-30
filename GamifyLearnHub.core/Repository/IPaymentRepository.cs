using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Repository
{
    public interface IPaymentRepository
    {
        Task<Payment> GetPaymentById(int paymentId);
        Task<int> CreatePayment(PaymentDetails paymentDetails);
        Task<int> UpdatePayment(Payment payment);   
        Task<int> DeletePayment(int paymentId);
    }
}
