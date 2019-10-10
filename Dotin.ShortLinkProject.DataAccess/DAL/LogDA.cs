using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dotin.ShortLinkProject.Common.DtoModel;
using Dotin.ShortLinkProject.DataAccess.Context;
using Dotin.ShortLinkProject.DataAccess.Model;

namespace Dotin.ShortLinkProject.DataAccess.DAL
{
    public class LogDA : BaseDA
    {

        #region Variables
        DatabaseContext context;
        #endregion

        #region Constructors
        public LogDA() : base()
        {
            context = new DatabaseContext();
        }
        #endregion

        #region Methods
        public int Insert(Log data)
        {
            try
            {
                data.CreateTime = DateTime.Now;

                context.Log.Add(data);

                if (context.SaveChanges() > 0)
                    return data.Id;
                return 0;
            }
            catch (Exception ex)
            {
                AddException(ex);
                return -1;
            }
        }
        public List<Log> GetAllLogs()
        {
            try
            {
                return context.Log.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                AddException(ex);
                return new List<Log>();
            }
        }
        #endregion
    }
}
