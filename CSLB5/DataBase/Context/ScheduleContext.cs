using System;
using System.Collections.Generic;
using CSLB5.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace CSLB5.DataBase.Context;

public partial class ScheduleContext : DbContext
{
    public ScheduleContext()
    {
    }

    public ScheduleContext(DbContextOptions<ScheduleContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Classroom> Classrooms { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Lecture> Lectures { get; set; }

    public virtual DbSet<Sсhedule> Sсhedules { get; set; }

    public virtual DbSet<Tutor> Tutors { get; set; }

    public virtual DbSet<TypesOfLecture> TypesOfLectures { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Classroom>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ClassroomID");
            entity.Property(e => e.Letter).HasColumnType("TEXT (1)");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("GroupID");
            entity.Property(e => e.GroupNumber).HasColumnType("TEXT (24)");
        });

        modelBuilder.Entity<Lecture>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("LectureID");
            entity.Property(e => e.Name).HasColumnType("TEXT (45)");
        });

        modelBuilder.Entity<Sсhedule>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Abbrevation).HasColumnType("TEXT (5)");
            entity.Property(e => e.ClassroomId).HasColumnName("ClassroomID");
            entity.Property(e => e.GroupId).HasColumnName("GroupID");
            entity.Property(e => e.LectureId).HasColumnName("LectureID");
            entity.Property(e => e.TutorId).HasColumnName("TutorID");

            entity.HasOne(d => d.AbbrevationNavigation).WithMany()
                .HasForeignKey(d => d.Abbrevation)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Classroom).WithMany()
                .HasForeignKey(d => d.ClassroomId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Group).WithMany()
                .HasForeignKey(d => d.GroupId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Lecture).WithMany()
                .HasForeignKey(d => d.LectureId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Tutor).WithMany()
                .HasForeignKey(d => d.TutorId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Tutor>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("TutorID");
            entity.Property(e => e.Name).HasColumnType("TEXT (16)");
            entity.Property(e => e.Patronimic).HasColumnType("TEXT (16)");
            entity.Property(e => e.Surname).HasColumnType("TEXT (16)");
        });

        modelBuilder.Entity<TypesOfLecture>(entity =>
        {
            entity.HasKey(e => e.Abbrevation);

            // entity.ToTable("TypesOfLecture");

            entity.Property(e => e.Abbrevation).HasColumnType("TEXT (5)");
            entity.Property(e => e.Name).HasColumnType("TEXT (16)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
