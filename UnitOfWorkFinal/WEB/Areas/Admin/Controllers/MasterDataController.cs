using BLL.Repository;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WEB.Areas.Admin.Controllers
{

    public class MasterDataController : Controller
    {
        
        TimeZoneInfo IND_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        

        //// GET: Admin/MasterData
        //public ActionResult Index()
        //{

        //    //DashboardModel model = new DashboardModel();
        //    //model.TotalUser = objdb.Users.Where(x => x.IsActive == true).Count();
        //    //model.TotalProduct = objdb.Products.Where(x => x.IsActive == true).Count();
        //    //model.TotalVehicle = objdb.Vehicles.Where(x => x.IsActive == true).Count();
        //    //return View(model);

        //    return View();
        //}

        
        public ActionResult Index()
        {
            Product model = new Product();
            var modelList = new ProductBLL { }.GetAllProduct();
            return View(modelList);
        }

        
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = new ProductBLL { }.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,InStock")] Product product)
        {
            if (ModelState.IsValid)
            {
                Product _product = new Product
                {
                    Id = 0,
                    Name = product.Name,
                    Price = product.Price
                };

                new ProductBLL { }.AddEditProduct(_product);
                return RedirectToAction("Index");
            }

            return View(product);
        }


        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = new ProductBLL { }.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,InStock")] Product product)
        {
            if (ModelState.IsValid)
            {
                new ProductBLL { }.AddEditProduct(product);

                return RedirectToAction("Index");
            }
            return View(product);
        }


        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = new ProductBLL { }.GetProductById(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            new ProductBLL { }.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        public ActionResult ChangeProductStatus(long? id)
        {
            bool Result = false;
            bool ChangeStatus = new ProductBLL { }.ChangeProductStatus(id);
            if (ChangeStatus)
            {
                Result = true;
            }
            return RedirectToAction("Index");
        }
        

        #region Product
        public ActionResult ProductList()
        {
            Product model = new Product();
            var modelList = new ProductBLL { }.ActiveProductList().ToList();
            ViewBag.modelList = modelList;
            return View(modelList);
        }
        public ActionResult AddEditProduct(int id = 0)
        {
            @ViewBag.Page = "P1";
            Product model = new Product();
            if (id != 0)
            {
                @ViewBag.Page = "P2";
                model = new ProductBLL { }.GetProductById(id);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult AddEditProduct(Product model, List<HttpPostedFileBase> file)
        {
            try
            {
                int AdminId = Convert.ToInt32(Session["AdminId"]);
                DateTime dt = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, IND_ZONE);
                string strFileName = "";
                string path = "";
                Random rnd = new Random();

                long res = 0;

                foreach (var item in file)
                {
                    if (item != null)
                    {
                        strFileName = "ProductImg_" + rnd.Next(100, 100000000) + "." + item.FileName.Split('.')[1].ToString();
                        path = Server.MapPath("~/Areas/Admin/IMAGE/" + strFileName);
                        item.SaveAs(path);
                    }
                }
                res = new ProductBLL { }.AddEditProduct(new Product
                {
                    Id = model.Id,
                    Name = model.Name,
                    Price = model.Price,
                    InStock = model.InStock
                });


                if (res != 0)
                {
                    if (model.Id == 0)
                    { Session["Success"] = "Product Successfully!"; }
                    else { Session["Success"] = "Product Edit Successfully!"; }
                    return RedirectToAction("ProductList");
                }
                Session["Error"] = "An Error has occured";
                return View(model);
            }
            catch (Exception)
            {
                Session["Error"] = "An Error has occured";
                return View(model);
                throw;
            }



        }
        public ActionResult DeleteProduct(long id = 0)
        {
            try
            {
                new ProductBLL { }.DeleteProduct(id);
                Session["Success"] = "Product Delete Successfully!";
                return RedirectToAction("ProductList");
            }
            catch (Exception)
            {
                return null;
                throw;
            }
        }


        #endregion



        #region JsonResult
        // check the Json Result in the browser using debugger mode at MasterData(Index) page
        public JsonResult GetProductList()
        {
            try
            {
                var productList = new ProductBLL { }.ActiveProductList();
                return Json(productList);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion
    }
}