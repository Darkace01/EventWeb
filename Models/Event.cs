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
        public string Title { get; set; }
        public string Location { get; set; }

 
        [Display(Name = "Long Description")]
        public string LongDescription { get; set; }


        [Display(Name = "Short Description")]
        public string ShortDescription
        {
            get {
                if (String.IsNullOrEmpty(LongDescription)){
                    return null;
                }
                else
                {
                    return LongDescription.Substring(0, 100) + "...";
                }
            }
        }

        public DateTime Time { get; set; }

        public int Attendees { get; set; }

        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }
        public string ImgUrl { get; set; }
    }
}