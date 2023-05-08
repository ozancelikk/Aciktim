using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Entities.Dtos;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimAdminWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }


        [HttpPost("changeforgottenpassword")]

        public IActionResult ChangeForgottenPassword(Customer customer)
        {
            var result = _customerService.ChangeForgottenPassword(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _customerService.GetAllWithId();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        

        [HttpGet("GetCustomersByTodayRegisterDate")]
        public IActionResult GetCustomersByTodayRegisterDate()
        {
            var result = _customerService.GetCustomersByTodayRegisterDate();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetCustomerOrdersByOrderNumbers")]

        public IActionResult GetCustomerOrdersByOrderNumbers()
        {
            var result = _customerService.GetCustomerOrdersByOrderNumbers();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getdetailsbyid")]

        public IActionResult GetDetailsById(string id)
        {
            var result = _customerService.GetDetailsById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getcustomerdetailsbymail")]

        public IActionResult GetCustomerDetailsByMail(string mail)
        {
            var result = _customerService.GetCustomerDetailsByMail(mail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]

        public IActionResult Add(CustomerDto customer) 
        {
            var map = _mapper.Map<Customer>(customer);
            var result = _customerService.Add(map);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]

        public IActionResult Update(CustomerDetailsDto customer)
        {
            var map = _mapper.Map<Customer>(customer);
            var result = _customerService.Update(map);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("delete")]

        public IActionResult Delete(string id)
        {
            var result = _customerService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
