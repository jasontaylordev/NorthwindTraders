using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Northwind.Application.Common.Interfaces;

namespace Northwind.Infrastructure.Identity
{
    public class UserManagerService : IUserManager
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserManagerService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> CreateUserAsync(string userName, string password)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email = userName,
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                return user.Id;
            }

            return null;
        }
    }
}
