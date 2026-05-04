using GymMangementDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangementDAL.Data.Configuration
{
    internal class GymUserConfiguration<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Name)//Name of the user
                .HasColumnType("varchar")
                .HasMaxLength(50);

            builder.Property(x => x.Name)//Email of the user
                .HasColumnType("varchar")
                .HasMaxLength(100);
            builder.HasIndex(x => x.Email)//Unique index on email to ensure uniqueness
                .IsUnique();

            builder.Property(x => x.Phone)//Phone of the user
              .HasColumnType("varchar")
              .HasMaxLength(11);
            builder.HasIndex(x => x.Phone)//Unique index on phone to ensure uniqueness
              .IsUnique();
            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("CK_Email", "Email LIKE '_%@_%._%'");
                tb.HasCheckConstraint("CK_Phone", "Phone LIKE '01%' AND Phone Not Like '%[^0-9]%'");
            });

            builder.OwnsOne(x => x.Address, AddressBuilder =>
            {
                AddressBuilder.Property(x=>x.Street)
                .HasColumnType("varchar")
                    .HasMaxLength(30)
                    .HasColumnName("Street");

                AddressBuilder.Property(x=>x.City)
                .HasColumnType("varchar")
                    .HasMaxLength(30)
                    .HasColumnName("City");

                AddressBuilder.Property(x=>x.BuildingNumber)
                    .HasColumnName("BuildingNumber");


            });





        }
    }
}
