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
            Random random = new Random();
            int iD =  random.Next(1, 100);

            events.Add(new Event { ID=iD,Name = "Harlem Harvest Festival 2019", Attendees = 57, Location = "New York", Time = DateTime.UtcNow, categoryName = "Technology" , shortDescription= "his city never sleeps for a reason — there's way too much to do. Catch an art show in Chelsea or a play Off Broadway." , longDescription= "This city never sleeps for a reason — there's way too much to do. Catch an art show in Chelsea or a play Off Broadway. Head to an underground venue to see your favorite band play live or to a pop-up for a mouthwatering prix fixe meal. Take a workshop in Brooklyn or eat your way through a food festival in Queens. Take your outings to the next level with these New York events.", imgUrl= "https://img.evbuc.com/https%3A%2F%2Fcdn.evbuc.com%2Fimages%2F38670528%2F108919755319%2F1%2Foriginal.jpg?auto=compress&s=32c728ebfab7bb7cab9cf42307962b37" });


            events.Add(new Event { ID=iD,Name = "Event Two", Attendees = 30, Location = "Carlifonia", Time = DateTime.UtcNow, categoryName = "Church" , shortDescription= "Looking for something to do in California? Whether you're a local, new in town or just cruising through we've got loads of great tips and events." , longDescription= "On Saturday, October 5, 2019, the 10th annual Veuve Clicquot Polo Classic, Los Angeles returns to Will Rogers State Historic Park. Join Veuve Clicquot to watch an exciting polo match while enjoying a day of picnicking and champagne sippin Polo - goers and champagne sippers alike can purchase one of four ticketing options,which offers access to Veuve Clicquot champagne bars featuring Yellow Label, Rob La Grande Dame,Rich,and Rich Rosé.Guests will be able to enjoy delicious food offerings from some of the city’s most popular food trucks, lawn games,and prime seating to cheer from the sidelines during a thrilling polo match led by world - renowned polo player Nacho Figueras.", imgUrl= "https://cdn.evbuc.com/eventlogos/146786072/svcpcla19textcrop.png" });


            events.Add(new Event { ID=iD,Name = "Event Two", Attendees = 10, Location = "London", Time = DateTime.UtcNow, categoryName = "Church" });

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
                                       || s.Name.Contains(searchString));
            }

            
            return View(eventss.ToList());
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {

            var detail = events.First(c => c.ID == id);
            if (detail == null)
            {
                return HttpNotFound();
            }
            return View(detail);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return View();
        }

        
    }
}
