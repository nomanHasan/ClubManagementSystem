using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubManagementV1.Models
{
    public class Club
    {
        [Key]
        public int ClubID { get; set; }
        
        public string ClubName { get; set; }
        
        public DateTime ClubCreated { get; set; }

        public string ClubDetails { get; set; }

        public List<Event> Events { get; set; }

        public List<President> Presidents { get; set; }

    }
}