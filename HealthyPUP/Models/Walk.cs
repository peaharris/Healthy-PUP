using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyPUP.Models
{
    public class Walk
    {
        // F i e l d s  &  P r o p e r t i e s
        [Key]
        public int Id { get; set; }

        public string Date { get; set; }

        public double Duration { get; set; }

        public double Distance { get; set; }
        public string Location { get; set; }

        [ForeignKey("Dog")]
        public int DogId { get; set; }
        public Dog Dog { get; set; }
    }
}
