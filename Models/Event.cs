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
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
        [Display(Name = "Long Description")]
        public string LongDescription { get; set; }
        public DateTime Time { get; set; }
        public int Attendees { get; set; }
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public string ImgUrl { get; set; }
    }
}