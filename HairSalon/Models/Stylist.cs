using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace HairSalon.Models
{
    public class Stylist
    {
        public int StylistId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Price Rating")]
        public int PriceRating { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        public virtual ICollection<Client> Clients { get; set; }

        public Stylist()
        {
            this.Clients = new HashSet<Client>();
        }
    }
}