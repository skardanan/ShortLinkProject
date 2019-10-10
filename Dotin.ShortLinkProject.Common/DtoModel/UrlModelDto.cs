using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotin.ShortLinkProject.Common.DtoModel
{
    public class UrlModelDto
    {
        #region Variables
        public string MainLink { get; set; }
        public string ShortLink { get; set; }
        public Int64 ViewCount { get; set; }
        public string CreateIp { get; set; }
        #endregion

    }
}
