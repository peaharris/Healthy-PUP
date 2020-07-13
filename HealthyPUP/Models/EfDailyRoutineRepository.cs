using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyPUP.Models
{
    public class EfDailyRoutineRepository : IDailyRoutineRepository
    {
        // F i e l d s  &  P r o p e r t i e s
        private AppDogDbContext context;

        // C o n s t r u c t o r s 
        public EfDailyRoutineRepository(AppDogDbContext context)
        {
            this.context = context;
        }

        // M e t h o d s  -  C R U D

        // C r e a t e
        public DailyRoutine Create(DailyRoutine dailyRoutine)
        {
            try
            {
                context.DailyRoutines.Add(dailyRoutine);
                context.SaveChanges();
                return dailyRoutine;
            }
            catch (Exception e)
            {//something bad happened!
                return null;
            }
        }

        // R e a d
        public IQueryable<DailyRoutine> GetAllDailyRoutines(int dogId)
        {
            return context.DailyRoutines
              .Where(dr => dr.DogId == dogId)
              .OrderBy(dr => dr.Date);
        }

        public DailyRoutine GetDailyRoutineById(int dailyRoutineId)
        {
            return context.DailyRoutines.FirstOrDefault(dr => dr.Id == dailyRoutineId);
             
        }
        public IQueryable<DailyRoutine> GetDailyRoutinesByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        // U p d a t e
        public DailyRoutine UpdateDailyRoutine(DailyRoutine dailyRoutine)
        {
            //1. Go find (read) this product from the database
            DailyRoutine dailyRoutineToUpdate = context.DailyRoutines //This will return an IQueryable
                .FirstOrDefault(dr => dr.Id == dailyRoutine.Id); //gets one product out of the database   

            //2. Modify the database copy of the product
            if (dailyRoutineToUpdate != null)
            {
                dailyRoutineToUpdate.Date = dailyRoutine.Date;
                dailyRoutineToUpdate.Food = dailyRoutine.Food;
                dailyRoutineToUpdate.Poop = dailyRoutine.Poop;
                dailyRoutineToUpdate.Pee = dailyRoutine.Pee;
                dailyRoutineToUpdate.Id = dailyRoutine.Id;

            //3. Dear Database: Please update you copy of this product
                context.SaveChanges();
            }
            return dailyRoutineToUpdate;
        }

        // D e l e t e
        public bool DeleteDailyRoutine(int id)
        {
            DailyRoutine dailyRoutineToDelete =
                context.DailyRoutines.FirstOrDefault(dr => dr.Id == id);
            if(dailyRoutineToDelete == null)
            {
                return false;
            }
            context.DailyRoutines.Remove(dailyRoutineToDelete);
            context.SaveChanges();
            return true;
        }
    }
}
