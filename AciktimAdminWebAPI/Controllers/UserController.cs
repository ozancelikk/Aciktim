using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimAdminWebAPI.Controllers
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

        [HttpGet("getalluserdetails")]
        public IActionResult GetAllUserDetails() 
        {
            var result = _userService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);  
        }

        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(UserDto user)
        {
            var result = _userService.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(string id)
        {
            var result = _userService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getdetailsbyid")]
        public IActionResult GetDetailsById(string id)
        {
            var result = _userService.GetDetailsById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbymail")]
        public IActionResult GetByMail(string mail)
        {
            var result = _userService.GetByMail(mail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getclaims")]
        public IActionResult GetClaims(User user)
        {
            var result = _userService.GetClaims(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
