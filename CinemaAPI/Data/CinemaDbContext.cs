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

    public virtual DbSet<Media> Media { get; set; }

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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer("Name=ConnectionStrings:DBConnect");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Actor>(entity =>
        {
            entity.HasKey(e => e.ActorId).HasName("PK__Actors__57B3EA2BFE3DA281");

            entity.Property(e => e.ActorId).HasColumnName("ActorID");
            entity.Property(e => e.ActorCountry).HasMaxLength(500).IsUnicode(false);
            entity.Property(e => e.ActorFullName).HasMaxLength(500).IsUnicode(false);
            entity.Property(e => e.ActorPhoto).IsUnicode(false);
        });

        modelBuilder.Entity<Director>(entity =>
        {
            entity.HasKey(e => e.DirectorId).HasName("PK__Director__26C69E26CC4528C4");

            entity.Property(e => e.DirectorId).HasColumnName("DirectorID");
            entity.Property(e => e.DirectorFullName).HasMaxLength(500).IsUnicode(false);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.GenreId).HasName("PK__Genres__0385055E275EB314");

            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.GenreName).HasMaxLength(200).IsUnicode(false);
        });

        modelBuilder.Entity<Hall>(entity =>
        {
            entity.HasKey(e => e.HallId).HasName("PK__Halls__7E60E27427FBB00B");

            entity.Property(e => e.HallId).HasColumnName("HallID");
            entity.Property(e => e.HallName).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.HallType).HasMaxLength(20).IsUnicode(false);
        });

        modelBuilder.Entity<Media>(entity =>
        {
            entity.HasKey(e => e.MediaId).HasName("PK__Media__B2C2B5AFF67EED97");

            entity.Property(e => e.MediaId).HasColumnName("MediaID");
            entity.Property(e => e.MovieDescription).HasMaxLength(4000).IsUnicode(false);
            entity.Property(e => e.MoviePhoto).IsUnicode(false);
            entity.Property(e => e.MovieTrailer).IsUnicode(false);
        });

        modelBuilder.Entity<Movie>(entity =>
        {
            entity.HasKey(e => e.MovieId).HasName("PK__Movies__4BD2943A4386AAF7");

            entity.Property(e => e.MovieId).HasColumnName("MovieID");
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
                .HasConstraintName("FK__Movies__MediaID__5EBF139D");
        });

        modelBuilder.Entity<MovieActor>(entity =>
        {
            entity.HasKey(e => e.MovieActorId).HasName("PK__Movie_Ac__0F76A5839445775C");

            entity.ToTable("Movie_Actor");

            entity.Property(e => e.MovieActorId).HasColumnName("MovieActorID");
            entity.Property(e => e.ActorId).HasColumnName("ActorID");
            entity.Property(e => e.ActorNickname).HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.MovieId).HasColumnName("MovieID");

            entity
                .HasOne(d => d.Actor)
                .WithMany(p => p.MovieActors)
                .HasForeignKey(d => d.ActorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Act__Actor__40F9A68C");

            entity
                .HasOne(d => d.Movie)
                .WithMany(p => p.MovieActors)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Act__Movie__40058253");
        });

        modelBuilder.Entity<MovieDirector>(entity =>
        {
            entity.HasKey(e => e.MovieDirectorId).HasName("PK__Movie_Di__AEB81F2EA77926CE");

            entity.ToTable("Movie_Director");

            entity.Property(e => e.MovieDirectorId).HasColumnName("MovieDirectorID");
            entity.Property(e => e.DirectorId).HasColumnName("DirectorID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");

            entity
                .HasOne(d => d.Director)
                .WithMany(p => p.MovieDirectors)
                .HasForeignKey(d => d.DirectorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Dir__Direc__7C4F7684");

            entity
                .HasOne(d => d.Movie)
                .WithMany(p => p.MovieDirectors)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Dir__Movie__7B5B524B");
        });

        modelBuilder.Entity<MovieGenre>(entity =>
        {
            entity.HasKey(e => e.MovieGenreId).HasName("PK__Movie_Ge__C18CDB603C2FCA98");

            entity.ToTable("Movie_Genre");

            entity.Property(e => e.MovieGenreId).HasColumnName("MovieGenreID");
            entity.Property(e => e.GenreId).HasColumnName("GenreID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");

            entity
                .HasOne(d => d.Genre)
                .WithMany(p => p.MovieGenres)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Gen__Genre__797309D9");

            entity
                .HasOne(d => d.Movie)
                .WithMany(p => p.MovieGenres)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Gen__Movie__787EE5A0");
        });

        modelBuilder.Entity<MovieScreenwriter>(entity =>
        {
            entity.HasKey(e => e.MovieScreenwriterId).HasName("PK__Movie_Sc__82D1508E39AA7AA5");

            entity.ToTable("Movie_Screenwriter");

            entity.Property(e => e.MovieScreenwriterId).HasColumnName("MovieScreenwriterID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.ScreenwriterId).HasColumnName("ScreenwriterID");

            entity
                .HasOne(d => d.Movie)
                .WithMany(p => p.MovieScreenwriters)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Scr__Movie__7E37BEF6");

            entity
                .HasOne(d => d.Screenwriter)
                .WithMany(p => p.MovieScreenwriters)
                .HasForeignKey(d => d.ScreenwriterId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movie_Scr__Scree__7F2BE32F");
        });

        modelBuilder.Entity<MovieSession>(entity =>
        {
            entity.HasKey(e => e.MovieSessionId).HasName("PK__MovieSes__111D7676E2ECBEA2");

            entity.Property(e => e.MovieSessionId).HasColumnName("MovieSessionID");
            entity.Property(e => e.HallId).HasColumnName("HallID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");
        });

        modelBuilder.Entity<Price>(entity =>
        {
            entity.HasKey(e => e.PriceId).HasName("PK__Prices__4957584F39BDA733");

            entity.Property(e => e.PriceId).HasColumnName("PriceID");
            entity.Property(e => e.MovieId).HasColumnName("MovieID");
            entity.Property(e => e.Price1).HasColumnName("Price");
            entity.Property(e => e.SeatReservationId).HasColumnName("SeatReservationID");

            entity
                .HasOne(d => d.Movie)
                .WithMany(p => p.Prices)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prices__MovieID__08B54D69");

            entity
                .HasOne(d => d.SeatReservation)
                .WithMany(p => p.Prices)
                .HasForeignKey(d => d.SeatReservationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Prices__SeatRese__09A971A2");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F04E38B53B9");

            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
            entity.Property(e => e.MovieSessionId).HasColumnName("MovieSessionID");
            entity.Property(e => e.PriceId).HasColumnName("PriceID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity
                .HasOne(d => d.MovieSession)
                .WithMany(p => p.Reservations)
                .HasForeignKey(d => d.MovieSessionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__Movie__151B244E");

            entity
                .HasOne(d => d.Price)
                .WithMany(p => p.Reservations)
                .HasForeignKey(d => d.PriceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__Price__160F4887");

            entity
                .HasOne(d => d.User)
                .WithMany(p => p.Reservations)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Reservati__UserI__14270015");
        });

        modelBuilder.Entity<Screenwriter>(entity =>
        {
            entity.HasKey(e => e.ScreenwriterId).HasName("PK__Screenwr__6443CA5CD0AAC42B");

            entity.Property(e => e.ScreenwriterId).HasColumnName("ScreenwriterID");
            entity.Property(e => e.ScreenwriterFullName).HasMaxLength(500).IsUnicode(false);
        });

        modelBuilder.Entity<SeatReservation>(entity =>
        {
            entity.HasKey(e => e.SeatReservationId).HasName("PK__SeatRese__978A96BA9E203F35");

            entity.ToTable("SeatReservation");

            entity.Property(e => e.SeatReservationId).HasColumnName("SeatReservationID");
            entity.Property(e => e.HallId).HasColumnName("HallID");

            entity
                .HasOne(d => d.Hall)
                .WithMany(p => p.SeatReservations)
                .HasForeignKey(d => d.HallId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SeatReser__HallI__04E4BC85");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC83CA5DEC");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.IsActive).HasDefaultValue(false).HasColumnName("isActive");
            entity.Property(e => e.Token).HasMaxLength(50).IsUnicode(false);
            entity.Property(e => e.UserEmail).HasMaxLength(200).IsUnicode(false);
            entity.Property(e => e.UserName).HasMaxLength(200).IsUnicode(false);
            entity.Property(e => e.UserPassword).HasMaxLength(200).IsUnicode(false);
            entity.Property(e => e.UserRole).HasMaxLength(50).IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
