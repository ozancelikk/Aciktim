using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Core.MessageBroker.Abstract;
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
        private readonly IMailSender _mailSender;
        private readonly IMailConsumerPasswordKeyService _mailConsumerPasswordKeyService;
        private readonly ICustomerService _customerService;
        public AuthController(ICustomerAuthService customerAuthService, IMailSender mailSender, IMailConsumerPasswordKeyService mailConsumerPasswordKeyService, ICustomerService customerService)
        {
            _customerAuthService = customerAuthService;
            _mailSender = mailSender;
            _mailConsumerPasswordKeyService = mailConsumerPasswordKeyService;
            _customerService = customerService;
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
            _mailSender.Mail(customerForRegisterDto.Email);
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
            var customer = _customerService.GetByMail(customerForLoginDto.Email);
            if (customer.Data.Status==false)
            {
                return BadRequest("Lütfen Mailinizi Onaylayın");
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

        [HttpGet("CheckIfPrivateKeyIsTrue")]
        public IActionResult CheckIfPrivateKeyIsTrue(string key,string mail)
        {
            var data=_mailConsumerPasswordKeyService.GetByMail(mail);
            var result=_mailConsumerPasswordKeyService.asd(key, mail);
            var customer = _customerService.GetByMail(mail);
            if (result.Success)
            {
                _mailConsumerPasswordKeyService.Delete(data.Data.Id);
                customer.Data.Status = true;
                _customerService.Update(customer.Data);
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
