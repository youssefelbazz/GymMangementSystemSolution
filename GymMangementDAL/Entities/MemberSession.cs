using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Entities
{
    internal class MemberSession:BaseEntity
    {
        //BookingDate == CreatedAt
        public bool IsAttended { get; set; }
        public Member Member { get; set; }
        public int MemberId { get; set; }
        public Session Session { get; set; }
        public int SessionId { get; set; }
    }
}
