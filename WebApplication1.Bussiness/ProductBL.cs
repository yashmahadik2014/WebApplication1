using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.DataAccess;

namespace WebApplication1.Bussiness
{
    public class ProductBL
    {
        ProductDL objDL = new ProductDL();

        public List<SelectListItem> GetProduct(int ProductGroupId)
        {
            try
            {
                List<SelectListItem> ProductList = new List<SelectListItem>();
                ProductList = objDL.GetProduct(ProductGroupId);
                return ProductList;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
