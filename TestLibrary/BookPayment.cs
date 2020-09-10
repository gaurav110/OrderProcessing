using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public class BookPayment : PhysicalProductPayment, IBookPayment
    {
        #region Private Variables

        private readonly ICommission _commission;

        #endregion

        #region Constructor

        public BookPayment(ICommission commission) : base(commission)
        {
            _commission = commission;
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Generate commission for book
        /// </summary>
        /// <param name="percent"></param>
        /// <returns></returns>
        public new string GenerateCommission(float percent)
        {
            return _commission.GenerateCommission(Constants.Book, percent);
        }

        /// <summary>
        /// Generate duplicate slip for royalty department
        /// </summary>
        /// <returns></returns>
        public string GenerateDuplicateSlip()
        {
            return string.Format(Constants.SlipMessage, Constants.RoyaltyDepartment);
        }

        #endregion
    }
}
