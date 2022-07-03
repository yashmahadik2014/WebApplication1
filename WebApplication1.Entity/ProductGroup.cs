using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Entity
{
    public class ProductGroup
    {
        public int ProductGroupId { get; set; }
        public string GroupDescription { get; set; }
        public int GroupCode { get; set; }
        public bool Active { get; set; }
    }
}
