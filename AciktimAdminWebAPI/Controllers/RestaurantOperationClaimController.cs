using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimAdminWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantOperationClaimController : ControllerBase
    {
        private readonly IRestaurantOperationClaimService _restaurantOperationClaimService;

        public RestaurantOperationClaimController(IRestaurantOperationClaimService restaurantOperationClaimService)
        {
            _restaurantOperationClaimService = restaurantOperationClaimService;
        }

        [HttpGet("getbyid")]

        public IActionResult GetById(string id) 
        {
            var result = _restaurantOperationClaimService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getallcalims")]

        public IActionResult GetAllClaims()
        {
            var result = _restaurantOperationClaimService.GetAllClaims();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result = _restaurantOperationClaimService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("add")]

        public IActionResult Add(RestaurantOperationClaimDto restaurantOperationClaimDto)
        {
            var result = _restaurantOperationClaimService.Add(restaurantOperationClaimDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("update")]

        public IActionResult Update(RestaurantOperationClaim restaurantOperationClaim)
        {
            var result = _restaurantOperationClaimService.Update(restaurantOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("delete")]

        public IActionResult Delete(RestaurantOperationClaim restaurantOperationClaim) 
        {
            var result = _restaurantOperationClaimService.Delete(restaurantOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
