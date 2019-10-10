using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dotin.ShortLinkProject.Common.DtoModel;

namespace Dotin.ShortLinkProject.Business.CacheHandler
{
    public class CacheHelper
    {
        public Dictionary<string, UrlModelDto> Cache = new Dictionary<string, UrlModelDto>();
        public void AddModel(string key, UrlModelDto model)
        {
            if (!HasKey(key))
                Cache[key] = model;
        }
        public UrlModelDto GetModel(string key)
        {
            if (HasKey(key))
                return Cache[key];
            return null;
        }
        public bool HasKey(string key)
        {
            if (Cache.ContainsKey(key)) return true;
            return false;

        }

    }
}
