using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimAdminWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantCommentController : ControllerBase
    {
        private IRestaurantCommentService _restaurantCommentService;

        public RestaurantCommentController(IRestaurantCommentService restaurantCommentService)
        {
            _restaurantCommentService = restaurantCommentService;
        }

        [HttpGet("GetAllActiveComments")]
        public IActionResult GetAllActiveComments() 
        {
            var result = _restaurantCommentService.GetAllActiveComments();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetAllPassiveComments")]
        public IActionResult GetAllPassiveComments()
        {
            var result = _restaurantCommentService.GetAllPassiveComments();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("Delete")]
        public IActionResult Delete(string id)
        {
            var result = _restaurantCommentService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("PassiveCommentToActiveComment")]
        public IActionResult PassiveCommentToActiveComment(RestaurantComment comment)
        {
            comment.Status = true;
            var result = _restaurantCommentService.Update(comment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
