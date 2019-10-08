using EventWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventWeb.Data
{
    public class EventRepository
    {
        public static List<Event> GetAllEvents()
        {
            var events = new List<Event>()
            {
                new Event{ ID=1,Title = "Harlem Harvest Festival 2019", Attendees = 57, Location = "New York", Time = DateTime.UtcNow, CategoryName = "Technology", LongDescription= "This city never sleeps for a reason — there's way too much to do. Catch an art show in Chelsea or a play Off Broadway. Head to an underground venue to see your favorite band play live or to a pop-up for a mouthwatering prix fixe meal. Take a workshop in Brooklyn or eat your way through a food festival in Queens. Take your outings to the next level with these New York events.", ImgUrl= "~/Content/Images/event-1.jpg" },
                new Event { ID=2,Title = "Cochela", Attendees = 30, Location = "Carlifonia", Time = DateTime.UtcNow, CategoryName = "Church", LongDescription= "On Saturday, October 5, 2019, the 10th annual Veuve Clicquot Polo Classic, Los Angeles returns to Will Rogers State Historic Park. Join Veuve Clicquot to watch an exciting polo match while enjoying a day of picnicking and champagne sippin Polo - goers and champagne sippers alike can purchase one of four ticketing options,which offers access to Veuve Clicquot champagne bars featuring Yellow Label, Rob La Grande Dame,Rich,and Rich Rosé.Guests will be able to enjoy delicious food offerings from some of the city’s most popular food trucks, lawn games,and prime seating to cheer from the sidelines during a thrilling polo match led by world - renowned polo player Nacho Figueras.", ImgUrl= "~/Content/Images/event-3.jpg" },
                new Event { ID=3,Title = "Headies", Attendees = 10, Location = "London", Time = DateTime.UtcNow, CategoryName = "Church" , ImgUrl="~/Content/Images/event-1.jpg", LongDescription= "This city never sleeps for a reason — there's way too much to do. Catch an art show in Chelsea or a play Off Broadway. Head to an underground venue to see your favorite band play live or to a pop-up for a mouthwatering prix fixe meal. Take a workshop in Brooklyn or eat your way through a food festival in Queens. Take your outings to the next level with these New York events."},
                new Event { ID=4,Title = "Headies", Attendees = 10, Location = "London", Time = DateTime.UtcNow, CategoryName = "Church" , ImgUrl="~/Content/Images/event-3.jpg", LongDescription= "On Saturday, October 5, 2019, the 10th annual Veuve Clicquot Polo Classic, Los Angeles returns to Will Rogers State Historic Park. Join Veuve Clicquot to watch an exciting polo match while enjoying a day of picnicking and champagne sippin Polo - goers and champagne sippers alike can purchase one of four ticketing options,which offers access to Veuve Clicquot champagne bars featuring Yellow Label, Rob La Grande Dame,Rich,and Rich Rosé.Guests will be able to enjoy delicious food offerings from some of the city’s most popular food trucks, lawn games,and prime seating to cheer from the sidelines during a thrilling polo match led by world - renowned polo player Nacho Figueras."},
                new Event { ID=5,Title = "Headies", Attendees = 10, Location = "London", Time = DateTime.UtcNow, CategoryName = "Arts" , ImgUrl="~/Content/Images/event-2.jpg", LongDescription= "This city never sleeps for a reason — there's way too much to do. Catch an art show in Chelsea or a play Off Broadway. Head to an underground venue to see your favorite band play live or to a pop-up for a mouthwatering prix fixe meal. Take a workshop in Brooklyn or eat your way through a food festival in Queens. Take your outings to the next level with these New York events."},
                new Event { ID=6,Title = "Headies", Attendees = 10, Location = "London", Time = DateTime.UtcNow, CategoryName = "Church" , ImgUrl="~/Content/Images/event-1.jpg", LongDescription= "On Saturday, October 5, 2019, the 10th annual Veuve Clicquot Polo Classic, Los Angeles returns to Will Rogers State Historic Park. Join Veuve Clicquot to watch an exciting polo match while enjoying a day of picnicking and champagne sippin Polo - goers and champagne sippers alike can purchase one of four ticketing options,which offers access to Veuve Clicquot champagne bars featuring Yellow Label, Rob La Grande Dame,Rich,and Rich Rosé.Guests will be able to enjoy delicious food offerings from some of the city’s most popular food trucks, lawn games,and prime seating to cheer from the sidelines during a thrilling polo match led by world - renowned polo player Nacho Figueras."},
                new Event { ID=7,Title = "Headies", Attendees = 10, Location = "London", Time = DateTime.UtcNow, CategoryName = "Love" , ImgUrl="~/Content/Images/event-3.jpg", LongDescription= "This city never sleeps for a reason — there's way too much to do. Catch an art show in Chelsea or a play Off Broadway. Head to an underground venue to see your favorite band play live or to a pop-up for a mouthwatering prix fixe meal. Take a workshop in Brooklyn or eat your way through a food festival in Queens. Take your outings to the next level with these New York events."},
                new Event { ID=8,Title = "Headies", Attendees = 10, Location = "London", Time = DateTime.UtcNow, CategoryName = "Sports" , ImgUrl="~/Content/Images/event-3.jpg", LongDescription= "On Saturday, October 5, 2019, the 10th annual Veuve Clicquot Polo Classic, Los Angeles returns to Will Rogers State Historic Park. Join Veuve Clicquot to watch an exciting polo match while enjoying a day of picnicking and champagne sippin Polo - goers and champagne sippers alike can purchase one of four ticketing options,which offers access to Veuve Clicquot champagne bars featuring Yellow Label, Rob La Grande Dame,Rich,and Rich Rosé.Guests will be able to enjoy delicious food offerings from some of the city’s most popular food trucks, lawn games,and prime seating to cheer from the sidelines during a thrilling polo match led by world - renowned polo player Nacho Figueras."}

            };
            return events;
        }

        public static Event GetEventById(int id)
        {
            var allEvents = GetAllEvents();
            var theEvent = allEvents.Where(e => e.ID == id).FirstOrDefault();
            return theEvent;
        }

        public static List<Event> GetEventByCategoryName(string category)
        {
            var allEvents = GetAllEvents();
            var theEvents = allEvents.Where(e => e.CategoryName.ToLower().Contains(category.ToLower())).ToList();
            return theEvents;
        }

        public static List<EventCategory> GetEventCategories()
        {
            var categories = new List<EventCategory>
            {
                new EventCategory{ID = 1, Name = "Sports"},
                new EventCategory{ID = 1, Name = "Technology"},
                new EventCategory{ID = 1, Name = "Arts"},
                 new EventCategory{ID = 1, Name = "Church"},
                new EventCategory{ID = 1, Name = "Lifestyle"},
                new EventCategory{ID = 1, Name = "Love"},
            };
            return categories;
        }
    }
}