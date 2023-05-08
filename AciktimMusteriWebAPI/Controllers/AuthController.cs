using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;

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
            customerForRegisterDto.RegisterDate = DateTime.Today.ToString("dd.MM.yyyy");

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
            var customerToLogin = _customerAuthService.Login(customerForLoginDto);
            if (!customerToLogin.Success)
            {
                return BadRequest(customerToLogin.Message);
            }
            var result = _customerAuthService.CreateAccessToken(customerToLogin.Data);
            if (result.Success)
            {
                return Ok(result);
            }
            result.Data.CustomerId = customerToLogin.Data.Id;
            return BadRequest(result);
        }

        [HttpPost("ChangePassword")]
        public ActionResult ChangePassword(CustomerChangePasswordDto customerChangePasswordDto)
        {
            var result = _customerAuthService.ChangePassword(customerChangePasswordDto);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
