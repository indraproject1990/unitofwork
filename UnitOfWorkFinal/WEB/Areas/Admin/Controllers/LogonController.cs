using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using BLL.Repository;
using BOL;

namespace WEB.Areas.Admin.Controllers
{
    public class LogonController : Controller
    {


        // GET: Admin/Logon
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AdminTB model)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    AdminBLL BLL = new AdminBLL();
                    AdminTB adminModel = new AdminTB { Username = model.Username, Password = model.Password };

                    AdminTB objadministrator = new AdminBLL { }.AdminLogin(adminModel);

                    if (objadministrator != null)
                    {
                        Session["AdminId"] = objadministrator.Id;
                        Session["UesrName"] = objadministrator.Username;
                        Session.Timeout = 60;
                        Session["Success"] = "Login Successfull!";
                        return RedirectToAction("Index", "MasterData");

                    }
                    else
                    {

                        Session["Error"] = "Invalid User name or Password.";
                        return View("Index", model);

                    }
                }
                return View("Index", model);

            }
            catch (Exception)
            {

                return View("Index", model);
                throw;
            }
        }
        public ActionResult Logout()
        {
            try
            {
                Session["AdminId"] = string.Empty;
                Session.Abandon();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
                throw;
            }
        }
    }
}