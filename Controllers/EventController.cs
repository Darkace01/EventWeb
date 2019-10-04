using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventWeb.Models;


namespace EventWeb.Controllers
{
    public class EventController : Controller
    {
        public static List<Event> events = new List<Event>();
        public void CreateData()
        {
            

        events.Add(new Event { ID=1,Name = "Event One", Attendees = 57, Location = "Lagos", Time = "3:30am", categoryName = "Owanbee" });
            events.Add(new Event { ID=2,Name = "Event Two", Attendees = 30, Location = "Abuja", Time = "5:30am", categoryName = "Church" });
            events.Add(new Event { ID=3,Name = "Event Two", Attendees = 10, Location = "Ikeja", Time = "5:30am", categoryName = "Church" });

        }
        // GET: Event
        public ActionResult Index(string sortOrder,string searchString)
        {
            CreateData();
            ViewBag.Category = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var eventss = from e in events
                           select e;
            switch (sortOrder)
            {
                case "name_desc":
                    eventss = eventss.OrderByDescending(s => s.categoryName);
                    break;
                default:
                    eventss = eventss.OrderBy(s => s.Name);
                    break;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                eventss = eventss.Where(s => s.Location.Contains(searchString)
                                       || s.categoryName.Contains(searchString)
                                       || s.Time.Contains(searchString)
                                       || s.Name.Contains(searchString));
            }

            
            return View(eventss.ToList());
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            var detail = events.SingleOrDefault(c => c.ID == id);
            return View(detail);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        
    }
}
