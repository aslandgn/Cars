using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Version = Cars.Entity.Entities.Version;

namespace Cars.Dal.Configurations
{
    public class VersionConfiguration : IEntityTypeConfiguration<Version>
    {
        public void Configure(EntityTypeBuilder<Version> builder)
        {
            builder.ToTable("Versions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ModelId).IsRequired();
            builder.Property(x => x.TransmissionTypeId).IsRequired();
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();

            builder
                .HasOne(p => p.Model)
                .WithMany(b => b.Versions)
                .HasForeignKey(p => p.ModelId);

            builder
                .HasOne(p => p.TransmissionType)
                .WithMany(b => b.Versions)
                .HasForeignKey(p => p.TransmissionTypeId);
        }
    }
}
