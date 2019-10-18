using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using HairSalon.Models;
using System;

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
        public ActionResult Create(int stylistId, IFormCollection collection)
        {
            try{
                Client client = new Client();
                
                client.FirstName=collection["FirstName"];
                client.LastName = collection["LastName"];
                client.StartDate = DateTime.Parse(collection["StartDate"]);
                client.PreferredAppointmentWeekDay = Int32.Parse(collection["PreferredAppointmentWeekDay"]);
                client.PreferredAppointmentTime = collection["PreferredAppointmentTime"].ToString();
                client.StylistId = Int32.Parse(collection["StylistId"]);
                client.Stylist = _db.Stylists.FirstOrDefault(s => s.StylistId == collection["StylistId"]);
                _db.Clients.Add(client);
                _db.SaveChanges();
            }
            catch
            {

            }
            return RedirectToRoute("Stylists", new { controller="Stylists", action="Details", id = stylistId });
        }

        [Route("/Stylists/{stylistId}/Clients/{id}/Details", Name="Details")]
        public ActionResult Details(int id)
        {
            Client client = _db.Clients.FirstOrDefault(c => c.ClientId == id);
            return View(client);
        }

    }
}