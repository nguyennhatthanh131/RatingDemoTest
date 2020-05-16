using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RatingDemoTest.Controllers
{
    public class RatingDemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return PartialView("_Login");
        }

        public IActionResult Rating(string passCode, int serviceId = 1)
        {
            var isAbleToLogin = AuthenLogin(passCode);
            if (isAbleToLogin)
            {
                var pageToLoad = "_SanitationRating";

                switch (serviceId)
                {
                    case 1:
                        break;
                    case 2:
                        pageToLoad = "_SecurityRating";
                        break;
                    case 3:
                        pageToLoad = "_StudentCareRating";
                        break;
                    default:
                        break;
                }

                return PartialView(pageToLoad);
            }

            return Json(isAbleToLogin);

        }

        private bool AuthenLogin(string passCode)
        {
            if (passCode == null || passCode == string.Empty)                  return false;
            return passCode.Equals("123456789");
        }
    }
}