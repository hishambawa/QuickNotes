using QuickNotes.Models;

namespace QuickNotes.Services
{
    public interface IUserService
    {
        Task<int> Login(User User);
    }
}

