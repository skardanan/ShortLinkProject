using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dotin.ShortLinkProject.Common.DtoModel;
namespace Dotin.ShortLinkProject.DataAccess.DAL
{
    public class BaseDA
    {
        #region Variables
        private HelperClass.ErrorHandlingHelper errorHandlingHelper;
        private List<Exception> ExceptionList { get; set; }
        public bool HasException
        {
            get
            {
                return (this.ExceptionList != null && ExceptionList.Count > 0);
            }
        }
        #endregion

        #region Constructor
        public BaseDA()
        {
            ResetProperties();
            errorHandlingHelper = new HelperClass.ErrorHandlingHelper();

        }
        
        #endregion

        #region Methods
      
        public List<Exception> GetExceptionList()
        {
            try
            {
                return this.ExceptionList;
            }
            catch (Exception ex)
            {

                return ExceptionList;
            }

        }
        public void AddException(Exception exception)
        {
            try
            {
                ExceptionList.Add(exception);
                errorHandlingHelper.SetError(exception);

            }
            catch (Exception ex)
            {

            }

        }

        #endregion

        #region HelperMethods
        public virtual void ResetProperties()
        {
            ExceptionList = new List<Exception>();
            errorHandlingHelper = null;
        }
        #endregion
    }
}
