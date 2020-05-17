using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RatingDemoTest.Domain;
using RatingDemoTest.ViewModel;

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

        public async Task<IActionResult> Rating(string passCode, int serviceId = 1)
        {
            var isAbleToLogin = await AuthenLogin(passCode, serviceId);

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
            
            return Json("Is Not able to login");
        }

        public async Task<bool> AuthenLogin(string passCode, int serviceId = 1)
        {
            var isAuthenLogin = false;
            if (passCode == null || passCode == string.Empty)
            {
                return isAuthenLogin;
            }

            if ((serviceId == 1 && passCode.Equals("12345")) ||
                (serviceId == 2 && passCode.Equals("23456")) ||
                (serviceId == 3 && passCode.Equals("34567")))
            {
                using (var context = new RatingDemoContext())
                {
                    var servicePassCode = serviceId == 1
                            ? "12345"
                            : serviceId == 2
                                ? "23456"
                                : "34567";

                    var loginService = Task.FromResult(context.LoginServices
                        .Where(x => x.LoginServiceId == serviceId &&
                                    x.LoginServicePassCode.Contains(servicePassCode))
                        .FirstOrDefault());

                    if (loginService.Result == null)
                    {
                        context.LoginServices.Add(new LoginServices
                        {
                            LoginServiceId = serviceId,
                            LoginServicePassCode = servicePassCode,
                            IsStillLogin = true
                        });
                        await context.SaveChangesAsync();                        
                    }
                    else
                    {
                        loginService.Result.IsStillLogin = true;
                        await context.SaveChangesAsync();
                    }

                    isAuthenLogin = true;
                }
            }

            return isAuthenLogin;
        }

        public async Task<IActionResult> LogoutFromService(string passCode, int serviceId = 1)
        {
            var isLogout = false;
            if (passCode == null || passCode == string.Empty)
            {
                return await Task.FromResult(Json(isLogout));
            }

            if ((serviceId == 1 && passCode.Equals("12345")) ||
                (serviceId == 2 && passCode.Equals("23456")) ||
                (serviceId == 3 && passCode.Equals("34567")))
            {
                using (var context = new RatingDemoContext())
                {
                    var servicePassCode = serviceId == 1
                            ? "12345"
                            : serviceId == 2
                                ? "23456"
                                : "34567";

                    var loginService = Task.FromResult(context.LoginServices
                        .Where(x => x.LoginServiceId == serviceId &&
                                    x.LoginServicePassCode.Contains(servicePassCode))
                        .FirstOrDefault());

                    if (loginService.Result == null)
                    {
                        isLogout = false;
                    }
                    else
                    {
                        loginService.Result.IsStillLogin = false;
                        await context.SaveChangesAsync();
                        isLogout = true;
                    }
                }
            }

            return await Task.FromResult(Json(isLogout));
        }

        public async Task<bool> RatingSubmit(int ratingPoint, string ratingComment, int serviceId = 1)
        {
            using (var context = new RatingDemoContext())
            {
                var ratingService = new ServicesRating
                {
                    RatedServiceId = serviceId,
                    RatedServicePoint = ratingPoint,
                    RatedServiceComment = ratingComment
                };

                context.ServicesRating.Add(ratingService);

                return await context.SaveChangesAsync() > 0;
            }
        }
    }
}