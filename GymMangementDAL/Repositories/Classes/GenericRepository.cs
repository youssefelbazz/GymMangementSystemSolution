using GymMangementDAL.Data.Contexts;
using GymMangementDAL.Entities;
using GymMangementDAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Classes
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity , new()
    {

        private readonly GymDbContext _dbcontext;
        public GenericRepository(GymDbContext dbContext)
        {
            dbContext= _dbcontext;
        }
        public int Add(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Add(entity);
            return _dbcontext.SaveChanges();
        }

        public int Delete(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Remove(entity);
            return _dbcontext.SaveChanges();
        }


        public IEnumerable<TEntity> GetAll(Func<TEntity, bool>? condition = null)
        {
          if (condition == null)
            {
                return _dbcontext.Set<TEntity>().AsNoTracking().ToList();
            }
            else
            {
                return _dbcontext.Set<TEntity>().AsNoTracking().Where(condition).ToList();
            }
        }

        public TEntity? GetById(int id)
        {
            return _dbcontext.Set<TEntity>().Find(id);
        }

        public int Update(TEntity entity)
        {
            _dbcontext.Set<TEntity>().Update(entity);
            return _dbcontext.SaveChanges();
        }
    }
}
