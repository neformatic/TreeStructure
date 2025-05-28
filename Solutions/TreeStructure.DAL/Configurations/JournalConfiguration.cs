using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreeStructure.DAL.Entities;

namespace TreeStructure.DAL.Configurations;

public class JournalConfiguration : IEntityTypeConfiguration<Journal>
{
    public void Configure(EntityTypeBuilder<Journal> builder)
    {
        builder.HasKey(j => j.Id);

        builder.Property(j => j.EventId)
            .IsRequired();

        builder.Property(j => j.CreatedAt)
            .IsRequired();

        builder.Property(j => j.Text)
            .HasColumnType("text");

        builder.Property(j => j.Parameters)
            .HasColumnType("text");

        builder.Property(j => j.StackTrace)
            .HasColumnType("text");
    }
}