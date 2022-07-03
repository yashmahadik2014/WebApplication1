using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public int ProductGroupId { get; set; }
        public string ProductDescription { get; set; }
        public int ProductNumber { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
    }
}
