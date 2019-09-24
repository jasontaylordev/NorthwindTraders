using System.Threading.Tasks;

namespace Northwind.Application.Common.Interfaces
{
    public interface IUserManager
    {
        Task<string> CreateUserAsync(string userName, string password);
    }
}
