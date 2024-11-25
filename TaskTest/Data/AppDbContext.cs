using TaskTest.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Drawing;


namespace TaskTest.Data
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
        {
            
        }
        public DbSet<TaskCategories> Categories { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<ProgrammingLanguages> ProgrammingLanguages { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Solutions> Solutions { get; set; }
        public DbSet<TaskImages> TaskImages { get; set; }
        public DbSet<Tests> Tests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Solutions>()
                .HasOne(o => o.Task)
                .WithMany(c => c.Solutions)
                .HasForeignKey(o => o.TaskId)
                .OnDelete(DeleteBehavior.NoAction); // Prevents cascading deletes

            modelBuilder.Entity<Tests>()
              .HasOne(o => o.Task)
              .WithMany(c => c.Tests)
              .HasForeignKey(o => o.TaskId)
              .OnDelete(DeleteBehavior.NoAction); // Prevents cascading deletes

            base.OnModelCreating(modelBuilder); // Important to call base here for Identity configuration

        }


        /*
                protected override void OnModelCreating(ModelBuilder modelBuilder)
                {
                    base.OnModelCreating(modelBuilder);

                    string password = "222aA!";
                    byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes

                    string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                            password: password!,
                            salt: salt,
                            prf: KeyDerivationPrf.HMACSHA256,
                            iterationCount: 100000,
                            numBytesRequested: 256 / 8));

                    DateOnly dateOnly = DateOnly.FromDateTime(DateTime.Now); // Get the current date


                    modelBuilder.Entity<User>(b =>
                    {
                        b.Property(x => x.Name).IsRequired();
                        b.HasData(

                            new User { 
                                Name = "Admin",
                                Surname = "Admin",
                                Email = "test@gmail.com",
                                EmailConfirmed = true,
                                Password = "222aA!",
                                PasswordHash = hashed,
                                Gender = "male",
                                BirthDay = dateOnly
                            }
                );

                    });

                }
        */
    }
}
