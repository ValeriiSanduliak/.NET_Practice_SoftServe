using System;
using System.Collections.Generic;
using CinemaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Data;

public partial class CinemaDbContext : DbContext
{
    public CinemaDbContext()
    {
    }

    public CinemaDbContext(DbContextOptions<CinemaDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Actor> Actors { get; set; }

    public virtual DbSet<Director> Directors { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Hall> Halls { get; set; }

    public virtual DbSet<Medium> Media { get; set; }

    public virtual DbSet<Movie> Movies { get; set; }

    public virtual DbSet<MovieActor> MovieActors { get; set; }

    public virtual DbSet<MovieDirector> MovieDirectors { get; set; }

    public virtual DbSet<MovieGenre> MovieGenres { get; set; }

    public virtual DbSet<MovieScreenwriter> MovieScreenwriters { get; set; }

    public virtual DbSet<MovieSession> MovieSessions { get; set; }

    public virtual DbSet<Price> Prices { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Screenwriter> Screenwriters { get; set; }

    public virtual DbSet<SeatReservation> SeatReservations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DBConnect");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.ActorId).HasName("PK__Actors__57B3EA2B507FE6EB");

            entity.Property(e => e.ActorId).HasColumnName("ActorID");
            entity.Property(e => e.ActorCountry)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ActorFullName)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.ActorPhoto).IsUnicode(false);
        });

        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.DirectorId).HasName("PK__Director__26C69E26BDEBA6D2");

            entity.Property(e => e.DirectorId).HasColumnName("DirectorID");
            entity.Property(e => e.DirectorFullName)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genres__0385055EFE3B192E");

            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.GenreName)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Hall>(entity =>
        {
            entity.HasKey(e => e.HallId).HasName("PK__Halls__7E60E27407FCA8C1");

            entity.Property(e => e.HallId).HasColumnName("HallID");
            entity.Property(e => e.HallName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.HallType)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Medium>(entity =>
        {
            entity.HasKey(e => e.MediaId).HasName("PK__Media__B2C2B5AF9E059215");

            entity.Property(e => e.MediaId).HasColumnName("MediaID");
            entity.Property(e => e.MovieDescription)
                .HasMaxLength(4000)
                .IsUnicode(false);
            entity.Property(e => e.MoviePhoto).IsUnicode(false);
            entity.Property(e => e.MovieTrailer).IsUnicode(false);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__Movies__4BD2943AB7294EF7");

            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.Country).HasColumnType("text");
            entity.Property(e => e.Limitations)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.MediaId).HasColumnName("MediaID");
            entity.Property(e => e.MovieTitle)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Rating)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Media).WithMany(p => p.Movies)
                .HasForeignKey(d => d.MediaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movies__MediaID__40F9A68C");
        });

        modelBuilder.Entity<MovieActor>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Movie_Actor");

            entity.Property(e => e.ActorId).HasColumnName("ActorID");
            entity.Property(e => e.ActorNickname)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MovieId).HasColumnName("MovieID");

            entity.HasOne(d => d.Actor).WithMany()
                .HasForeignKey(d => d.ActorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Act__Actor__4D5F7D71");

            entity.HasOne(d => d.Movie).WithMany()
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Act__Movie__4C6B5938");
        });

        modelBuilder.Entity<MovieDirector>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Movie_Director");

            entity.Property(e => e.DirectorId).HasColumnName("DirectorID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");

            entity.HasOne(d => d.Director).WithMany()
                .HasForeignKey(d => d.DirectorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Dir__Direc__531856C7");

            entity.HasOne(d => d.Movie).WithMany()
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Dir__Movie__5224328E");
        });

        modelBuilder.Entity<MovieGenre>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Movie_Genre");

            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");

            entity.HasOne(d => d.Genre).WithMany()
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Gen__Genre__55F4C372");

            entity.HasOne(d => d.Movie).WithMany()
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Gen__Movie__55009F39");
        });

        modelBuilder.Entity<MovieScreenwriter>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Movie_Screenwriter");

            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.ScreenwriterId).HasColumnName("ScreenwriterID");

            entity.HasOne(d => d.Movie).WithMany()
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Scr__Movie__4F47C5E3");

            entity.HasOne(d => d.Screenwriter).WithMany()
                .HasForeignKey(d => d.ScreenwriterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Scr__Scree__503BEA1C");
        });

        modelBuilder.Entity<MovieSession>(entity =>
        {
            entity.HasKey(e => e.MovieSessionId).HasName("PK__MovieSes__111D7676F7950AF0");

            entity.Property(e => e.MovieSessionId).HasColumnName("MovieSessionID");
            entity.Property(e => e.HallId).HasColumnName("HallID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");

            entity.HasOne(d => d.Hall).WithMany(p => p.MovieSessions)
                .HasForeignKey(d => d.HallId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("HallID");

            entity.HasOne(d => d.Movie).WithMany(p => p.MovieSessions)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovieSessions_MovieID");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.PriceId).HasName("PK__Prices__4957584F020297C1");

            entity.Property(e => e.PriceId).HasColumnName("PriceID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.Price1).HasColumnName("Price");
            entity.Property(e => e.SeatReservationId).HasColumnName("SeatReservationID");

            entity.HasOne(d => d.Movie).WithMany(p => p.Prices)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prices__MovieID__681373AD");

            entity.HasOne(d => d.SeatReservation).WithMany(p => p.Prices)
                .HasForeignKey(d => d.SeatReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prices__SeatRese__690797E6");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F0457A9201A");

            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
            entity.Property(e => e.MovieSessionId).HasColumnName("MovieSessionID");
            entity.Property(e => e.PriceId).HasColumnName("PriceID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.MovieSession).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.MovieSessionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__Movie__0C50D423");

            entity.HasOne(d => d.Price).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.PriceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__Price__0D44F85C");

            entity.HasOne(d => d.User).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__UserI__0B5CAFEA");
        });

        modelBuilder.Entity<Screenwriter>(entity =>
        {
            entity.HasKey(e => e.ScreenwriterId).HasName("PK__Screenwr__6443CA5C47B050A9");

            entity.Property(e => e.ScreenwriterId).HasColumnName("ScreenwriterID");
            entity.Property(e => e.ScreenwriterFullName)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<SeatReservation>(entity =>
        {
            entity.HasKey(e => e.SeatReservationId).HasName("PK__SeatRese__978A96BAE0B2B1DF");

            entity.ToTable("SeatReservation");

            entity.Property(e => e.SeatReservationId).HasColumnName("SeatReservationID");
            entity.Property(e => e.HallId).HasColumnName("HallID");

            entity.HasOne(d => d.Hall).WithMany(p => p.SeatReservations)
                .HasForeignKey(d => d.HallId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SeatReser__HallI__6442E2C9");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__3213E83FB06D3CC0");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("role");
            entity.Property(e => e.Token)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("token");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
