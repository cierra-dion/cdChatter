using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Chatter2.Models
{
    public class Message
    {
        public int MessageID { get; set; }
        [MaxLength(150)]
        public string MessageBox { get; set; }

        //Doesn't mean to be ICollection cuz only one to many relationship not many to many?
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}