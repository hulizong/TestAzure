using System;
using System.Collections.Generic;
using System.Text;

namespace Model.AD.Sys
{
   public  class Sys_Role
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        public int PowerSetId { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
