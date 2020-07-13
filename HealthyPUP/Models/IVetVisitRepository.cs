using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyPUP.Models
{
    public interface IVetVisitRepository
    {
        // C r e a t e
        public VetVisit Create(VetVisit v);

        // R e a d 
        IQueryable<VetVisit> GetAllVetVisits(int dogId);
        VetVisit GetVetVisitById(int vetVisitId);
        IQueryable<VetVisit> GetVetVisitsByKeyword(string keyword);


        // U p d a t e 
        public VetVisit UpdateVetVisit(VetVisit v);

        // D e l e t e
        public bool DeleteVetVisit(int id);
    }
}
