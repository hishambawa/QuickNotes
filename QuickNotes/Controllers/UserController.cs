using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using QuickNotes.DTO;
using QuickNotes.Models;
using QuickNotes.Services;

namespace QuickNotes.Controllers
{
    [ApiController]
    [EnableCors]
    [Route("api/[controller]")]
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService _userService)
        {
            this._userService = _userService;
        }

        [HttpPost]
        public async Task<Response> Login(User User)
        {
            return await _userService.Login(User);
        }
    }
}

