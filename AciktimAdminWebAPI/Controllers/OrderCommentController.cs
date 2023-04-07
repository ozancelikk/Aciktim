using AutoMapper;
using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimAdminWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderCommentController : ControllerBase
    {
        private readonly IOrderCommentService _orderCommentService;
        private readonly IMapper _mapper;

        public OrderCommentController(IOrderCommentService orderCommentService, IMapper mapper)
        {
            _orderCommentService = orderCommentService;
            _mapper = mapper;
        }
        [HttpPost("Add")]
        public IActionResult Add(OrderCommentDto orderCommentDto)
        {
            var map=_mapper.Map<OrderComment>(orderCommentDto);
            var result=_orderCommentService.Add(map);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("Update")]
        public IActionResult Update(OrderComment orderComment)
        {
            var result = _orderCommentService.Add(orderComment);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(string id)
        {
            var result = _orderCommentService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _orderCommentService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetByRestaurantId")]
        public IActionResult GetAll(string id)
        {
            var result = _orderCommentService.GetByRestaurantId(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
