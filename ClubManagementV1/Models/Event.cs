using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubManagementV1.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }

        public string EventName { get; set; }

        public DateTime EventTime { get; set; }

        public Club EventClub { get; set; }

        public President President { get; set; }

        public string EventVenue { get; set; }
        

    }
}