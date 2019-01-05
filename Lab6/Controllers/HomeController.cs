using Lab6.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab6.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseAccessI _dataRepository;

        public HomeController(DatabaseAccessI dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public ActionResult Index()
        {
            var username = System.Web.HttpContext.Current.User.Identity.GetUserName();
            ViewBag.TotalMoney = _dataRepository.GetAccountTotalCash(username);
            ViewBag.TotalPets = _dataRepository.GetAccountTotalPets(username);
            ViewBag.TotalUsers = _dataRepository.GetNumberofEmployees(username);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Super Battle Pets";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "We're NOT currently hiring OR accepting invitations to war";

            return View();
        }
    }
}