using AutoMapper;
using Business.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimRestoranWebAPI.Controllers
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
            var order= _mapper.Map<Order>(orderDto);
            var result=_orderService.Add(order);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(Order order)
        {
            var result = _orderService.Update(order);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("Delete")]
        public IActionResult Delete(string id)
        {
            var result = _orderService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _orderService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("OrderMenusByRestaurantId")]
        public IActionResult OrderMenusByRestaurantId(string restaurantId)
        {
            var result = _orderService.OrderMenusByRestaurantId(restaurantId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
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
        [HttpPost("GetById")]
        public IActionResult GetById(string id)
        {
            var result = _orderService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("ChangeOrderStatusToCourier")]
        public IActionResult ChangeOrderStatusToCourier(Order order)
        {
            order.OrderStatus = "Kuryede";
            var result = _orderService.Update(order);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
        [HttpPost("ChangeOrderStatusToReady")]
        public IActionResult ChangeOrderStatusToReady(Order order)
        {
            order.OrderStatus = "Hazırlanıyor";
            var result = _orderService.Update(order);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
        [HttpPost("ChangeOrderStatusToComplete")]
        public IActionResult ChangeOrderStatusToComplete(Order order)
        {
            order.OrderStatus = "Tamamlandı";
            var result = _orderService.Update(order);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);

        }
    }
}
