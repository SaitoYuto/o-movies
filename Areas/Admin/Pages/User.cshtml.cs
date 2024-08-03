using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace OMovies.Areas.Admin.Pages
{
    [Authorize(Roles = "Admin")]
    public class UserModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserModel(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public class UserWithRoles
        {
            public IdentityUser User { get; set; }
            public IList<string> Roles { get; set; }
        }

        public List<UserWithRoles> UsersWithRoles { get; set; }

        public async Task OnGetAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            UsersWithRoles = new List<UserWithRoles>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                UsersWithRoles.Add(new UserWithRoles
                {
                    User = user,
                    Roles = roles
                });
            }
        }
    }
}