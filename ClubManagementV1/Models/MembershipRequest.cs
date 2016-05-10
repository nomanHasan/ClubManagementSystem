using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClubManagementV1.Models
{
    public class MembershipRequest
    {
        public Club Club { get; set; }


        public Student Student { get; set; }
    }
}