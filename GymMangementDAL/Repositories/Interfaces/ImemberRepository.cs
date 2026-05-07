using GymMangementDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Repositories.Interfaces
{
    internal interface IMemberRepository
    {
        IEnumerable<Member> GetAlL();   
        Member? GetById(int id);

        int Add(Member member);

        int Update(Member member);  
        int Delete(int id);

    }
}
