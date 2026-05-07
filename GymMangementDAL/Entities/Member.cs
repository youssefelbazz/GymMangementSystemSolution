using GymMangementDAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Entities
{
    public class Member:GymUser
    {

        //join date == created at 
        public string? Photo { get; set; }

        public HealthRecord HealthRecord { get; set; } = null!;

        public ICollection<MemberShip> MemberShips { get; set; }=null!;
        public ICollection<MemberSession> MemberSessions { get; set; }=null!;

    }
}
