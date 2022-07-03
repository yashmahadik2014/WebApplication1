using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.DataAccess;

namespace WebApplication1.Bussiness
{
    public class ProductGroupBL
    {
        ProductGroupDL objDL = new ProductGroupDL();
        public List<SelectListItem> GetProductGroup()
        {
            try
            {
                List<SelectListItem> ProductList = new List<SelectListItem>();
                ProductList = objDL.GetProductGroup();
                return ProductList;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
