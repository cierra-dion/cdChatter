using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Chatter2.Models
{
    public class Photo
    {
        public int PhotoID { get; set; }
        public string UserPhoto { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}