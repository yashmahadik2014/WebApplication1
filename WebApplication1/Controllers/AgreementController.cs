using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Bussiness;
using WebApplication1.Entity;

namespace WebApplication1.Controllers
{
    public class AgreementController : Controller
    {

        AgreementBal objBl = new AgreementBal();
        ProductBL pobjBl = new ProductBL();
        ProductGroupBL pgobjBl = new ProductGroupBL();

        // GET: Agreement
        public ActionResult Index()
        {
            List<Agreement> lobj = new List<Agreement>();
            string userId = User.Identity.GetUserId();
            if (!string.IsNullOrEmpty(userId))
            {
                lobj = objBl.GetAgreementDetails(userId);
            }
            return View(lobj);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Agreement obj = new Agreement();
            obj.ProductList = new List<SelectListItem>();
            obj.ProductList.Add(new SelectListItem()
            {
                Text = "Select Product",
                Value = ""
            });
            obj.ProductGroupList = new List<SelectListItem>();
            obj.ProductGroupList = pgobjBl.GetProductGroup();
            return View(obj);
        }

        [HttpPost]
        public ActionResult Create(Agreement obj)
        {
            obj.ProductGroupList = new List<SelectListItem>();
            try
            {
                if (ModelState.IsValid)
                {
                    obj.UserId = User.Identity.GetUserId();
                    var res = 0;
                    if (obj.Id == 0)
                    {
                        res = objBl.InsertAgreementDetails(obj);
                    }
                    else
                    {
                        var a = objBl.UpdateAgreementDetails(obj);
                        if(a)
                        {
                            res = 1;
                        }
                    }
                    if(res!=0)
                    {
                        if (obj.Id == 0)
                            TempData["SuccessMessage"] = "Agreement Created Successfully";
                        else
                            TempData["SuccessMessage"] = "Agreement Updated Successfully";
                        return RedirectToAction("Index", "Agreement");
                    }
                }
                obj.ProductGroupList = pgobjBl.GetProductGroup();
                obj.ProductList = new List<SelectListItem>();
                if (obj.ProductGroupId != 0)
                {
                    obj.ProductList = pobjBl.GetProduct(obj.ProductGroupId);
                }
                else
                {
                    obj.ProductList.Add(new SelectListItem()
                    {
                        Text = "Select Product",
                        Value = ""
                    });
                }
                return View(obj);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                obj.ProductGroupList = pgobjBl.GetProductGroup();
                obj.ProductList = new List<SelectListItem>();
                if (obj.ProductGroupId != 0)
                {
                    obj.ProductList = pobjBl.GetProduct(obj.ProductGroupId);
                }
                else
                {
                    obj.ProductList.Add(new SelectListItem()
                    {
                        Text = "Select Product",
                        Value = ""
                    });
                }
                return View(obj);
            }
        }

        public JsonResult GetProduct(int ProductGroupId)
        {
            List<SelectListItem> ProductList = pobjBl.GetProduct(ProductGroupId);
            return Json(new { ok = true, Constituency = ProductList, JsonRequestBehavior.AllowGet });
        }

        public ActionResult Edit(int Id)
        {
            Agreement obj = new Agreement();
            obj = objBl.GetAgreementDetailsByID(Id);

            obj.ProductGroupList = new List<SelectListItem>();
            obj.ProductGroupList = pgobjBl.GetProductGroup();
            obj.ProductList = new List<SelectListItem>();
            if (obj.ProductGroupId != 0)
            {
                obj.ProductList = pobjBl.GetProduct(obj.ProductGroupId);
            }
            else
            {
                obj.ProductList.Add(new SelectListItem()
                {
                    Text = "Select Product",
                    Value = ""
                });
            }

            return View("Create", obj);
        }

        public ActionResult Delete(int Id)
        {
            var res = objBl.DeleteAgreementDetails(Id);
            TempData["SuccessMessage"] = "Agreement Deleted Successfully";
            return RedirectToAction("Index");
        }

    }
}