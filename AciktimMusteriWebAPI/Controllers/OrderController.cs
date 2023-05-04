using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimMusteriWebAPI.Controllers
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
        [HttpPost("Add")]
        public IActionResult Add(OrderDto orderDto)
        {
            var map=_mapper.Map<Order>(orderDto);
            var result=_orderService.Add(map);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _orderService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpGet("GetAllOrderDetails")]
        public IActionResult GetAllOrderDetails()
        {
            var result = _orderService.GetAllOrdersDetails();
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


        [HttpGet("GetActiveOrdersByCustomerId")]
        public IActionResult GetOrdersByCustomerIdYeni(string customerId)
        {
            var result = _orderService.GetActiveOrdersDetailsByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("GetCompletedOrdersDetailsByCustomerId")]
        public IActionResult GetCompletedOrdersDetailsByCustomerId(string customerId)
        {
            var result = _orderService.GetCompletedOrdersDetailsByCustomerId(customerId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        
    }
}
