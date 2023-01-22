using Cars.Entity.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cars.Dal.Configurations
{
    public class VersionSpesificationConfiguration : IEntityTypeConfiguration<VersionSpesification>
    {
        public void Configure(EntityTypeBuilder<VersionSpesification> builder)
        {
            builder.ToTable("VersionSpesifications");
            builder.HasKey(x => new { x.VersionId, x.SpesificationId });
            builder.Property(x => x.IsActive).IsRequired();
            builder.Property(x => x.IsDeleted).IsRequired();

            builder
                .HasOne(p => p.Spesification)
                .WithMany(b => b.VersionSpesifications)
                .HasForeignKey(p => p.SpesificationId);

            builder
                .HasOne(p => p.Version)
                .WithMany(b => b.VersionSpesifications)
                .HasForeignKey(p => p.VersionId);
        }
    }
}
