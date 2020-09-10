using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public class PhysicalProductPayment : Payment, IPhysicalProductPayment
    {
        #region Private Variables

        private readonly ICommission _commission;

        #endregion

        #region Constructor

        public PhysicalProductPayment(ICommission commission)
        {
            _commission = commission;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Generates commission for agent
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        public string GenerateCommission(float percent)
        {
            return _commission.GenerateCommission(Constants.PhysicalProduct, percent);
        }

        /// <summary>
        /// Generate slip for shipping
        /// </summary>
        /// <param name="slipName"></param>
        /// <returns></returns>
        public string GenerateSlip()
        {
            return string.Format(Constants.SlipMessage, Constants.Shipping);
        }

        #endregion
    }
}
