using GamifyLearnHub.Core.Data;
using GamifyLearnHub.Core.DTO;
using GamifyLearnHub.Core.Repository;
using GamifyLearnHub.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Infra.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository; 
        }
        public async Task<int> CreatePayment(PaymentDetails paymentDetails)
        {
           return await _paymentRepository.CreatePayment(paymentDetails);  
        }

        public async Task<int> DeletePayment(int paymentId)
        {
           return await _paymentRepository.DeletePayment(paymentId);    
        }

        public async Task<Payment> GetPaymentById(int paymentId)
        {
            return await _paymentRepository.GetPaymentById(paymentId);  
        }

        public async Task<int> UpdatePayment(Payment payment)
        {
           return await _paymentRepository.UpdatePayment(payment);  
        }
    }
}
