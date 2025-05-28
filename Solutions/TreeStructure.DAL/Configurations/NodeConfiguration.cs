using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TreeStructure.DAL.Entities;

namespace TreeStructure.DAL.Configurations;

public class NodeConfiguration : IEntityTypeConfiguration<Node>
{
    public void Configure(EntityTypeBuilder<Node> builder)
    {
        builder.HasKey(n => n.Id);

        builder.Property(n => n.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasIndex(n => new { n.ParentId, n.Name })
            .IsUnique();

        builder.HasOne(n => n.Parent)
            .WithMany(n => n.Children)
            .HasForeignKey(n => n.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(n => n.Tree)
            .WithMany(t => t.Nodes)
            .HasForeignKey(n => n.TreeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}