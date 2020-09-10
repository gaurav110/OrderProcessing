using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public class Email : IEmail
    {
        public string SendEmail(string sender, string emailType)
        {
            return string.Format(Constants.EmailMessage, sender, emailType);
        }
    }
}
