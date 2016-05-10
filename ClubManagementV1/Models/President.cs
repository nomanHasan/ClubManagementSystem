using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubManagementV1.Models
{
    public class President
    {
        public Student Student { get; set; }

        public Club Club { get; set; }
        

        public Account Account { get; set; }
    }
}