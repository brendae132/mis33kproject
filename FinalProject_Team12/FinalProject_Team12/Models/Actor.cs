using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FinalProject_Team12.Models
{
    public class Actor
    {
        public Int32 ActorID { get; set;}
        
        [Display(Name = "Actor Name")]
        public String ActorName { get; set; }

        //navigationalproperties
        public virtual List<Movie> Movies { get; set; }
    }
}