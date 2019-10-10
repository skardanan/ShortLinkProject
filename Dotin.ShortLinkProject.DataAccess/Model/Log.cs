using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotin.ShortLinkProject.DataAccess.Model
{
   public class Log : BaseModel
    {
        #region Variable
        public string ExceptionMessage { get; set; }
        public string IP { get; set; }
        #endregion
    }
}
