using Cars.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cars.Dal.Configurations
{
    public class SpesificationConfiguration : IEntityTypeConfiguration<Spesification>
    {
        public void Configure(EntityTypeBuilder<Spesification> builder)
        {
            builder.ToTable("Spesifications");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
        }
    }
}
