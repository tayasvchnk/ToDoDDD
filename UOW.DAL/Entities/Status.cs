using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoDDD.DAL.Entities
{
    public class Status : BaseEntity
    {
        public string StatusName { get; set; } = null!;
    }
}
