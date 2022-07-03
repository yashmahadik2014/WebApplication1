using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.DataAccess;
using WebApplication1.Entity;

namespace WebApplication1.Bussiness
{
    public class AgreementBal
    {
        AgreementDal objDl = new AgreementDal();
        public int InsertAgreementDetails(Agreement assets)
        {
            try
            {
                return objDl.InsertAgreementDetails(assets);
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
               
                return objDl.UpdateAgreementDetails(assets);

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
                return objDl.GetAgreementDetails(UserID);
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
                return objDl.GetAgreementDetailsByID(ID);
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
                return objDl.DeleteAgreementDetails(ID);

            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
