using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public interface IPayment
    {
        string SavePaymentInformation(decimal amount);
    }

    public interface ISlip
    {
        string GenerateSlip(string slipName);
    }

    public interface IEmail
    {
        string SendEmail(string sender, string emailType);
    }

    public interface ICommission
    {
        string GenerateCommission(string type, float percent);
    }

    public interface IMembershipPayment : IPayment
    {
        string ActivateMembership();
        string UpgradeMembership();
        string SendEmail(string sender);
    }

    public interface IPhysicalProductPayment : IPayment
    {
        string GenerateCommission(float percent);
        string GenerateSlip();
    }

    public interface IBookPayment : IPhysicalProductPayment
    {
        string GenerateDuplicateSlip();
    }

    public interface IVideoPayment : IPayment, ISlip
    {

    }
}
