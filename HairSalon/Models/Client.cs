using System;
using System.ComponentModel.DataAnnotations;
namespace HairSalon.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Preferred Day of Week")]
        public int PreferredAppointmentWeekDay { get; set; }
        [Display(Name = "Preferred Time")]
        public string PreferredAppointmentTime { get; set; }

        public int StylistId { get; set; }
        public virtual Stylist Stylist { get; set; }
    }
}