using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyPUP.Models
{
    public class DogWalk
    {
            public IQueryable<Dog> Dogs { get; set; }
            public IQueryable<Walk> Walks { get; set; }
    }
}
