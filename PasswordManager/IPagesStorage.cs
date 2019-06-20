using System.Threading.Tasks;

namespace PasswordManager
{
    public interface IPagesStorage
    {
        Task<bool> AddAsync(Page page);
    }
}