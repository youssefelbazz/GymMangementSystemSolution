using GymMangementDAL.Data.Contexts;
using GymMangementDAL.Entities;
using GymMangementDAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Classes
{
    public class TrainerRepository : ITrainerRepository
    {


        private readonly GymDbContext _dbContext;
        public TrainerRepository(GymDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Add(Trainer trainer)
        {
            _dbContext.Trainers.Add(trainer);
            return _dbContext.SaveChanges();
        }

        public int Delete(Trainer trainer)
        {
            _dbContext.Trainers.Remove(trainer);
            return _dbContext.SaveChanges();
        }

        public Trainer? Get(int id)
        {
            return _dbContext.Trainers.Find(id);
        }

        public IEnumerable<Trainer> GetAll()
        {
            return _dbContext.Trainers.ToList();
        }

        public int Update(Trainer trainer)
        {
            _dbContext.Trainers.Update(trainer);
            return _dbContext.SaveChanges();
        }
    }
}
