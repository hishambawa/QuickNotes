using QuickNotes.DTO;
using QuickNotes.Models;

namespace QuickNotes.Services
{
    public interface IUserService
    {
        Task<Response> Login(User User);
    }
}

