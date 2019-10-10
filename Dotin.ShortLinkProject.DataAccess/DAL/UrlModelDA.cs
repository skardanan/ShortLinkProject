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
    public class UrlModelDA : BaseDA
    {

        #region Variables
        DatabaseContext context;
        #endregion

        #region Constructors
        public UrlModelDA() : base()
        {
            context = new DatabaseContext();
        }
        #endregion

        #region Methods
        public int Insert(UrlModel data)
        {
            try
            {
                data.CreateTime = DateTime.Now;

                context.UrlAddress.Add(data);

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
        public bool Update(UrlModel data)
        {
            try
            {
                var prop = context.Entry(data);
                prop.CurrentValues.SetValues(data);
                prop.State = System.Data.Entity.EntityState.Modified;
                if (context.SaveChanges() > 0)
                    return true;
                return false;
            }
            catch (Exception ex)
            {
                AddException(ex);
                return false;
            }
        }


        public List<UrlModel> GetAll()
        {
            try
            {
                return context.UrlAddress.AsNoTracking().ToList();
            }
            catch (Exception ex)
            {
                AddException(ex);
                return new List<UrlModel>();
            }
        }

        public UrlModel GetUrlByCode(string code)
        {
            try
            {
                return context.UrlAddress.Where(t => t.ShortLink == code).FirstOrDefault();
            }
            catch (Exception ex)
            {
                AddException(ex);
                return null;
            }
        }
        #endregion
    }
}
