using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthyPUP.Models
{
    public class DogViewModel //POCO create database 
    {
        // F i e l d s  &  P r o p e r t i e s
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Birthday { get; set; }

        public string Breed { get; set; }
        public string UserName { get; set; }
        public IEnumerable<Walk> Walks { get; set; }
        public IEnumerable<VetVisit> VetVisits { get; set; }
        public IEnumerable<DailyRoutine> DailyRoutines { get; set; }
        public IFormFile ProfilePicture { get; set; }

        //[ForeignKey("User")]
        //public int UserId { get; set; }
        //public User User { get; set; }






    }
}
