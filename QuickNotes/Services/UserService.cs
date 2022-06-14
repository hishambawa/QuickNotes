using System;
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

        public async Task<int> Login(User User)
        {
            List<User> Users = _context.Users.ToList();

            foreach (User U in Users)
            {
                if (U.Username.Equals(User.Username))
                {
                    return 1;
                }
            }

            User NewUser = new User(Users.Count, User.Username);

            _context.Add(NewUser);
            await _context.SaveChangesAsync();

            return 2;
        }
    }
}

