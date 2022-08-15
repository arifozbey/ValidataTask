using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidataTask.Entity;

namespace InfrastructureLayer.Mappings
{
    public class ValidataMap : IEntityTypeConfiguration<ValidataEntity>
    {
        public void Configure(EntityTypeBuilder<ValidataEntity> builder)
        {

            builder.ToTable("ValidataEntity");

            builder.Property(p => p.Id)
                .ValueGeneratedNever();
            builder.Property(p => p.OrderId).IsRequired(false);
            builder.Property(p => p.PostalCode).IsRequired(false);

            builder.Property(p => p.Name)
                .HasColumnType("varchar(255)");

            //Referenace
            builder.HasOne(x => x.Order).WithMany().HasForeignKey(b => b.OrderId)
    .OnDelete(DeleteBehavior.Cascade).IsRequired(false);

            builder.HasData(
new ValidataEntity { Id = 1, Name = "Andriy", Date = DateTime.Now.AddDays(-2), Adress = "Test", LastName = "Ozbey", Number = 3, PostalCode = 123 },
new ValidataEntity { Id = 3, Name = "Oyku", Date = DateTime.Now.AddDays(-1), Adress = "Test", LastName = "Ozbey", Number = 3, PostalCode = 123 },
new ValidataEntity { Id = 2, Name = "Arif", Date = DateTime.Now, Adress = "Test", LastName = "Ozbey", Number = 3, PostalCode = 123 });


        }
    }
}
