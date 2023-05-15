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
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetAllOrders")]
        public IActionResult GetAllOrders()
        {
            var result = _orderService.GetAll();
            if (result.Success)
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


        [HttpGet("GetOrdersByCustomerId")]
        public IActionResult GetOrdersByCustomerId(string customerId)
        {
            var result = _orderService.GetOrderDetailsByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }



        [HttpGet("GetCustomerOrderDetailsByDate")]
        public IActionResult GetCustomerOrderDetailsByDate(string start,string end,string customerId)
        {
            var result = _orderService.GetCustomerOrderDetailsByDate(start,end,customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        
        [HttpGet("GetRestaurantOrderDetailsByDate")]
        public IActionResult GetRestaurantOrderDetailsByDate(string start, string end, string restaurantId)
        {
            var result = _orderService.GetRestaurantOrderDetailsByDate(start, end, restaurantId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        

        [HttpGet("GetOrdersByRestaurantId")]
        public IActionResult GetOrdersByRestaurantId( string restaurantId)
        {
            var result = _orderService.GetOrdersByRestaurantId(restaurantId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
    }
}
