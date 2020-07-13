using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthyPUP.Models
{
    public class VetVisit
    {
        // F i e l d s  &  P r o p e r t i e s
        [Key]
        public int Id { get; set; }

        public string Date { get; set; }

        public string Vaccine { get; set; }

        public double Weight { get; set; }

        public string Comments { get; set; }

        [ForeignKey("Dog")]
        public int DogId { get; set; }
        public Dog Dog { get; set; }
    }
}