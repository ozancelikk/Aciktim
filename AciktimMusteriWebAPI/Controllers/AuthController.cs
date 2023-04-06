﻿using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AciktimMusteriWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly ICustomerAuthService _customerAuthService;
        public AuthController(ICustomerAuthService customerAuthService)
        {
            _customerAuthService = customerAuthService;
        }
        [HttpPost("Register")]
        public IActionResult Register(CustomerForRegisterDto customerForRegisterDto)
        {
            var exists = _customerAuthService.UserExists(customerForRegisterDto.Email);

            if (!exists.Success)
            {
                return BadRequest(exists.Message);
            }

            var register = _customerAuthService.Register(customerForRegisterDto);
            var check = _customerAuthService.CreateAccessToken(register.Data);

            if (!check.Success)
            {
                return BadRequest(check.Message);
            }
            return Ok(check);
        }


        [HttpPost("login")]
        public ActionResult Login(CustomerForLoginDto customerForLoginDto)
        {
            var userToLogin = _customerAuthService.Login(customerForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }
            var result = _customerAuthService.CreateAccessToken(userToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
