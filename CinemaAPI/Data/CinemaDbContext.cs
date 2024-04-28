using System;
using System.Collections.Generic;
using CinemaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Data;

public partial class CinemaDbContext : DbContext
{
    public CinemaDbContext() { }

    public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
        : base(options) { }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Hall> Halls { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieActor> MovieActors { get; set; }

    public virtual DbSet<MovieDirector> MovieDirectors { get; set; }

    public virtual DbSet<MovieGenre> MovieGenres { get; set; }

    public virtual DbSet<MoviePrice> MoviePrices { get; set; }

    public virtual DbSet<MovieScreenwriter> MovieScreenwriters { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Screenwriter> Screenwriters { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.ActorId).HasName("PK__Actors__57B3EA2B8BDC9A09");

            entity.Property(e => e.ActorId).HasColumnName("ActorID");
            entity.Property(e => e.ActorCountry).HasMaxLength(500).IsUnicode(false);
            entity.Property(e => e.ActorFullName).HasMaxLength(500).IsUnicode(false);
        });

        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.DirectorId).HasName("PK__Director__26C69E261416777A");

            entity.Property(e => e.DirectorId).ValueGeneratedNever().HasColumnName("DirectorID");
            entity.Property(e => e.DirectorFullName).HasMaxLength(500).IsUnicode(false);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genres__0385055E31D48BDA");

            entity.Property(e => e.GenreId).ValueGeneratedNever().HasColumnName("GenreID");
            entity.Property(e => e.GenreName).HasMaxLength(200).IsUnicode(false);
        });

        modelBuilder.Entity<Hall>(entity =>
        {
            entity.HasKey(e => e.HallId).HasName("PK__Halls__7E60E274316C66A5");

            entity.Property(e => e.HallId).ValueGeneratedNever().HasColumnName("HallID");
            entity.Property(e => e.HallName).HasMaxLength(200).IsUnicode(false);
            entity.Property(e => e.HallType).HasMaxLength(20).IsUnicode(false);
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.HasKey(e => e.MediaId).HasName("PK__Media__B2C2B5AFD49F1F08");

            entity.Property(e => e.MediaId).ValueGeneratedNever().HasColumnName("MediaID");
            entity.Property(e => e.MovieDescription).HasMaxLength(4000).IsUnicode(false);
            entity.Property(e => e.MovieTrailer).IsUnicode(false);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__Movies__4BD2943AF496558D");

            entity.Property(e => e.MovieId).ValueGeneratedNever().HasColumnName("MovieID");
            entity.Property(e => e.Country).HasColumnType("text");
            entity.Property(e => e.Limitations).HasMaxLength(10).IsUnicode(false);
            entity.Property(e => e.MediaId).HasColumnName("MediaID");
            entity.Property(e => e.MovieTitle).HasMaxLength(255).IsUnicode(false);
            entity.Property(e => e.Rating).HasMaxLength(50).IsUnicode(false);

            entity
                .HasOne(d => d.Media)
                .WithMany(p => p.Movies)
                .HasForeignKey(d => d.MediaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movies__MediaID__4E88ABD4");
        });

        modelBuilder.Entity<MovieActor>(entity =>
        {
            entity.HasNoKey().ToTable("Movie_Actor");

            entity.Property(e => e.ActorId).HasColumnName("ActorID");
            entity.Property(e => e.ActorNickname).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.MovieId).HasColumnName("MovieID");

            entity
                .HasOne(d => d.Actor)
                .WithMany()
                .HasForeignKey(d => d.ActorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Act__Actor__46E78A0C");

            entity
                .HasOne(d => d.Movie)
                .WithMany()
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Act__Movie__47DBAE45");
        });

        modelBuilder.Entity<MovieDirector>(entity =>
        {
            entity.HasNoKey().ToTable("Movie_Director");

            entity.Property(e => e.DirectorId).HasColumnName("DirectorID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");

            entity
                .HasOne(d => d.Director)
                .WithMany()
                .HasForeignKey(d => d.DirectorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Dir__Direc__48CFD27E");

            entity
                .HasOne(d => d.Movie)
                .WithMany()
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Dir__Movie__49C3F6B7");
        });

        modelBuilder.Entity<MovieGenre>(entity =>
        {
            entity.HasNoKey().ToTable("Movie_Genre");

            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");

            entity
                .HasOne(d => d.Genre)
                .WithMany()
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Gen__Genre__4AB81AF0");

            entity
                .HasOne(d => d.Movie)
                .WithMany()
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Gen__Movie__4BAC3F29");
        });

        modelBuilder.Entity<MoviePrice>(entity =>
        {
            entity.HasNoKey().ToTable("Movie_Price");

            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.PriceId).HasColumnName("PriceID");

            entity
                .HasOne(d => d.Movie)
                .WithMany()
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Pri__Movie__0A9D95DB");

            entity
                .HasOne(d => d.Price)
                .WithMany()
                .HasForeignKey(d => d.PriceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Pri__Price__0B91BA14");
        });

        modelBuilder.Entity<MovieScreenwriter>(entity =>
        {
            entity.HasNoKey().ToTable("Movie_Screenwriter");

            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.ScreenwriterId).HasColumnName("ScreenwriterID");

            entity
                .HasOne(d => d.Movie)
                .WithMany()
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Scr__Movie__4CA06362");

            entity
                .HasOne(d => d.Screenwriter)
                .WithMany()
                .HasForeignKey(d => d.ScreenwriterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Scr__Scree__4D94879B");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.PriceId).HasName("PK__Prices__4957584F3CDC8816");

            entity.Property(e => e.PriceId).ValueGeneratedNever().HasColumnName("PriceID");
            entity.Property(e => e.HallId).HasColumnName("HallID");
            entity.Property(e => e.Price1).HasColumnName("Price");

            entity
                .HasOne(d => d.Hall)
                .WithMany(p => p.Prices)
                .HasForeignKey(d => d.HallId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prices__HallID__08B54D69");
        });

        modelBuilder.Entity<Screenwriter>(entity =>
        {
            entity.HasKey(e => e.ScreenwriterId).HasName("PK__Screenwr__6443CA5CA8E6B847");

            entity
                .Property(e => e.ScreenwriterId)
                .ValueGeneratedNever()
                .HasColumnName("ScreenwriterID");
            entity.Property(e => e.ScreenwriterFullName).HasMaxLength(500).IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3213E83FB06D3CC0");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email).HasMaxLength(255).IsUnicode(false).HasColumnName("email");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Name).HasMaxLength(255).IsUnicode(false).HasColumnName("name");
            entity
                .Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role).HasMaxLength(50).IsUnicode(false).HasColumnName("role");
            entity.Property(e => e.Token).HasMaxLength(100).IsUnicode(false).HasColumnName("token");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
