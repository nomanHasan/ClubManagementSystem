using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubManagementV1.Models
{
    public class ParticipationRequest
    {
        public Student Student { get; set; }


        public Event Event { get; set; }
    }
}