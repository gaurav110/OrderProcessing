using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestLibrary;

namespace UnitTestProject1
{
    [TestClass]
    public class Test1
    {
        #region Private Variables

        private readonly ICommission _commission;
        private readonly IEmail _email;

        #endregion

        #region Constructor

        public Test1()
        {
            _commission = new Commission();
            _email = new Email();
        }

        #endregion

        #region Test Methods

        /// <summary>
        /// Test method for payment of physical product
        /// </summary>
        [TestMethod]
        public void TestPhysicalProductPayment()
        {
            string response;
            decimal amount = 1000;
            float percent = 2.0F;


            IPhysicalProductPayment physicalProductPayment = new PhysicalProductPayment(_commission);
            response = physicalProductPayment.SavePaymentInformation(amount);
            Assert.AreEqual(string.Format(Constants.PaymentMessage, amount), response);

            response = physicalProductPayment.GenerateSlip();
            Assert.AreEqual(string.Format(Constants.SlipMessage, Constants.Shipping), response);

            response = physicalProductPayment.GenerateCommission(percent);
            Assert.AreEqual(string.Format(Constants.CommissionMessage, Constants.PhysicalProduct, percent), response);
        }

        /// <summary>
        /// Test method for payment of membership
        /// </summary>
        [TestMethod]
        public void TestMembershipPayment()
        {
            string response;
            decimal amount = 1000;
            string owner = "Owner Name";

            IMembershipPayment membershipPayment = new MembershipPayment(_email);
            response = membershipPayment.SavePaymentInformation(amount);
            Assert.AreEqual(string.Format(Constants.PaymentMessage, amount), response);

            response = membershipPayment.ActivateMembership();
            Assert.AreEqual(string.Format(Constants.MembershipActivationMessage), response);

            response = membershipPayment.SendEmail(owner);
            Assert.AreEqual(string.Format(Constants.EmailMessage, owner, Constants.Activation), response);
        }

        /// <summary>
        /// Test method for payment of upgrading membership
        /// </summary>
        [TestMethod]
        public void TestMembershipUpgradePayment()
        {
            string response;
            decimal amount = 1000;
            string owner = "Owner Name";

            IMembershipPayment membershipPayment = new MembershipPayment(_email);
            response = membershipPayment.SavePaymentInformation(amount);
            Assert.AreEqual(string.Format(Constants.PaymentMessage, amount), response);

            response = membershipPayment.UpgradeMembership();
            Assert.AreEqual(string.Format(Constants.MembershipUpgradationMessage), response);

            response = membershipPayment.SendEmail(owner);
            Assert.AreEqual(string.Format(Constants.EmailMessage, owner, Constants.Activation), response);
        }

        /// <summary>
        /// Test method for payment of book
        /// </summary>
        [TestMethod]
        public void TestBookPayment()
        {
            string response;
            decimal amount = 1000;
            float percent = 2.1F;


            IBookPayment bookPayment = new BookPayment(_commission);
            response = bookPayment.SavePaymentInformation(amount);
            Assert.AreEqual(string.Format(Constants.PaymentMessage, amount), response);

            response = bookPayment.GenerateSlip();
            Assert.AreEqual(string.Format(Constants.SlipMessage, Constants.Shipping), response);

            response = bookPayment.GenerateDuplicateSlip();
            Assert.AreEqual(string.Format(Constants.SlipMessage, Constants.RoyaltyDepartment), response);

            response = bookPayment.GenerateCommission(percent);
            Assert.AreEqual(string.Format(Constants.CommissionMessage, Constants.Book, percent), response);
        }

        /// <summary>
        /// Test method for payment of video with free video
        /// </summary>
        [TestMethod]
        public void TestVideoPaymentWithFreeVideo()
        {
            string response;
            decimal amount = 1000;

            string videoName = Constants.Video1;
            IVideoPayment videoPayment = new VideoPayment();
            response = videoPayment.SavePaymentInformation(amount);
            Assert.AreEqual(string.Format(Constants.PaymentMessage, amount), response);

            response = videoPayment.GenerateSlip(videoName);

            if (videoName.ToLower() == Constants.Video1.ToLower())
            {
                videoName += "," + Constants.Video2;
            }

            Assert.AreEqual(string.Format(Constants.SlipMessage, videoName), response);
        }

        /// <summary>
        /// Test method for payment of video without free video
        /// </summary>
        [TestMethod]
        public void TestVideoPaymentWithoutFreeVideo()
        {
            string response;
            decimal amount = 1000;

            string videoName = "Another Video Name";
            IVideoPayment videoPayment = new VideoPayment();
            response = videoPayment.SavePaymentInformation(amount);
            Assert.AreEqual(string.Format(Constants.PaymentMessage, amount), response);

            response = videoPayment.GenerateSlip(videoName);

            if (videoName.ToLower() == Constants.Video1.ToLower())
            {
                videoName += "," + Constants.Video2;
            }

            Assert.AreEqual(string.Format(Constants.SlipMessage, videoName), response);
        }

        #endregion
    }
}
