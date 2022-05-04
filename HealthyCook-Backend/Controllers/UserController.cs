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

        /// <summary>
        /// Registro de usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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
                var validateEmail = await _userService.ValidateEmail(user.Email);
                if (validateEmail)
                {
                    return BadRequest(new { message = "El email " + user.Email + " ya se encuentra en uso" });
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

        /// <summary>
        /// Metodo para verificar si un email se encuentra en uso o no
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [Route("VerifyEmail/{email}")]
        [HttpGet]
        public async Task<string> ValidateEmail(string email)
        {

            var verifyEmail = await _userService.ValidateEmail(email);
            if (verifyEmail) return "El email " + email + " se encuentra en uso";
            return "Email disponible";

        }

        /// <summary>
        /// Buscar usuario por su ID
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [Route("SearchUser/{userID}")]
        [HttpGet]
        public async Task<IActionResult> SearchUser(int userID)
        {
            try
            {
                var patient = await _userService.SearchUser(userID);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Eliminar usuario
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        [HttpDelete("{userID}")]
        public async Task<IActionResult> DeleteUser(int userID)
        {
            try
            {
                var user = await _userService.SearchUser(userID);
                if (user == null) return BadRequest(new { message = "a no esta" });
                await _userService.DeleteUser(user);
                return Ok(new { message = "xd se borro pipi" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


    }
}
