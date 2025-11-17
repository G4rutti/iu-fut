using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IU_FUT.Models;

public partial class iufutContext : DbContext
{
    public iufutContext()
    {
    }

    public iufutContext(DbContextOptions<iufutContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Campo> Campos { get; set; }

    public virtual DbSet<Jogador> Jogadors { get; set; }

    public virtual DbSet<Partidum> Partida { get; set; }

    public virtual DbSet<Time> Times { get; set; }

    public virtual DbSet<TimePartidum> TimePartida { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=iu-fut;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Campo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Campo__3214EC07EAC99909");

            entity.ToTable("Campo");

            entity.Property(e => e.Cidade)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Endereco)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Jogador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Jogador__3214EC07DCDDAA90");

            entity.ToTable("Jogador");

            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Posicao)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(255)
                .IsUnicode(false);

            // RN02: E-mail deve ser único no sistema
            entity.HasIndex(e => e.Email)
                .IsUnique()
                .HasDatabaseName("IX_Jogador_Email");

            entity.HasOne(d => d.IdTimeNavigation).WithMany(p => p.Jogadors)
                .HasForeignKey(d => d.IdTime)
                .HasConstraintName("FK__Jogador__IdTime__3E52440B");
        });

        modelBuilder.Entity<Partidum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Partida__3214EC07484E589A");

            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Campo).WithMany(p => p.Partida)
                .HasForeignKey(d => d.Campo_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Partida__Campo_I__3B75D760");
        });

        modelBuilder.Entity<Time>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Time__3214EC0796C2DC09");

            entity.ToTable("Time");

            entity.Property(e => e.Descricao)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TimePartidum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TimePart__3214EC079B98B58D");

            entity.HasOne(d => d.Partida).WithMany(p => p.TimePartida)
                .HasForeignKey(d => d.Partida_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TimeParti__Parti__4222D4EF");

            entity.HasOne(d => d.Time).WithMany(p => p.TimePartida)
                .HasForeignKey(d => d.Time_Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TimeParti__Time___412EB0B6");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
