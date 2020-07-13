using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyPUP.Models
{
    public interface IDailyRoutineRepository
    {
        // C r e a t e
        public DailyRoutine Create(DailyRoutine dr);

        // R e a d 
        IQueryable<DailyRoutine> GetAllDailyRoutines(int dogId);
        DailyRoutine GetDailyRoutineById(int dailyRoutineId);
        IQueryable<DailyRoutine> GetDailyRoutinesByKeyword(string keyword);


        // U p d a t e 
        public DailyRoutine UpdateDailyRoutine(DailyRoutine dr);

        // D e l e t e
        public bool DeleteDailyRoutine(int id);
    }
}
