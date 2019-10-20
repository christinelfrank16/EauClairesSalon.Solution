using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class HomeController : Controller
    {
        private readonly HairSalonContext _db;

        public HomeController(HairSalonContext db)
        {
            _db = db;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost("/Search")]
        public ActionResult Search(string searchType, string searchInput)
        {
            if(String.IsNullOrEmpty(searchInput))
            {
                searchInput = "";
            }
            ViewBag.SearchType = searchType;
            ViewBag.searchInput = searchInput;
            List<Object> model;
            if(searchType == "stylist")
            {
                model = _db.Stylists.Where(stylist => stylist.FirstName.ToLower().Contains(searchInput.ToLower()) || stylist.LastName.ToLower().Contains(searchInput.ToLower()) || searchInput.ToLower().Contains(stylist.FirstName.ToLower()) || searchInput.ToLower().Contains(stylist.LastName.ToLower())).Select(s=>(Object) s).ToList();
            }
            else
            {
                model = _db.Clients.Where(client => client.FirstName.ToLower().Contains(searchInput.ToLower()) || client.LastName.ToLower().Contains(searchInput.ToLower()) || searchInput.ToLower().Contains(client.FirstName.ToLower()) || searchInput.ToLower().Contains(client.LastName.ToLower())).Select(s => (Object) s).ToList();
            }
            return View(model);
        }
    }
}