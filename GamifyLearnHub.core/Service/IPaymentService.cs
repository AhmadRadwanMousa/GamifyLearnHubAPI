﻿using GamifyLearnHub.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamifyLearnHub.Core.Service
{
    public interface IPaymentService
    {
        Task<Payment> GetPaymentById(int paymentId);
        Task<int> CreatePayment(Payment payment);
        Task<int> UpdatePayment(Payment payment);
        Task<int> DeletePayment(int paymentId);
    }
}