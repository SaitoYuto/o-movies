using Microsoft.AspNetCore.Identity;

public class RoleInitializer
{
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

        string[] roleNames = { "Admin", "User" };
        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
        }

        var configuration = serviceProvider.GetRequiredService<IConfiguration>();

        var adminUser = await userManager.FindByEmailAsync(configuration["Admin:Email"]);
        if (adminUser == null)
        {
            adminUser = new IdentityUser
            {
                UserName = configuration["Admin:Name"],
                Email = configuration["Admin:Email"],
                EmailConfirmed = true 
            };
            await userManager.CreateAsync(adminUser, configuration["Admin:Password"]);
        }
        
        if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }
    }
}