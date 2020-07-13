using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyPUP.Models
{
    public class EfVetVisitRepository : IVetVisitRepository
    {
        // F i e l d s  &  P r o p e r t i e s
        private AppDogDbContext context;

        // C o n s t r u c t o r s 
        public EfVetVisitRepository(AppDogDbContext context)
        {
            this.context = context;
        }

        // M e t h o d s  -  C R U D

        // C r e a t e
        public VetVisit Create(VetVisit vetVisit)
        {
            try
            {
                context.VetVisits.Add(vetVisit);
                context.SaveChanges();
                return vetVisit;
            }
            catch (Exception e)
            {//something bad happened!
                return null;
            }
        }

        // R e a d
        public IQueryable<VetVisit> GetAllVetVisits(int dogId)
        {
            return context.VetVisits
              .Where(v => v.DogId == dogId)
              .OrderBy(v => v.Date);
        }

        public VetVisit GetVetVisitById(int vetVisitId)
        {
            return context.VetVisits.FirstOrDefault(v => v.Id == vetVisitId);
             
        }
        public IQueryable<VetVisit> GetVetVisitsByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        // U p d a t e
        public VetVisit UpdateVetVisit(VetVisit vetVisit)
        {
            //1. Go find (read) this product from the database
            VetVisit vetVisitToUpdate = context.VetVisits //This will return an IQueryable
                .FirstOrDefault(v => v.Id == vetVisit.Id); //gets one product out of the database   

            //2. Modify the database copy of the product
            if (vetVisitToUpdate != null)
            {
                vetVisitToUpdate.Date = vetVisit.Date;
                vetVisitToUpdate.Vaccine = vetVisit.Vaccine;
                vetVisitToUpdate.Weight = vetVisit.Weight;
                vetVisitToUpdate.Comments = vetVisit.Comments;
                vetVisitToUpdate.Id = vetVisit.Id;

            //3. Dear Database: Please update you copy of this product
                context.SaveChanges();
            }
            return vetVisitToUpdate;
        }

        // D e l e t e
        public bool DeleteVetVisit(int id)
        {
            VetVisit vetVisitToDelete =
                context.VetVisits.FirstOrDefault(v => v.Id == id);
            if(vetVisitToDelete == null)
            {
                return false;
            }
            context.VetVisits.Remove(vetVisitToDelete);
            context.SaveChanges();
            return true;
        }
    }
}
