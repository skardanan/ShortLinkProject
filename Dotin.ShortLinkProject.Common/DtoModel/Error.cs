using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotin.ShortLinkProject.Common.DtoModel
{
    public class Error
    {
        #region Variable
        public string ErrorMessage { get; set; }
        #endregion
        #region Constructor
        public Error() { }
        public Error(string message)
        {
            ErrorMessage = message;
        }
        #endregion

    }
}
