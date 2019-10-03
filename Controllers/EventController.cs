using EventWeb.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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

        // GET: Event
        public ActionResult Index(string sortOrder,string searchString)
        {
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
