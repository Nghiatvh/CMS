using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using As2.Models;
using As2.Data;

namespace As2.Data
{
	public class CMSContext : DbContext
	{

		public DbSet<Admin> Admins { get; set; }
		public DbSet<Categories> Categories { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<Topic> Topics { get; set; }
		public DbSet<Trainee> Trainees { get; set; }
		public DbSet<TraineeCourse> TraineeCourses { get; set; }
		public DbSet<Trainer> Trainers { get; set; }
		public DbSet<TrainerTopic> TrainerTopics { get; set; }
		public DbSet<TrainingStaff> TrainingStaffs { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=CMS;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
		}




		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TrainerTopic>().HasKey(tt => new { tt.TrainerID, tt.TopicID });

			modelBuilder.Entity<TrainerTopic>()
				.HasOne<Trainer>(tt => tt.Trainer)
				.WithMany(s => s.TrainerTopics)
				.HasForeignKey(tt => tt.TrainerID);

			modelBuilder.Entity<TrainerTopic>()
				.HasOne<Topic>(tt => tt.Topic)
				.WithMany(s => s.TrainerTopics)
				.HasForeignKey(tt => tt.TopicID);

			modelBuilder.Entity<TraineeCourse>().HasKey(tc => new { tc.TraineeID, tc.CourseID });

			modelBuilder.Entity<TraineeCourse>()
				.HasOne<Trainee>(tc => tc.Trainee)
				.WithMany(s => s.TraineeCourses)
				.HasForeignKey(tc => tc.TraineeID);

			modelBuilder.Entity<TraineeCourse>()
				.HasOne<Course>(tc => tc.Course)
				.WithMany(s => s.TraineeCourses)
				.HasForeignKey(tc => tc.CourseID);
		}
	}
}