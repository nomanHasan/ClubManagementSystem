using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ClubManagementV1.Models
{
    public class Admin
    {
        [Key]
        public int AdminID { get; set; }

        public string AdminName { get; set; }

        public Account Account { get; set; }


    }
}