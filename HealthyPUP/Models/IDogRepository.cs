using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyPUP.Models
{
    public interface IDogRepository
    {
        // C r e a t e
        public Dog Create(Dog dog);

        // R e a d 
        IQueryable<Dog> GetAllDogs();
        Dog GetDogById(int dogId);
        IQueryable<Dog> GetDogsByKeyword(string keyword);

        // U p d a t e 
        public Dog UpdateDog(Dog d);

        // D e l e t e
        public bool DeleteDog(int id);
    }
}
