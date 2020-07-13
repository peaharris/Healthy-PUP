using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthyPUP.Models
{
    public class DailyRoutine
    {
        // F i e l d s  &  P r o p e r t i e s
        [Key]
        public int Id { get; set; }

        public string Date { get; set; }

        public string Food { get; set; }

        public int Poop { get; set; }

        public int Pee { get; set; }

        [ForeignKey("Dog")]
        public int DogId { get; set; }
        public Dog Dog { get; set; }
    }
}
