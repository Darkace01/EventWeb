using EventWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using EventWeb.Models;

namespace EventWeb.Controllers
{
    public class EventController : Controller
    {
        private AppDbContext _context;

        public EventController()
        {
            _context = new AppDbContext();
            
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public void CreateData()
        {
            _context.Events.Add(new Event { Name = "Event One", Attendees = 57, Location = "Lagos", Time = "3:30am", CategoryId = 1 });
            _context.Events.Add(new Event { Name = "Event Two", Attendees = 30, Location = "Abuja", Time = "5:30am", CategoryId = 2 });
            _context.Events.Add(new Event { Name = "Event Two", Attendees = 10, Location = "Ikeja", Time = "5:30am", CategoryId = 1 });


            _context.Categories.Add(new Category { Name = "Owanbeee" });
            _context.Categories.Add(new Category { Name = "New Owanbee" });

            _context.SaveChanges();
        }
        // GET: Event
        public ActionResult Index(string sortOrder,string searchString)
        {
            CreateData();
            ViewBag.Category = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var events = from e in _context.Events
                           select e;
            switch (sortOrder)
            {
                case "name_desc":
                    events = events.OrderByDescending(s => s.Category.Name);
                    break;
                default:
                    events = events.OrderBy(s => s.Name);
                    break;
            }
                    if (!String.IsNullOrEmpty(searchString))
            {
                events = events.Where(s => s.Location.Contains(searchString)
                                       || s.Category.Name.Contains(searchString)
                                       || s.Time.Contains(searchString));
            }

            
            return View(events.ToList());
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            var detail = _context.Events.Include(c => c.Category).SingleOrDefault(c => c.ID == id);
            return View(detail);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        
    }
}
