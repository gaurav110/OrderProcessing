using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public class Payment : IPayment
    {
        public string SavePaymentInformation(decimal amount)
        {
            return string.Format(Constants.PaymentMessage, amount);
        }
    }
}
