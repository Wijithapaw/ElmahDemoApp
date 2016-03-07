using ElmahDemoApp.Areas.AdminArea.Models;
using ElmahDemoApp.Data;
using ElmahDemoApp.Domain;
using ElmahDemoApp.Domain.Entities;
using ElmahDemoApp.Domain.Services;
using ElmahDemoApp.Services;
using ElmahDemoApp.Utills;
using Microsoft.AspNet.Identity.Owin;
using MvcSiteMapProvider;
using MvcSiteMapProvider.Web.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElmahDemoApp.Areas.AdminArea.Controllers
{
    public class AdminController : _BaseController
    {
        private readonly IAdminService AdminService;

        public AdminController(IAdminService adminService)
        {
            this.AdminService = adminService;
        }

        public ActionResult Index()
        {
            var admins = AdminService.GetAll();
            return View(admins);
        }

        /* Test method: site map nodes with url parameters
        [SiteMapTitle("FirstName", Target = AttributeTarget.ParentNode)]
        public ActionResult MoreDetails(string adminId)
        {
            SiteMapHelper.SetParentRouteValues("id", adminId);

            var admin = AdminService.Get(adminId);
            return View(admin);
        }*/
    }
}
