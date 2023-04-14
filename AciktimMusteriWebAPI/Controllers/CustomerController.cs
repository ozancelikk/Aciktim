using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Entities.Dtos;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimMusteriWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        private readonly IMapper _mapper;
        public CustomerController(ICustomerService customerService,IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }
        [HttpPost("Add")]
        public IActionResult Add(CustomerDto customerDto)
        {
            var customer =_mapper.Map<Customer>(customerDto);
            var result=_customerService.Add(customer);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Update")]
        public IActionResult Update2(CustomerDetailsDto customer)
        {
            var map = _mapper.Map<Customer>(customer);
            var oldCustomer = _customerService.GetById(map.Id);
            if (oldCustomer != null)
            {
                map.PasswordHash = oldCustomer.Data.PasswordHash; 
                map.PasswordSalt = oldCustomer.Data.PasswordSalt; 
            }
            var result = _customerService.Update(map);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("Delete")]
        public IActionResult Delete(string id)
        {
            var result = _customerService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            var result = _customerService.GetDetailsById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetByMail")]
        public IActionResult GetByMail(string mail)
        {
            var result = _customerService.GetCustomerDetailsByMail(mail);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
