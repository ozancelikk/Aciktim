using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimAdminWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAddressController : ControllerBase
    {
        private readonly ICustomerAddressService _customerAddressService;
        private readonly IMapper _mapper;

        public CustomerAddressController(ICustomerAddressService customerAddressService, IMapper mapper)
        {
            _customerAddressService = customerAddressService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public IActionResult Add(CustomerAddressesDto customerAddresses)
        {
            var map = _mapper.Map<CustomerAddresses>(customerAddresses);
            var result = _customerAddressService.Add(map);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]
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

        public IActionResult Update(CustomerAddresses customerAddresses)
        {
            var result = _customerAddressService.Update(customerAddresses);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(string id) 
        {
            var result = _customerAddressService.GetById(id);
            if (result.Success)
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

        public IActionResult GetAllByCustomerId(string customerId)
        {
            var result = _customerAddressService.GetAllByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
