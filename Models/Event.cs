using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventWeb.Models
{
    public class Event
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Time { get; set; }
        public int Attendees { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}