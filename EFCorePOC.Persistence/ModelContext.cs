using EFCorePOC.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCorePOC.Persistence;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Subscriber> Subscribers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseOracle("Name=ConnectionStrings:Oracle");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("FLORIN")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Subscriber>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("SUB_PK");

            entity.ToTable("SUBSCRIBERS");

            entity.Property(e => e.Id)
                .HasColumnType("NUMBER")
                .HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NAME");
            entity.Property(e => e.Subscribed)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("SUBSCRIBED");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
