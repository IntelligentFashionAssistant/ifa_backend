using System.Collections.Generic;
using System.Linq;
using api.ApiDTOs;
using application.DTOs;
using application.services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/garment")]
    public class GarmentController : Controller
    { 
       private readonly IGarmentService _garmentServices;

        public GarmentController(IGarmentService garmentServices)
        {
            _garmentServices = garmentServices;
        }

        [HttpPost("rate")]
        public IActionResult RateGarment()
        {
            return null;
        }
        
        
        //[HttpGet("/{id:int}")]
        //public IActionResult GetGarmentById(long id)
        //{
        //    var respons = new ResponsApiDto<GarmentApiDto>();
        //    var data = _garmentServices.GetById(id);

        //    if (data != null)
        //    {
        //        respons.Data = new GarmentApiDto
        //        {
        //            Name = data.Name,
        //            Description = data.Description,
        //            Brand = data.Brand,
        //            Price = data.Price,
        //            CategoryId = data.CategoryId,
        //            StoreId = data.StoreId,
        //            Images = data.Images,
        //            Colors = data.Colors,
        //            Properties = data.Properties.Select(p => new PropertyApiDto
        //            {
        //                Name = p.Name,
        //                Description = p.Description,
        //                GroupId = p.GroupId,
        //                CategoryId = p.CategoryId,
        //            }).ToList(),
        //        };
        //        respons.Status = "Success";
        //        return Ok(respons);
        //    }

        //    respons.Status = "Failed";
        //    return Ok(respons);
        //}
        
        
        [HttpGet]
        public IActionResult GetAllGaremnts()
        {
            var respons = new ResponsApiDto<ICollection<GarmentApiDto>>();
            var data = _garmentServices.GetAll();

            if(data != null)
            {
                respons.Data = data.Select(garmet => new GarmentApiDto
                {
                    Name = garmet.Name,
                    Description = garmet.Description,
                    Brand = garmet.Brand,
                    Price = garmet.Price,
                    CategoryId = garmet.CategoryId,
                    StoreId = garmet.StoreId,
                    Images = garmet.Images,
                    Colors = garmet.Colors,
                    Properties = garmet.Properties.Select(p => new PropertyApiDto
                    {
                        Name = p.Name,
                        Description = p.Description,
                        GroupId = p.GroupId,
                        CategoryId = p.CategoryId,
                    }).ToList(),
                    }).ToList();
                respons.Status = "Success";
                return Ok(respons);
            }
            respons.Status = "Failed";
            return Ok(respons);
        }

        [HttpPost]
        public IActionResult CreateGarment(GarmentApiDto garmentApiDto)
        {
            var respons = new ResponsApiDto<GarmentApiDto>();
            var data = _garmentServices.Create(new GarmentDto
            {
                Name = garmentApiDto.Name,
                Description = garmentApiDto.Description,
                Brand = garmentApiDto.Brand,
                Price = garmentApiDto.Price,
                CategoryId = garmentApiDto.CategoryId,
                StoreId = garmentApiDto.StoreId,
                Images = garmentApiDto.Images,
                Colors = garmentApiDto.Colors,
                Properties = garmentApiDto.Properties.Select(p => new PropertyDto
                {    
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    GroupId = p.GroupId,
                    CategoryId = p.CategoryId,
                }).ToList(),
            });

            if(data != null)
            {
                respons.Data = new GarmentApiDto
                {
                    Name = data.Name,
                    Description = data.Description,
                    Brand = data.Brand,
                    Price = data.Price,
                    CategoryId = data.CategoryId,
                    StoreId = data.StoreId,
                    Images = data.Images,
                    Colors = data.Colors,
                    Properties = data.Properties.Select(p => new PropertyApiDto
                    {
                        Name = p.Name,
                        Description = p.Description,
                        GroupId = p.GroupId,
                        CategoryId = p.CategoryId,
                    }).ToList(),
                };
                respons.Status = "Success";
                return Ok(respons);
            }

            respons.Status = "Failed";
            return Ok(respons);
        }

        [HttpPut]
        public IActionResult EditGarment(GarmentApiDto garmentApiDto)
        {
            var respons = new ResponsApiDto<GarmentApiDto>();
            var data = _garmentServices.Edit(new GarmentDto
            {
                Name = garmentApiDto.Name,
                Description = garmentApiDto.Description,
                Brand = garmentApiDto.Brand,
                Price = garmentApiDto.Price,
                CategoryId = garmentApiDto.CategoryId,
                StoreId = garmentApiDto.StoreId,
                Images = garmentApiDto.Images,
                Colors = garmentApiDto.Colors,
                Properties = garmentApiDto.Properties.Select(p => new PropertyDto
                {   Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    GroupId = p.GroupId,
                    CategoryId = p.CategoryId,
                }).ToList(),
            });

            if (data != null)
            {
                respons.Data = new GarmentApiDto
                {
                    Name = data.Name,
                    Description = data.Description,
                    Brand = data.Brand,
                    Price = data.Price,
                    CategoryId = data.CategoryId,
                    StoreId = data.StoreId,
                    Images = data.Images,
                    Colors = data.Colors,
                    Properties = data.Properties.Select(p => new PropertyApiDto
                    {
                        Name = p.Name,
                        Description = p.Description,
                        GroupId = p.GroupId,
                        CategoryId = p.CategoryId,
                    }).ToList(),
                };
                respons.Status = "Success";
                return Ok(respons);
            }
            respons.Status = "Failed";
            return Ok(respons);
        }

        [HttpDelete]
        public IActionResult DeleteGarmentById(long id)
        {
            _garmentServices.DeleteById(id);

            return Ok();
        }
        
        
    }
}