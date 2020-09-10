using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public class MembershipPayment : Payment, IMembershipPayment
    {
        #region Private Variables

        private readonly IEmail _email;

        #endregion

        #region Constructor

        public MembershipPayment(IEmail email)
        {
            _email = email;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Activate membership
        /// </summary>
        /// <returns></returns>
        public string ActivateMembership()
        {
            return string.Format(Constants.MembershipActivationMessage);
        }

        /// <summary>
        /// Upgrade membership
        /// </summary>
        /// <returns></returns>
        public string UpgradeMembership()
        {
            return string.Format(Constants.MembershipUpgradationMessage);
        }

        /// <summary>
        /// Send email to owner
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public string SendEmail(string sender)
        {
            return _email.SendEmail(sender, Constants.Activation);
        }

        #endregion 
    }
}
