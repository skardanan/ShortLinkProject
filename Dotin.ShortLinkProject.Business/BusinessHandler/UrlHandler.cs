using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dotin.ShortLinkProject.Business.HashHelper;
using Dotin.ShortLinkProject.Common.DtoModel;
using Dotin.ShortLinkProject.DataAccess.DAL;
using Dotin.ShortLinkProject.DataAccess.Model;

namespace Dotin.ShortLinkProject.Business.BusinessHandler
{
    public class UrlHandler : BaseDomain
    {
        #region Variable
        public UrlModelDA DataAccess;
        #endregion
        #region Constructor
        public UrlHandler()
        {
            DataAccess = new UrlModelDA();
        }
        #endregion
        #region Method
        public string GenerateCode(UrlModelDto dto)
        {
            try
            {
                string code = HashHandler.Hash(dto.MainLink) + GetLastUrlAddressId().ToString().PadLeft(4, '0');
                UrlModel model = new UrlModel()
                {
                    MainLink = dto.MainLink,
                    ShortLink = code,
                    ViewCount = 0,
                    CreateIp=dto.CreateIp
                };
                if (DataAccess.Insert(model) <= 0)
                {
                    throw new Exception("خطا در سرور");
                }
                return code;
            }
            catch (Exception ex)
            {
                AddException(ex);
                return "";
            }
        }
        public UrlModelDto GetUrlAddress(string code)
        {
            try
            {
                UrlModel model = DataAccess.GetUrlByCode(code);
                if (model == null)
                    throw new Exception("داده یافت نشد");
                model.ViewCount++;
                if (DataAccess.Update(model))
                {
                    return model.ConvertToDto();
                }
                throw new Exception("خطا در بروزرسانی بازدیدها");
            }
            catch (Exception ex)
            {
                AddException(ex);
                return null;
            }

        }
        public int GetLastUrlAddressId()
        {
            UrlModel model = DataAccess.GetAll().LastOrDefault();
            return model != null ? model.Id : 0;
        }
        #endregion
    }
}
