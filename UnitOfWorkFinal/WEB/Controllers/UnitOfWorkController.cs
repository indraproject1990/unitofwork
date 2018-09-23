using BLL.Repository;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WEB.Controllers
{
    [RoutePrefix("api")]
    public class UnitOfWorkController : ApiController
    {
        ProductBLL BLL = new ProductBLL();

        [Route("ProductList")]
        [HttpPost]
        public HttpResponseMessage ActiveProductList()
        {
            Dictionary<string, object> Value = new Dictionary<string, object>();
            HttpResponseMessage response = null;
            try
            {
                var ProductList = BLL.ActiveProductList();

                if (ProductList != null)
                {
                    Value["result"] = "TRUE";
                    Value["ProductList"] = ProductList;
                }
                else
                {
                    Value["result"] = "FALSE";
                }
            }
            catch (Exception pm)
            {
                Value["result"] = "error in server/states";
            }
            response = Request.CreateResponse(HttpStatusCode.OK, Value, "application/json");
            return response;
        }

        [Route("ProductUpdate")]
        [HttpPost]
        public HttpResponseMessage ProductUpdate()
        {

            TimeZoneInfo IND_ZONE = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime Date = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, IND_ZONE);
            Dictionary<string, object> Value = new Dictionary<string, object>();
            HttpResponseMessage response = null;
            try
            {
                long Id = Convert.ToInt64(System.Web.HttpContext.Current.Request.Form["Id"]);
                string Name = System.Web.HttpContext.Current.Request.Form["Name"];
                long Price = Convert.ToInt64(System.Web.HttpContext.Current.Request.Form["Price"]);
                bool InStock = Convert.ToBoolean(System.Web.HttpContext.Current.Request.Form["InStock"]);

                //// Store User image
                //var Image = System.Web.HttpContext.Current.Request.Files["Image"];
                //string strMedImg = "";
                //string path = "";
                //Random rnd = new Random();
                //if (Image != null)
                //{
                //    strMedImg = "UserImg_" + rnd.Next(100, 100000000) + "." + Image.FileName.Split('.')[1].ToString();
                //    path = System.Web.HttpContext.Current.Server.MapPath("~/Areas/Admin/IMAGE/" + strMedImg);
                //    Image.SaveAs(path);
                //}

                Product obj = BLL.GetProductById(Id);
                if (obj != null)
                {
                    obj.Id = Id;
                    obj.Name = Name;
                    obj.Price = Price;
                    obj.InStock = InStock;

                    BLL.AddEditProduct(obj);
                }

                long id = obj.Id;
                if (id != 0)
                {
                    Value["result"] = "TRUE";
                    Value["id"] = id;
                    Value["message"] = "Update Successfully!";
                }
                else
                {
                    Value["result"] = "FALSE";
                }
            }
            catch (Exception pm)
            {
                Value["result"] = "error in server/states";
            }
            response = Request.CreateResponse(HttpStatusCode.OK, Value, "application/json");
            return response;
        }
    }
}
