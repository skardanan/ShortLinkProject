using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dotin.ShortLinkProject.DataAccess.Model
{
   public class BaseModel
    {
        #region Variable
        [Key]
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        #endregion
    }
}
