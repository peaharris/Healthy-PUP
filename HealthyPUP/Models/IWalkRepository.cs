using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyPUP.Models
{
    public interface IWalkRepository
    {
        // C r e a t e
        public Walk Create(Walk w);

        // R e a d 
        IQueryable<Walk> GetAllWalks(int dogId);
        Walk GetWalkById(int walkId);
        IQueryable<Walk> GetWalksByKeyword(string keyword);


        // U p d a t e 
        public Walk UpdateWalk(Walk w);

        // D e l e t e
        public bool DeleteWalk(int id);
    }
}
