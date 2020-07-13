using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyPUP.Models
{
    public class AppDogDbContext : IdentityDbContext<IdentityUser>
    {
        // F i e l d s  &  P r o p e r t i e s
        public DbSet<Dog>  Dogs  { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<VetVisit> VetVisits { get; set; }
        public DbSet<DailyRoutine> DailyRoutines { get; set; }



        // C o n s t r u c t o r s
        public AppDogDbContext (DbContextOptions<AppDogDbContext> options)
            :base(options)
        {
        }

        // M e t h o d s 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        //    // D o g s
        //    modelBuilder.Entity<Dog>().HasData
        //        (new Dog
        //        {
        //            Id = 1,
        //            Name = "Harold",
        //            Breed = "Boston Terrier",
        //            Birthday = "2010-02-19"
        //        });
        //    modelBuilder.Entity<Dog>().HasData
        //        (new Dog
        //        {
        //            Id = 2,
        //            Name = "Buck",
        //            Breed = "Lab",
        //            Birthday = "2015-01-10"
        //        });
        //    modelBuilder.Entity<Dog>().HasData
        //        (new Dog
        //        {
        //            Id = 3,
        //            Name = "Bones",
        //            Breed = "Chow Chow",
        //            Birthday = "2018-05-09"
        //        });
        //    modelBuilder.Entity<Dog>().HasData
        //        (new Dog
        //        {
        //            Id = 4,
        //            Name = "Winnie",
        //            Breed = "Border Collie",
        //            Birthday = "2016-01-19"
        //        });
        //    modelBuilder.Entity<Dog>().HasData
        //        (new Dog
        //        {
        //            Id = 5,
        //            Name = "Moose",
        //            Breed = "Pit Terrier",
        //            Birthday = "2012-02-04"
        //        });
        //    modelBuilder.Entity<Dog>().HasData
        //        (new Dog
        //        {
        //            Id = 6,
        //            Name = "Mochi",
        //            Breed = "Chihuahuas",
        //            Birthday = "2014-04-17"
        //        });
        //    modelBuilder.Entity<Dog>().HasData
        //        (new Dog
        //        {
        //            Id = 7,
        //            Name = "Walter",
        //            Breed = "Scottish Terrier",
        //            Birthday = "2016-06-21"
        //        });
        //    modelBuilder.Entity<Dog>().HasData
        //        (new Dog
        //        {
        //            Id = 8,
        //            Name = "Ben",
        //            Breed = "German Shepherd",
        //            Birthday = "2015-12-24"
        //        });
        //    modelBuilder.Entity<Dog>().HasData
        //        (new Dog
        //        {
        //            Id = 9,
        //            Name = "Penny",
        //            Breed = "Poodle",
        //            Birthday = "2016-11-14"
        //        });
        //    modelBuilder.Entity<Dog>().HasData
        //        (new Dog
        //        {
        //            Id = 10,
        //            Name = "Yoshi",
        //            Breed = "Pug",
        //            Birthday = "2015-02-14"
        //        });

        //    // W a l k s
        //    modelBuilder.Entity<Walk>().HasData
        //      (new Walk
        //      {
        //          Id = 1,
        //          Date = "2020-05-08",
        //          Duration = 50,
        //          Distance = 1,
        //          Location = "Walked to ciy Park and played frisbee",
        //          DogId = 1
        //      });
        //    modelBuilder.Entity<Walk>().HasData
        //      (new Walk
        //      {
        //          Id = 2,
        //          Date = "2020-05-08",
        //          Duration = 60,
        //          Distance = 2,
        //          Location = "Walked to the creek",
        //          DogId = 2
        //      });
        //    modelBuilder.Entity<Walk>().HasData
        //      (new Walk
        //      {
        //          Id = 3,
        //          Date = "2020-05-08",
        //          Duration = 50,
        //          Distance = 1,
        //          Location = "Walked to Target",
        //          DogId = 3
        //      });
        //    modelBuilder.Entity<Walk>().HasData
        //      (new Walk
        //      {
        //          Id = 4,
        //          Date = "2020-05-08",
        //          Duration = 30,
        //          Distance = 0,
        //          Location = "Dog Park",
        //          DogId = 4
        //      });
        //    modelBuilder.Entity<Walk>().HasData
        //      (new Walk
        //      {
        //          Id = 5,
        //          Date = "2020-05-08",
        //          Duration = 80,
        //          Distance = 3,
        //          Location = "Dog Park",
        //          DogId = 5
        //      });
        //    modelBuilder.Entity<Walk>().HasData
        //      (new Walk
        //      {
        //          Id = 6,
        //          Date = "2020-05-08",
        //          Duration = 180,
        //          Distance = 3,
        //          Location = "Benedict Fountain Park",
        //          DogId = 6
        //      });
        //    modelBuilder.Entity<Walk>().HasData
        //      (new Walk
        //      {
        //          Id = 7,
        //          Date = "2020-05-08",
        //          Duration = 250,
        //          Distance = 4,
        //          Location = "Jogged to Curtis Park and back",
        //          DogId = 7
        //      });
        //    modelBuilder.Entity<Walk>().HasData
        //      (new Walk
        //      {
        //          Id = 8,
        //          Date = "2020-05-08",
        //          Duration = 200,
        //          Distance = 3,
        //          Location = "Went swimming at the beach",
        //          DogId = 8
        //      });
        //    modelBuilder.Entity<Walk>().HasData
        //      (new Walk
        //      {
        //          Id = 9,
        //          Date = "2020-05-08",
        //          Duration = 220,
        //          Distance = 4,
        //          Location = "Played fetch at Lawson Park",
        //          DogId = 9
        //      });
        //    modelBuilder.Entity<Walk>().HasData
        //      (new Walk
        //      {
        //          Id = 10,
        //          Date = "2020-05-08",
        //          Duration = 160,
        //          Distance = 2,
        //          Location = "Walked to City Park",
        //          DogId = 10
        //      });

        //    // V e t  V i s i t s 
        //    modelBuilder.Entity<VetVisit>().HasData
        //        (new VetVisit
        //        {
        //            Id = 1, 
        //            Date = "2020-05-01",
        //            Vaccine = "Rabies",
        //            Weight = 18,
        //            Comments = "Harold was so bad at the vets today!",
        //            DogId = 1
        //        });
        //    modelBuilder.Entity<VetVisit>().HasData
        //        (new VetVisit
        //        {
        //            Id = 2,
        //            Date = "2020-05-02",
        //            Vaccine = "Distemper",
        //            Weight = 55,
        //            Comments = "Buck needs to start taking fish oil pills",
        //            DogId = 2
        //        });
        //    modelBuilder.Entity<VetVisit>().HasData
        //        (new VetVisit
        //        {
        //            Id = 3,
        //            Date = "2020-05-03",
        //            Vaccine = "Parvo",
        //            Weight = 67,
        //            Comments = "Bones coat is dry",
        //            DogId = 3
        //        });
        //    modelBuilder.Entity<VetVisit>().HasData
        //        (new VetVisit
        //        {
        //            Id = 4,
        //            Date = "2020-05-01",
        //            Vaccine = "Parainfluenza",
        //            Weight = 26,
        //            Comments = "Winnie was so good today!",
        //            DogId = 4
        //        });
        //    modelBuilder.Entity<VetVisit>().HasData
        //        (new VetVisit
        //        {
        //            Id = 5,
        //            Date = "2020-05-02",
        //            Vaccine = "Rabies",
        //            Weight = 45,
        //            Comments = "Moose needs to come back in 2 weeks for a follow up",
        //            DogId = 5
        //        });
        //    modelBuilder.Entity<VetVisit>().HasData
        //        (new VetVisit
        //        {
        //            Id = 6,
        //            Date = "2020-05-05",
        //            Vaccine = "Rabies",
        //            Weight = 10,
        //            Comments = "Mochi needs to gain 5 lbs",
        //            DogId = 6
        //        });
        //    modelBuilder.Entity<VetVisit>().HasData
        //        (new VetVisit
        //        {
        //            Id = 7,
        //            Date = "2020-05-06",
        //            Vaccine = "Kennel Cough",
        //            Weight = 19,
        //            Comments = "Walter was so bad at the vets today!",
        //            DogId = 7
        //        });
        //    modelBuilder.Entity<VetVisit>().HasData
        //        (new VetVisit
        //        {
        //            Id = 8,
        //            Date = "2020-05-07",
        //            Vaccine = null,
        //            Weight = 67,
        //            Comments = "Ben was so good and well behaved at the vets today!",
        //            DogId = 8
        //        });
        //    modelBuilder.Entity<VetVisit>().HasData
        //        (new VetVisit
        //        {
        //            Id = 9,
        //            Date = "2020-05-03",
        //            Vaccine = null,
        //            Weight = 45,
        //            Comments = "Penny was complimented on her coat",
        //            DogId = 9
        //        });
        //    modelBuilder.Entity<VetVisit>().HasData
        //        (new VetVisit
        //        {
        //            Id = 10,
        //            Date = "2020-05-04",
        //            Vaccine = "Rabies",
        //            Weight = 23,
        //            Comments = "Yoshi needs to lose 5 lbs!",
        //            DogId = 10
        //        });

        //    // D a i l y  R o u t i n e
        //    modelBuilder.Entity<DailyRoutine>().HasData
        //        (new DailyRoutine
        //        {
        //            Id = 1,
        //            Date = "2020-05-08",
        //            Food = "Chicken and sweet potatoes ",
        //            Poop = 2,
        //            Pee = 4,
        //            DogId = 1
        //        });
        //    modelBuilder.Entity<DailyRoutine>().HasData
        //        (new DailyRoutine
        //        {
        //            Id = 2,
        //            Date = "2020-05-08",
        //            Food = "Iams",
        //            Poop = 3,
        //            Pee = 2,
        //            DogId = 2
        //        });
        //    modelBuilder.Entity<DailyRoutine>().HasData
        //        (new DailyRoutine
        //        {
        //            Id = 3,
        //            Date = "2020-05-08",
        //            Food = "Eggs and carrots",
        //            Poop = 3,
        //            Pee = 4,
        //            DogId = 3
        //        });
        //    modelBuilder.Entity<DailyRoutine>().HasData
        //        (new DailyRoutine
        //        {
        //            Id = 4,
        //            Date = "2020-05-08",
        //            Food = "Blue Buffalo Chicken Kibbles",
        //            Poop = 2,
        //            Pee = 6,
        //            DogId = 4
        //        });
        //    modelBuilder.Entity<DailyRoutine>().HasData
        //        (new DailyRoutine
        //        {
        //            Id = 5,
        //            Date = "2020-05-08",
        //            Food = "Purina Beneful",
        //            Poop = 3,
        //            Pee = 9,
        //            DogId = 5
        //        });
        //    modelBuilder.Entity<DailyRoutine>().HasData
        //        (new DailyRoutine
        //        {
        //            Id = 6,
        //            Date = "2020-05-08",
        //            Food = "Raw chicken and rice",
        //            Poop = 3,
        //            Pee = 6,
        //            DogId = 6
        //        });
        //    modelBuilder.Entity<DailyRoutine>().HasData
        //        (new DailyRoutine
        //        {
        //            Id = 7,
        //            Date = "2020-05-08",
        //            Food = "Taste of the Wild Salmon Kibbles",
        //            Poop = 4,
        //            Pee = 8,
        //            DogId = 7
        //        });
        //    modelBuilder.Entity<DailyRoutine>().HasData
        //        (new DailyRoutine
        //        {
        //            Id = 8,
        //            Date = "2020-05-08",
        //            Food = "Hills Science Diet Kibbles",
        //            Poop = 3,
        //            Pee = 5,
        //            DogId = 8
        //        });
        //    modelBuilder.Entity<DailyRoutine>().HasData
        //        (new DailyRoutine
        //        {
        //            Id = 9,
        //            Date = "2020-05-08",
        //            Food = "Beef Cheek and sweet potatoes",
        //            Poop = 4,
        //            Pee = 9,
        //            DogId = 9
        //        });
        //    modelBuilder.Entity<DailyRoutine>().HasData
        //        (new DailyRoutine
        //        {
        //            Id = 10,
        //            Date = "2020-05-08",
        //            Food = "Pork and brussel sprouts",
        //            Poop = 3,
        //            Pee = 8,
        //            DogId = 10
        //        });
        }
    }
}
