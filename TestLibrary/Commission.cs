using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public class Commission : ICommission
    {
        public string GenerateCommission(string type, float percent)
        {
            return string.Format(Constants.CommissionMessage, type, percent);
        }
    }
}
