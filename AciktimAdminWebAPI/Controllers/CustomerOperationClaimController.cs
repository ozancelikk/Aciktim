using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimAdminWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOperationClaimController : ControllerBase
    {
        private readonly ICustomerOperationClaimService _customerOperationClaimService;

        public CustomerOperationClaimController(ICustomerOperationClaimService customerOperationClaimService)
        {
            _customerOperationClaimService = customerOperationClaimService;
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(string id)
        {
            var result = _customerOperationClaimService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("GetCustomerClaims")]

        public IActionResult GetClaims(string id)
        {
            var result = _customerOperationClaimService.GetCustomersClaims(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getallclaims")]

        public IActionResult GetAllClaims()
        {
            var result = _customerOperationClaimService.GetAllClaims();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _customerOperationClaimService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]
        
        public IActionResult Add(CustomerOperationClaimDto customerOperationClaimDto)
        {
            var result = _customerOperationClaimService.Add(customerOperationClaimDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]

        public IActionResult Delete(CustomerOperationClaim ustomerOperationClaim)
        {
            var result = _customerOperationClaimService.Delete(ustomerOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]

        public IActionResult Update(CustomerOperationClaim ustomerOperationClaim)
        {
            var result = _customerOperationClaimService.Update(ustomerOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
