using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dotin.ShortLinkProject.Common.DtoModel;
namespace Dotin.ShortLinkProject.DataAccess.Model
{
   public class UrlModel : BaseModel
    {
        #region Variable
        public string MainLink { get; set; }
        public string ShortLink { get; set; }
        public Int64 ViewCount { get; set; }
        public string CreateIp { get; set; }
        #endregion
        #region HelperMethod
        public UrlModelDto ConvertToDto()
        {
           return new UrlModelDto()
            {
                MainLink = this.MainLink,
                ShortLink = this.ShortLink,
                ViewCount = this.ViewCount,
                CreateIp=this.CreateIp
            };
        }
        #endregion
    }
}
