using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimMusteriWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressesController : ControllerBase
    {
        private readonly ICustomerAddressService _customerAddressService;
        private readonly IMapper _mapper;

        public CustomerAddressesController(ICustomerAddressService customerAddressService, IMapper mapper)
        {
            _customerAddressService = customerAddressService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public IActionResult Add(CustomerAddressesDto customerAddressesDto)
        {
            var mapper = _mapper.Map<CustomerAddresses>(customerAddressesDto);
            var result = _customerAddressService.Add(mapper);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerAddressService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getallbycustomerid")]
        public IActionResult GetAllByCustomerId(string id)
        {
            var result = _customerAddressService.GetAllByCustomerId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("delete")]
        public IActionResult Delete(string id)
        {
            var result = _customerAddressService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]
        public IActionResult Update(CustomerAddresses customerAddress)
        {
            var result = _customerAddressService.Update(customerAddress);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
