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
    internal class MemberRepository : IMemberRepository
    {
        private readonly GymDbContext _dbContext= new GymDbContext();

        public int Add(Member member)
        {
            _dbContext.Members.Add(member);
            return _dbContext.SaveChanges();
        }

        public int Delete(int id)
        {
            var Member = _dbContext.Members.Find(id);
            if(Member is null) { return 0; }
            _dbContext.Members.Remove(Member);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<Member> GetAlL()
        {
           
             return _dbContext.Members.ToList();
        }

        public Member? GetById(int id)
        {
            return _dbContext.Members.Find(id);
        }

        public int Update(Member member)
        {
            _dbContext.Members.Update(member);
            return _dbContext.SaveChanges();
        }
    }
}
