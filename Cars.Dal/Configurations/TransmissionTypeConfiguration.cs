using Cars.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cars.Dal.Configurations
{
    public class TransmissionTypeConfiguration : IEntityTypeConfiguration<TransmissionType>
    {
        public void Configure(EntityTypeBuilder<TransmissionType> builder)
        {
            builder.ToTable("TransmissionTypes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();
        }
    }
}
