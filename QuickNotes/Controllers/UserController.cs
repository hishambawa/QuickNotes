using System;
using Microsoft.AspNetCore.Mvc;
using QuickNotes.Models;
using QuickNotes.Services;

namespace QuickNotes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        public async Task<int> Login(User User)
        {
            return await _userService.Login(User);
        }
    }
}

