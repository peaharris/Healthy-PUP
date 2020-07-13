using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyPUP.Models
{
    public class EfDogRepository : IDogRepository
    {
        // F i e l d s  &  P r o p e r t i e s
        private AppDogDbContext context;
        private SignInManager<IdentityUser> signinManager;


        // C o n s t r u c t o r s 
        public EfDogRepository (AppDogDbContext context, SignInManager<IdentityUser> signinManager)
        {
            this.context = context;
            this.signinManager = signinManager;
        }

        // M e t h o d s  -  C R U D

        // C r e a t e
        public Dog Create(Dog dog)
        {
            var user = signinManager.Context.User;
            bool isLoggedIn = user.Identity.IsAuthenticated;

            if(isLoggedIn)
            {
                string userName = user.Identity.Name;
                dog.UserName = userName;
                try
                {
                    context.Dogs.Add(dog);
                    context.SaveChanges();
                    return dog;
                }
                catch (Exception e)
                {//something bad happened!
                }
            }
            return null;
        }

        // R e a d
        public IQueryable<Dog> GetAllDogs()
        {
            var user = signinManager.Context.User;
            bool isLoggedIn = user.Identity.IsAuthenticated;
            string userName = user.Identity.Name;

            return context.Dogs
                          .Where(d => d.UserName == userName)
                          .OrderBy(d => d.Name);
        }

        public Dog GetDogById(int dogId)
        {
            Dog theDog = context.Dogs
                                .Include(w => w.Walks)
                                .Include(v => v.VetVisits)
                                .Include(dr => dr.DailyRoutines)
                                .Where(d => d.Id == dogId)
                                .FirstOrDefault();
            //Walk[] allWalks = context.Walks.ToArray(); go to walks table and get ALL the walks
            return theDog;
        }
        public IQueryable<Dog> GetDogsByKeyword(string keyword)
        {
            return GetAllDogs()
                .Where(d => d.Name.Contains(keyword) || d.Breed.Contains(keyword))
                .Include(d => d.Walks);
        }

        // U p d a t e
        public Dog UpdateDog(Dog dog)
        {
            //1. Go find (read) this product from the database
            Dog dogFromDb = context.Dogs //This will return an IQueryable
                .FirstOrDefault(d => d.Id == dog.Id); //gets one product out of the database   

            //2. Modify the database copy of the product
            if (dogFromDb != null)
            {
                dogFromDb.Name = dog.Name;
                dogFromDb.Birthday = dog.Birthday;
                dogFromDb.Breed = dog.Breed;

            //3. Dear Database: Please update you copy of this product
                context.SaveChanges();
            }
            return dogFromDb;
        }

        // D e l e t e
        public bool DeleteDog(int id)
        {
            Dog dogToDelete =
                context.Dogs.FirstOrDefault(d => d.Id == id);
            if(dogToDelete == null)
            {
                return false;
            }
            context.Dogs.Remove(dogToDelete);
            context.SaveChanges();
            return true;
        }
    }
}
