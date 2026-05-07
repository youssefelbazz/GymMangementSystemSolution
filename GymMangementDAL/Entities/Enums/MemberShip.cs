using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Entities.Enums
{
    public class MemberShip:BaseEntity
    {
        //start date == created at 
        public DateTime EndDate { get; set; }
        //readonly property
       public string Status         {
            get
            {
                if (DateTime.Now <= EndDate)
                    return "Expired";
                else
                    return "Active";
            }
        }
        public Member Member { get; set; }=null!;
        public int MemberId { get; set; }
        public int PlanId { get; set; }
        public Plan Plan { get; set; } = null!;


    }
}
