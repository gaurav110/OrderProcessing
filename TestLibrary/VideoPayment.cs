using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public class VideoPayment : Payment, IVideoPayment
    {
        #region Public Methods

        public string GenerateSlip(string slipName)
        {
            if(slipName.ToLower() == Constants.Video1.ToLower())
            {
                slipName += "," + Constants.Video2;
            }
            return string.Format(Constants.SlipMessage, slipName);
        }

        #endregion
    }
}
