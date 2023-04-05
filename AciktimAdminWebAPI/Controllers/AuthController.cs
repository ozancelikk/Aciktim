﻿using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimAdminWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto user)
        {
            var result = _authService.Register(user);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var result2 = _authService.CreateAccessToken(result.Data);
            if (result2.Success)
            {
                return Ok(result2);
            }
            return BadRequest(result2.Message);
        }

        [HttpPost("login")]

        public IActionResult Login(UserForLoginDto user)
        {
            var result = _authService.Login(user);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }
            var result2 = _authService.CreateAccessToken(result.Data);
            if (result2.Success)
            {
                return Ok(result2);
            }
            return BadRequest(result2.Message);
        }

        [HttpGet("userexists")]
        public IActionResult UserExists(string email) 
        {
            var result = _authService.UserExists(email);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("forgotpassword")]

        public IActionResult ForgotPassword(string eMail)
        {
            var result = _authService.ForgotPassword(eMail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("changeforgottenpassword")]

        public IActionResult ChangeForgottenPassword(ForgottenPassword forgottenPassword)
        {
            var result = _authService.ChangeForgottenPassword(forgottenPassword);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
