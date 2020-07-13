using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyPUP.Models
{
    public class EfWalkRepository : IWalkRepository
    {
        // F i e l d s  &  P r o p e r t i e s
        private AppDogDbContext context;

        // C o n s t r u c t o r s 
        public EfWalkRepository (AppDogDbContext context)
        {
            this.context = context;
        }

        // M e t h o d s  -  C R U D

        // C r e a t e
        public Walk Create(Walk walk)
        {
            try
            {
                context.Walks.Add(walk);
                context.SaveChanges();
                return walk;
            }
            catch (Exception e)
            {//something bad happened!
                return null;
            }
        }

        // R e a d
        public IQueryable<Walk> GetAllWalks(int dogId)
        {
            return context.Walks
              .Where(w => w.DogId == dogId)
              .OrderBy(w => w.Date);
        }

        public Walk GetWalkById(int walkId)
        {
            return context.Walks.FirstOrDefault(w => w.Id == walkId);
             
        }
        public IQueryable<Walk> GetWalksByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        // U p d a t e
        public Walk UpdateWalk(Walk walk)
        {
            //1. Go find (read) this product from the database
            Walk walkToUpdate = context.Walks //This will return an IQueryable
                .FirstOrDefault(w => w.Id == walk.Id); //gets one product out of the database   

            //2. Modify the database copy of the product
            if (walkToUpdate != null)
            {
                walkToUpdate.Date = walk.Date;
                walkToUpdate.Duration = walk.Duration;
                walkToUpdate.Distance = walk.Distance;
                walkToUpdate.Location = walk.Location;
                walkToUpdate.Id = walk.Id;

            //3. Dear Database: Please update you copy of this product
                context.SaveChanges();
            }
            return walkToUpdate;
        }

        // D e l e t e
        public bool DeleteWalk(int id)
        {
            Walk walkToDelete =
                context.Walks.FirstOrDefault(w => w.Id == id);
            if(walkToDelete == null)
            {
                return false;
            }
            context.Walks.Remove(walkToDelete);
            context.SaveChanges();
            return true;
        }
    }
}
