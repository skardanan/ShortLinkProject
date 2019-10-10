using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dotin.ShortLinkProject.Common.DtoModel;
using Dotin.ShortLinkProject.DataAccess.DAL;
using Dotin.ShortLinkProject.DataAccess.Model;

namespace Dotin.ShortLinkProject.DataAccess.HelperClass
{
    public class ErrorHandlingHelper
    {
        #region Variables
        #endregion

        #region Constructor
        public ErrorHandlingHelper()
        {

        }
        #endregion

        #region Methods


        public void SetError(Exception err)
        {
            LogError("Error Message : " + err.Message + "\r\nInner Exception Message : " + err?.InnerException?.Message);

        }

        private void LogError(string exMsg)
        {
            try
            {

                #region *** Get Class Name & Method Name ***
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
                string methodName = "", className = "";

                int indxStack = 1;

                while (methodName == "" || methodName == "SetError")
                {
                    methodName = st.GetFrame(indxStack).GetMethod().Name;
                    className = st.GetFrame(indxStack).GetMethod().DeclaringType.FullName;
                    indxStack++;
                }
                exMsg += "\r\n\r\n Class : " + className +
                        "\r\n\r\n Method : " + methodName;

                #endregion

                Log log = new Log();
                LogDA logDA = new LogDA();
                log.ExceptionMessage = exMsg;
                logDA.Insert(log);
            }
            catch (System.Exception exc)
            {
                AddFileException(exc);
            }
        }

        #endregion

        #region Helper Methods

        private void AddFileException(Exception ex)
        {
            try
            {
                string path = "";
                if (!System.IO.File.Exists(path))
                {
                    var f = File.Create(path);
                    f.Close();
                }

                string exMsg = ex.Message;
                if (ex.InnerException != null && ex.InnerException.Message != null)
                {
                    exMsg += " - Inner : " + ex.InnerException.Message;
                    if (ex.InnerException.InnerException != null && ex.InnerException.InnerException.Message != null)
                        exMsg += " - Inner : " + ex.InnerException.InnerException.Message;
                }

                using (StreamWriter sw = new StreamWriter(path, append: true, encoding: Encoding.UTF8))
                {
                    sw.WriteLine($"[{DateTime.Now} {DateTime.Now.ToShortTimeString()}] : {exMsg}");
                }

            }
            catch (Exception e)
            {

                throw;
            }
        }

        #endregion
    }
}
