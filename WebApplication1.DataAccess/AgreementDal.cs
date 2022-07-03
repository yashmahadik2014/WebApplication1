using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Comman;
using WebApplication1.Entity;

namespace WebApplication1.DataAccess
{
    public class AgreementDal
    {

        public int InsertAgreementDetails(Agreement assets)
        {
            try
            {
                SqlCommand command = DBConnection.CreateCommand();
                command.CommandText = "Usp_Create_Data_Agreement";

                command.Parameters.AddWithValue("@Id", assets.Id);
                command.Parameters.AddWithValue("@UserId", assets.UserId);
                command.Parameters.AddWithValue("@ProductGroupId", assets.ProductGroupId);
                command.Parameters.AddWithValue("@ProductId", assets.ProductId);
                command.Parameters.AddWithValue("@EffectiveDate", assets.EffectiveDate);
                command.Parameters.AddWithValue("@Expiration", assets.Expiration);
                command.Parameters.AddWithValue("@NewPrice", assets.NewPrice);
                command.Parameters.AddWithValue("@iIdentity", 0);
                command.Parameters["@iIdentity"].Direction = ParameterDirection.Output;

                return DBConnection.InsertCommand(command);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool UpdateAgreementDetails(Agreement assets)
        {
            try
            {
                SqlCommand command = DBConnection.CreateCommand();
                command.CommandText = "Usp_Update_Data_Agreement";

                command.Parameters.AddWithValue("@Id", assets.Id);
                command.Parameters.AddWithValue("@UserId", assets.UserId);
                command.Parameters.AddWithValue("@ProductGroupId", assets.ProductGroupId);
                command.Parameters.AddWithValue("@ProductId", assets.ProductId);
                command.Parameters.AddWithValue("@EffectiveDate", assets.EffectiveDate);
                command.Parameters.AddWithValue("@Expiration", assets.Expiration);
                command.Parameters.AddWithValue("@NewPrice", assets.NewPrice);

                DBConnection.ExecuteCommand(command);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public List<Agreement> GetAgreementDetails(string UserID)
        {
            try
            {
                SqlCommand command = DBConnection.CreateCommand();
                command.CommandText = "Usp_Get_Data_Agreement";
                command.Parameters.AddWithValue("@UserId", UserID);

                DataTable dt = DBConnection.ExecuteSelectCommand(command);
                List<Agreement> Agreementlist = new List<Agreement>();
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        Agreement AgreementDetails = new Agreement();
                        AgreementDetails.Id = Convert.ToInt32(dr["Id"]);
                        AgreementDetails.ProductId = Convert.ToInt32(dr["ProductId"]);
                        AgreementDetails.ProductGroupId = Convert.ToInt32(dr["ProductGroupId"]);
                        AgreementDetails.UserId = Convert.ToString(dr["UserId"]);
                        AgreementDetails.EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]);
                        AgreementDetails.Expiration = Convert.ToDateTime(dr["Expiration"]);
                        AgreementDetails.NewPrice = Convert.ToDecimal(dr["NewPrice"]);
                        AgreementDetails.ProductDescription = Convert.ToString(dr["ProductDescription"]);
                        AgreementDetails.GroupDescription = Convert.ToString(dr["GroupDescription"]);
                        Agreementlist.Add(AgreementDetails);
                    }
                }
                return Agreementlist;
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public Agreement GetAgreementDetailsByID(int ID)
        {
            try
            {
                SqlCommand command = DBConnection.CreateCommand();

                command.CommandText = "Usp_Get_Data_Agreement_Id";
                command.Parameters.AddWithValue("@Id", ID);

                DataTable dt = DBConnection.ExecuteSelectCommand(command);
                Agreement AgreementDetails = new Agreement();
                foreach (DataRow dr in dt.Rows)
                {

                    AgreementDetails.Id = Convert.ToInt32(dr["Id"]);
                    AgreementDetails.ProductId = Convert.ToInt32(dr["ProductId"]);
                    AgreementDetails.ProductGroupId = Convert.ToInt32(dr["ProductGroupId"]);
                    AgreementDetails.UserId = Convert.ToString(dr["UserId"]);
                    AgreementDetails.EffectiveDate = Convert.ToDateTime(dr["EffectiveDate"]);
                    AgreementDetails.Expiration = Convert.ToDateTime(dr["Expiration"]);
                    AgreementDetails.NewPrice = Convert.ToDecimal(dr["NewPrice"]);
                }

                return AgreementDetails;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool DeleteAgreementDetails(int ID)
        {
            try
            {
                SqlCommand command = DBConnection.CreateCommand();
                command.CommandText = "Usp_Delete_Data_Agreement_Id";

                command.Parameters.AddWithValue("@Id", ID);

                DBConnection.ExecuteCommand(command);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
