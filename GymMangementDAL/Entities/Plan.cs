using GymMangementDAL.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Entities
{
    internal class Plan : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string DurationDays { get; set; }
        public bool IsActive { get; set; }
        public decimal Price { get; set; }

        public ICollection<MemberShip> PlanMembers { get; set; } = null!;
    }
}
