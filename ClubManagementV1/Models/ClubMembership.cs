using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ClubManagementV1.Models
{
    public class ClubMembership
    {

        public Club Club { get; set; }


        public Student Student { get; set; }

        public DateTime DateJoined { get; set; }

    }
}