using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventWeb.Data;
using EventWeb.Models;


namespace EventWeb.Controllers
{
    public class EventController : Controller
    { 
        // GET: Event
        public ActionResult Index(string sortOrder,string searchString, string category)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
            } 

            // get all events
            var events = EventRepository.GetAllEvents();

            // filter by category
            if (!String.IsNullOrEmpty(category))
            {
                events = EventRepository.GetEventByCategoryName(category);
            } 

            // filter by search keyword (location or event title or category
            if (!String.IsNullOrEmpty(searchString))
            {
                events = events.Where(s => s.Location.ToLower().Contains(searchString)
                                       || s.Title.ToLower().Contains(searchString)
                                       || s.CategoryName.ToLower().Contains(searchString)).ToList();
            }

            ViewBag.Categories = EventRepository.GetEventCategories().Select(c => c.Name).ToList();
            return View(events);
        }
 

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {

            var theEvent = EventRepository.GetEventById(id);  
            if (theEvent == null)
            {
                return HttpNotFound();
            }
            return View(theEvent);
        }
         

        
    }
}
