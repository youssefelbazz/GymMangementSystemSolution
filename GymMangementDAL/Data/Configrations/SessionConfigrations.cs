using GymMangementDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Data.Configrations
{
    internal class SessionConfigrations : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable(Tb =>
            {
                Tb.HasCheckConstraint("CK_Session_Capacity", "Capacity Between 1 and 25");
                Tb.HasCheckConstraint("CK_Session_Dates", "StartDate < EndDate");
            });
        }
    }
}
