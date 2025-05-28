using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreeStructure.DAL.Entities;

namespace TreeStructure.DAL.Configurations;

public class TreeConfiguration : IEntityTypeConfiguration<Tree>
{
    public void Configure(EntityTypeBuilder<Tree> builder)
    {
        builder.HasKey(t => t.Id);

        builder.Property(t => t.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasMany(t => t.Nodes)
            .WithOne(n => n.Tree)
            .HasForeignKey(n => n.TreeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(t => t.Name)
            .IsUnique();
    }
}