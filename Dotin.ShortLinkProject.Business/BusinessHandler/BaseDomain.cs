using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dotin.ShortLinkProject.Common.DtoModel;

namespace Dotin.ShortLinkProject.Business.BusinessHandler
{
    public class BaseDomain
    {
        #region Variables
        public List<Exception> ExceptionList { get; set; }
        public List<Error> ErrorList { get; set; }
        public bool HasError
        {
            get
            {
                return ErrorList != null && ErrorList.Count > 0;
            }
        }
        public bool HasException
        {
            get
            {
                return ExceptionList != null && ExceptionList.Count > 0;
            }
        }
        #endregion
        #region Method
        public void AddException(Exception ex)
        {
            if (ExceptionList == null) ExceptionList = new List<Exception>();
            ExceptionList.Add(ex);
        }

        public void AddException(string msg)
        {
            if (ErrorList == null) ErrorList = new List<Error>();
            ErrorList.Add(new Error(msg));
        }
        #endregion
    }
}
