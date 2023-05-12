﻿using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class RecruitingDbContext: DbContext
    {
        public RecruitingDbContext(DbContextOptions<RecruitingDbContext> options) : base(options)
        {

        }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<JobStatusLookUp> JobStatusLookUps { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // I can use this method to do fluent API way to do any schema changes just like Data
            modelBuilder.Entity<Candidate>(ConfigureCandidate);
            // Action<EntityTypeBuilder<TEntity>> buildAction
            
        }

        private void ConfigureCandidate(EntityTypeBuilder<Candidate> builder)
        {
            // we can establish the rule for the candidate table
            builder.HasKey(c => c.Id);
            builder.Property(c => c.FirstName).HasMaxLength(100);
            builder.HasIndex(c => c.Email).IsUnique();
            builder.Property(c => c.CreatedOn).HasDefaultValueSql("getdate()");
        }
    }
}
