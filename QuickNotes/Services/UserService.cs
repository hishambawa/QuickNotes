using QuickNotes.DTO;
using QuickNotes.Models;

namespace QuickNotes.Services
{
    public class UserService : IUserService
    {
        private readonly NotesDbContext _context;

        public UserService()
        {
            _context = new NotesDbContext();
            _context.Database.EnsureCreated();
        }

        public async Task<Response> Login(User User)
        {
            User ExistingUser = _context.Users.FirstOrDefault(e => e.Username.Equals(User.Username));

            if (ExistingUser != null)
            {
                return new Response(1, ExistingUser.UserId, "User exists. Logging in");
            }

            User NewUser = new User(User.Username);

            _context.Add(NewUser);
            await _context.SaveChangesAsync();

            return new Response(1, NewUser.UserId, "User doesn't exist. Creating new user");
        }
    }
}

