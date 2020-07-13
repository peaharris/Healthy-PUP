using System;
namespace HealthyPUP.Models
{
    public class VetVisits
    {
        // F i e l d s  &  P r o p e r t i e s

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public string Vaccine { get; set; }

        public double Weight { get; set; }

        public string Comments { get; set; }
    }
}