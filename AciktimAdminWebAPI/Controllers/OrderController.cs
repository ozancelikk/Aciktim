using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimAdminWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpPost("add")]
        public IActionResult Add(OrderDetailsDto order)
        {
            var map = _mapper.Map<Order>(order);
            var result = _orderService.Add(map);
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            var result = _orderService.GetAll();
            if(result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetActiveOrdersByRestaurantId")]
        public IActionResult GetActiveOrdersByRestaurantId(string restaurantId)
        {
            var result = _orderService.GetActiveOrdersDetailsByRestaurantId(restaurantId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetPassiveOrdersByRestaurantId")]
        public IActionResult GetPassiveOrdersByRestaurantId(string restaurantId)
        {
            var result = _orderService.GetPassiveOrdersDetailsByRestaurantId(restaurantId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(string id)
        {
            var result = _orderService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetTodayOrders")]
        public IActionResult GetTodayOrders()
        {
            var result = _orderService.GetTodayOrders();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetYesterdayOrders")]
        public IActionResult GetYesterdayOrders()
        {
            var result = _orderService.GetYesterdayOrders();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
