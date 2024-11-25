using Microsoft.AspNetCore.Identity;
using TaskTest.Constants;
using TaskTest.Models;

namespace TaskTest.Data
{
    public class AdminSeeder
    {
            public static async Task SeedDefaultData(IServiceProvider service)
            {
                var userMgr = service.GetService<UserManager<User>>();
                var roleMgr = service.GetService<RoleManager<IdentityRole>>();

                string inputDate = "2024/10/15";

                DateOnly dateOnly = DateOnly.ParseExact(inputDate, "yyyy/MM/dd");

                string formattedDate = dateOnly.ToString("yyyy-MM-dd");

                DateOnly parsedDate = DateOnly.ParseExact(formattedDate, "yyyy-MM-dd");

                var admin = new User
                    {
                        Name = "Admin",
                        Surname = "Test",
                        UserName = "test@gmail.com",
                        Email = "test@gmail.com",
                        EmailConfirmed = true,
                        Gender = "male",
                        BirthDay = parsedDate,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                    };

                var isUserExists = await userMgr.FindByEmailAsync(admin.Email);

                if (isUserExists == null)
                {
                    await roleMgr.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
                    await roleMgr.CreateAsync(new IdentityRole(Roles.User.ToString()));
                    await roleMgr.CreateAsync(new IdentityRole(Roles.Company.ToString()));

                    await userMgr.CreateAsync(admin, "Admin1!");
                    await userMgr.AddToRoleAsync(admin, Roles.Admin.ToString());

                }
            }
        }
}
