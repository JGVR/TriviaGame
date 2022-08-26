using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AppDomain.Models
{
    public partial class TriviaQuestionsContext : DbContext
    {
        public TriviaQuestionsContext()
        {
        }

        public TriviaQuestionsContext(DbContextOptions<TriviaQuestionsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Triviaanswer> Triviaanswers { get; set; } = null!;
        public virtual DbSet<Triviaquestion> Triviaquestions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=TriviaQuestions;Username=juanvasquez;Password=Locoloco02");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Triviaanswer>(entity =>
            {
                entity.ToTable("triviaanswers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Answer)
                    .HasMaxLength(25)
                    .HasColumnName("answer");

                entity.Property(e => e.Points).HasColumnName("points");

                entity.Property(e => e.Questionid).HasColumnName("questionid");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Triviaanswers)
                    .HasForeignKey(d => d.Questionid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("triviaanswers_questionid_fkey");
            });

            modelBuilder.Entity<Triviaquestion>(entity =>
            {
                entity.ToTable("triviaquestions");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Answer)
                    .HasMaxLength(25)
                    .HasColumnName("answer");

                entity.Property(e => e.Difficulty).HasColumnName("difficulty");

                entity.Property(e => e.Point).HasColumnName("point");

                entity.Property(e => e.Question)
                    .HasMaxLength(250)
                    .HasColumnName("question");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
