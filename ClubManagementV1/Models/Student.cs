using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace ClubManagementV1.Models
{
    public class Student
    {
        public int StudentID { get; set; }

        public string StudentName { get; set; }
          
        public string StudentEmail { get; set; }

        public string StudentPhone { get; set; }
        
        public Account Account { get; set; }

        public List<Club> Clubs { get; set; }

        public List<Event> Events { get; set; }
        
    }
}