using HealthyCook_Backend.Domain.IServices;
using HealthyCook_Backend.Domain.Models;
using HealthyCook_Backend.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyCook_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            try
            {
                var validateExistence = await _userService.ValidateExistence(user);
                if (validateExistence)
                {
                    return BadRequest(new { message = "El usuario " + user.Username + " ya existe" });
                }
                user.Password = Encrypt.EncryptPassword(user.Password);
                user.DateCreated = DateTime.Now;
                await _userService.SaveUser(user);
                return Ok(new { message = "Usuario registrado con exito." });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
