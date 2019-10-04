using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Category Name")]
        public string categoryName { get; set; }
        public int CategoryId { get; set; }
    }
}