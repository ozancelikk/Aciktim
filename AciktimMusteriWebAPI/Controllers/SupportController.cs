using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete.DBEntities;
using Entities.Concrete;
using Entities.Dtos;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AciktimMusteriWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupportController : ControllerBase
    {
        private readonly ISupportService _supportService;
        private readonly IMapper _mapper;

        public SupportController(IMapper mapper, ISupportService supportService)
        {
            _mapper = mapper;
            _supportService = supportService;
        }

        [HttpPost("Add")]
        public IActionResult Add(SupportDto support)
        {
            var map = _mapper.Map<Support>(support);
            var result = _supportService.Add(map);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Delete")]
        public IActionResult Delete(string id)
        {
            var result = _supportService.Delete(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _supportService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
