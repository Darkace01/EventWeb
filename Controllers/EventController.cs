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


        public List<Event> GetAllEvents()
        {
            var events = new List<Event>()
            {
                new Event{ ID=1,Name = "Harlem Harvest Festival 2019", Attendees = 57, Location = "New York", Time = DateTime.UtcNow, CategoryName = "Technology" , ShortDescription= "his city never sleeps for a reason — there's way too much to do. Catch an art show in Chelsea or a play Off Broadway." , LongDescription= "This city never sleeps for a reason — there's way too much to do. Catch an art show in Chelsea or a play Off Broadway. Head to an underground venue to see your favorite band play live or to a pop-up for a mouthwatering prix fixe meal. Take a workshop in Brooklyn or eat your way through a food festival in Queens. Take your outings to the next level with these New York events.", ImgUrl= "https://img.evbuc.com/https%3A%2F%2Fcdn.evbuc.com%2Fimages%2F38670528%2F108919755319%2F1%2Foriginal.jpg?auto=compress&s=32c728ebfab7bb7cab9cf42307962b37" },

                new Event { ID=2,Name = "Cochela", Attendees = 30, Location = "Carlifonia", Time = DateTime.UtcNow, CategoryName = "Church" , ShortDescription= "Looking for something to do in California? Whether you're a local, new in town or just cruising through we've got loads of great tips and events." , LongDescription= "On Saturday, October 5, 2019, the 10th annual Veuve Clicquot Polo Classic, Los Angeles returns to Will Rogers State Historic Park. Join Veuve Clicquot to watch an exciting polo match while enjoying a day of picnicking and champagne sippin Polo - goers and champagne sippers alike can purchase one of four ticketing options,which offers access to Veuve Clicquot champagne bars featuring Yellow Label, Rob La Grande Dame,Rich,and Rich Rosé.Guests will be able to enjoy delicious food offerings from some of the city’s most popular food trucks, lawn games,and prime seating to cheer from the sidelines during a thrilling polo match led by world - renowned polo player Nacho Figueras.", ImgUrl= "https://img.evbuc.com/https%3A%2F%2Fcdn.evbuc.com%2Fimages%2F38670296%2F108919755319%2F1%2Foriginal.jpg?auto=compress&s=75f8839894ebbcf4582f60fdd2108b41" },

                new Event { ID=3,Name = "Headies", Attendees = 10, Location = "London", Time = DateTime.UtcNow, CategoryName = "Church" , ImgUrl="https://www.tripsavvy.com/thmb/3eY-niQL7ktbmfj46_EUAGxHkSM=/3000x1864/filters:no_upscale():max_bytes(150000):strip_icc()/Disney-Halloween-57fe9c733df78cbc2860740b.jpg", ShortDescription= "Looking for something to do in California? Whether you're a local, new in town or just cruising through we've got loads of great tips and events."}
            };
            return events;
        }
        // GET: Event
        public ActionResult Index(string sortOrder,string searchString)
        {
            GetAllEvents();
            ViewBag.Category = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.Location = String.IsNullOrEmpty(sortOrder) ? "location" : "";

            var events = from e in GetAllEvents()
                           select e;
            switch (sortOrder)
            {
                case "name_desc":
                    events = events.OrderByDescending(s => s.CategoryName);
                    break;
                case "location":
                    events = events.OrderBy(s => s.Location);
                    break;
                default:
                    events = events.OrderBy(s => s.Name);
                    break;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                events = events.Where(s => s.Location.Contains(searchString)
                                       || s.CategoryName.Contains(searchString)
                                       || s.Name.Contains(searchString));
            }

            return View(events.ToList());
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {

            var detail = GetAllEvents().SingleOrDefault(c => c.ID == id);
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
