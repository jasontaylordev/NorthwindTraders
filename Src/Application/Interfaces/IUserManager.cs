using System.Threading.Tasks;

namespace Northwind.Application.Interfaces
{
    public interface IUserManager
    {
        Task<string> CreateUserAsync(string userName, string password);
    }
}
