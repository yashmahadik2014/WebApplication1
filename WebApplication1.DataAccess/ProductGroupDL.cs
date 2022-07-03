using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using WebApplication1.Comman;

namespace WebApplication1.DataAccess
{
    public class ProductGroupDL
    {
        public List<SelectListItem> GetProductGroup()
        {
            try
            {
                SqlCommand command = DBConnection.CreateCommand();
                command.CommandText = "Usp_Get_ProductGroup";

                DataTable dt = DBConnection.ExecuteSelectCommand(command);
                List<SelectListItem> ProductList = new List<SelectListItem>();
                ProductList.Add(new SelectListItem()
                {
                    Text = "Select Product Group",
                    Value = ""
                });
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ProductList.Add(new SelectListItem()
                        {
                            Text = dr["GroupDescription"].ToString(),
                            Value = dr["ProductGroupId"].ToString()
                        });
                    }
                }
                return ProductList;
            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
