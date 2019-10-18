using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {
        private readonly HairSalonContext _db;

        public ClientsController(HairSalonContext db)
        {
            _db = db;
        }

        [HttpGet("/Stylists/{stylistId}/Clients/Create", Name="Create")]
        public ActionResult Create(int stylistId)
        {
            ViewBag.StylistId = stylistId;
            return View();
        }

        [HttpPost("/Stylists/{stylistId}/Clients/Create", Name="Create")]
        public ActionResult Create(Client client, int stylistId)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();
            return RedirectToRoute("Stylists", new { controller="Stylists", action="Details", id = stylistId });
        }

    }
}