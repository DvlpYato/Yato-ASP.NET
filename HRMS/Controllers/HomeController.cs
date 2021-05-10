using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HRMS.Models;
using Microsoft.AspNetCore.Http;
using HRMS.Connect;
using System.Data;

namespace HRMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //private readonly IHttpContextAccessor _httpContextAccessor;
        //private ISession _session => _httpContextAccessor.HttpContext.Session;


        private ConnectDB conDB = new ConnectDB();
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            if (Check_login() == true)
            {
                return View();
            }else {
                return View("login");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        private bool Check_login() {
            bool result = false;
            if (HttpContext.Session.GetString("Login") != null) {
                if (HttpContext.Session.GetString("Login") == "1") {
                    result = true;
                }
            }
            return result;
        }

        [HttpPost]
        public IActionResult Login(String u_name, String u_pass) {
            //string text;
            DataTable dt = conDB.Getdata($"Select * from `lkm_user` where u_name = '{u_name}';");
            if (dt.Rows.Count > 0) {
                if (dt.Rows[0]["u_pass"].ToString() == EncodeString.MD5HashCyptography(u_pass)) {
                    HttpContext.Session.SetString("Login", "1");
                    HttpContext.Session.SetString("username", dt.Rows[0]["u_name"].ToString());
                    //ViewBag.username = HttpContext.Session.GetString("username");
                    //_session.SetString("username", dt.Rows[0]["u_pass"].ToString());
                    return View("Index");
                }

            }
            return View();
        }

        public IActionResult Logout() {
            HttpContext.Session.Clear();
            return View("login");
        }


        public IActionResult InputData()
        {

            return View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
