using api.ApiDTOs;
using application.contracts.services;
using application.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodySizesController : ControllerBase
    {

        private readonly IBodySizesService _bodySizesService;

        public BodySizesController(IBodySizesService bodySizesService)
        {
            _bodySizesService = bodySizesService;
        }

        [HttpGet]
        public IActionResult GetAllBodySizes()
        {
            var response = new ResponsApiDto<ICollection<BodySizesApiDto>>();
            var data = _bodySizesService.GetAll();

            if (data != null)
            {
                response.Data = data.Select(body => new BodySizesApiDto
                {
                    Id = body.Id,
                    BustRange = body.BustRange,
                    HipRange = body.HipRange,
                    ShoulderRange = body.ShoulderRange,
                    WaistRange = body.WaistRange,
                }).ToList();
                response.Status = "Success";
                return Ok(response.Data);
            }
            response.Status = "Failed";
            return BadRequest(response.Data);
        }

        [HttpPost]
        public IActionResult CreateBodySizes(BodySizesApiDto bodySizesApiDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(bodySizesApiDto);
            }

            var respons = new ResponsApiDto<string>();
            var data = _bodySizesService.CreateBody(new BodySizesDto
            {
               ShoulderRange = bodySizesApiDto.ShoulderRange,
               WaistRange = bodySizesApiDto.WaistRange,
               HipRange = bodySizesApiDto.HipRange,
               BustRange = bodySizesApiDto.BustRange,
            });

            if (data != null)
            {
                respons.Data = data;
                respons.Status = "Success";
                return Ok(respons);
            }

            respons.Data = "Numbers Invalid";
            respons.Status = "Failed";
            return Ok(respons);
        }

        [HttpPut]
        public IActionResult EditBodySizes(BodySizesApiDto bodySizesApiDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(bodySizesApiDto);
            }

            var respons = new ResponsApiDto<string>();
            var data = _bodySizesService.CreateBody(new BodySizesDto
            {
                Id = bodySizesApiDto.Id,
                ShoulderRange = bodySizesApiDto.ShoulderRange,
                WaistRange = bodySizesApiDto.WaistRange,
                HipRange = bodySizesApiDto.HipRange,
                BustRange = bodySizesApiDto.BustRange,
            });

            if (data != null)
            {
                respons.Data = data;
                respons.Status = "Success";
                return Ok(respons);
            }

            respons.Data = "Numbers Invalid";
            respons.Status = "Failed";
            return Ok(respons);
        }

        [HttpDelete]
        public IActionResult DeleteBodySizes(long id)
        {
            _bodySizesService.DeleteById(id);

            return Ok();
        }
    }
}
