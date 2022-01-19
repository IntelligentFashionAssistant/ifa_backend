using System.Collections.Generic;
using System.Linq;
using api.ApiDTOs;
using api.Utils;
using application.DTOs;
using application.services;
using domain.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/garment")]
    public class GarmentController : Controller
    {
        private readonly IGarmentService _garmentServices;
        private readonly IImageService _imageService;
        private readonly IStoreService _storeService;
        private readonly UserManager<User> _userManager;
        public GarmentController(IGarmentService garmentServices,
                                 IImageService imageService,
                                 IStoreService storeService,
                                 UserManager<User> userManager
                                 )
        {
            _garmentServices = garmentServices;
            _imageService = imageService;
            _storeService = storeService;
            _userManager = userManager;
        }


        [HttpPost("toggle-like/{id:int}")]
        public async Task<IActionResult> LikeOrDislikeGarment(long garmentId)
        {
            var respons = new ResponsApiDto<ICollection<GarmentApiDto>, string>();
            try
            {
                _garmentServices.LikeOrDislikeGarment(User, garmentId);
                return Ok();
            }
            catch (Exception e)
            {
                respons.AddError(e.Message);
                return BadRequest(respons);
            }
        }
        
        
        [HttpGet("search/{keyword}")]
        public async Task<IActionResult> GetUserGarmentsByKeyword(string keyword, [FromQuery] PageApiDto pageApiDto)
        {
            var respons = new ResponsApiDto<ICollection<GarmentApiDto>, string>();
            
            try
            {
                var garments = await _garmentServices.GetUserGarmentsByKeyword(User, keyword, pageApiDto.PageNumber, pageApiDto.PageSize);
                respons.Data = Mapper.FromGarmentDtoToGarmentApiDto(garments);
                return Ok(respons);
            }
            catch (Exception e)
            {
                // todo : better error message
                respons.AddError("error");
                return NotFound(respons);
            }
        }
        [HttpGet("category/{categoryId:long}")]
        public async Task<IActionResult> GetUserGarmentsByCategory(long categoryId, [FromQuery] PageApiDto pageApiDto)
        {
            var respons = new ResponsApiDto<ICollection<GarmentApiDto>, string>();
            
            try
            {
                var garments = await _garmentServices.GetUserGarmentsByCategory(User, categoryId, pageApiDto.PageNumber, pageApiDto.PageSize);
                respons.Data = Mapper.FromGarmentDtoToGarmentApiDto(garments);
                return Ok(respons);
            }
            catch (Exception e)
            {
                // todo : better error message
                respons.AddError("error");
                return NotFound(respons);
            }
        }
        
        [HttpGet("user-garments")]
        public async Task<IActionResult> GetUserGarments([FromQuery] PageApiDto pageApiDto)
        {
            var respons = new ResponsApiDto<ICollection<GarmentApiDto>, string>();
            
            try
            {
                var garments = await _garmentServices.GetUserGarments(User, pageApiDto.PageNumber, pageApiDto.PageSize);
                respons.Data = Mapper.FromGarmentDtoToGarmentApiDto(garments);
                return Ok(respons);
            }
            catch (Exception e)
            {
                // todo : better error message
                respons.AddError("error");
                return NotFound(respons);
            }

        }


        [HttpGet("{id:int}")]
        public IActionResult GetGarmentById(long id)
        {
            var respons = new ResponsApiDto<GarmentApiDto, string>();
            var data = _garmentServices.GetById(id);

            if (data != null)
            {
                respons.Data = new GarmentApiDto
                {
                    Id = data.Id,
                    Name = data.Name,
                    Description = data.Description,
                    Brand = data.Brand,
                    Price = data.Price,
                    CategoryId = data.CategoryId,
                    StoreId = data.StoreId,
                    Images = data.Images,
                    Colors = data.Colors,
                    Sizes = data.Sizes,
                    CreatedAt = data.CreatedAt,
                };
                return Ok(respons);
            }

            respons.AddError("Not found");
            return NotFound(respons);
        }


        [HttpGet()]
        public IActionResult GetAllGaremnts()
        {
            var respons = new ResponsApiDto<ICollection<GarmentApiDto>, string>();
            try
            {
                var data = _garmentServices.GetAll();

                if (data != null)
                {
                    respons.Data = data.Select(garmet => new GarmentApiDto
                    {
                        Id = garmet.Id,
                        Name = garmet.Name,
                        Description = garmet.Description,
                        Brand = garmet.Brand,
                        Price = garmet.Price,
                        CategoryId = garmet.CategoryId,
                        Category = garmet.Category,
                        StoreId = garmet.StoreId,
                        Images = garmet.Images,
                        Colors = garmet.Colors,
                        Sizes = garmet.Sizes,
                        StoreApiDto = new StoreApiDto
                        {
                            StoreName = garmet.StoreDto.StoreName,
                            Locations = garmet.StoreDto.Locations.Select(l => new LocationApiDto
                            {
                                Country = l.Country,
                                City = l.City,
                                Street = l.Street,
                                PhoneNumber = l.PhoneNumaber,
                                Id = l.Id,
                            }).ToList(),
                        },
                        //Properties = garmet.Properties.Select(p => p).ToList(),
                    }).ToList();

                }
            }
            catch(Exception ex)
            {
                respons.AddError(ex.Message);
                return NotFound(respons);
            }
            
            return Ok(respons);
        }

        [HttpPost("CreateGarment")]
        public async  Task<IActionResult> CreateGarment([FromForm] GarmentApiDto.Requst garmentApiDto)
        {
            
            var user = await _userManager.GetUserAsync(User);
            long storeId = await _storeService.GetStoreByUserId(user.Id);


            var respons = new ResponsApiDto<GarmentApiDto, string>();
            var images = new List<string>();

            try
            {
                if (garmentApiDto.ImagesFiles.Count > 0)
                {
                    images = await _imageService.SaveListOfImages(garmentApiDto.ImagesFiles);

                }
                var data = _garmentServices.Create(new GarmentDto
                {
                    Name = garmentApiDto.Name,
                    Description = garmentApiDto.Description,
                    Brand = garmentApiDto.Brand,
                    Price = garmentApiDto.Price,
                    CategoryId = garmentApiDto.CategoryId,
                    StoreId = storeId,
                    Images = images,
                    ColorsOfId = garmentApiDto.Colors,
                    Properties = garmentApiDto.Properties,
                    SizesOfId = garmentApiDto.Sizes
                });

                if (data != null)
                {   
                    respons.Data = new GarmentApiDto
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Description = data.Description,
                        Brand = data.Brand,
                        Price = data.Price,
                        CategoryId = data.CategoryId,
                        StoreId = data.StoreId,
                        Images = data.Images,
                        ColorsOfId = garmentApiDto.Colors,
                        Properties = garmentApiDto.Properties,
                         SizesOfId = garmentApiDto.Sizes
                        
                        //Properties = data.Properties.Select(p => p).ToList(),
                    };
                   
                }
            }
            catch (Exception ex)
            {
                respons.AddError(ex.Message);
                return BadRequest(respons);
            }
            return Ok(respons);
        }

        [HttpPut]
        public async Task<IActionResult> EditGarment([FromForm] GarmentApiDto.Requst garmentApiDto)
        {

            var respons = new ResponsApiDto<GarmentApiDto, string>();
            var images = new List<string>();

            try
            {
                 
                if (garmentApiDto.ImagesFiles != null)
                {
                    images = await _imageService.SaveListOfImages(garmentApiDto.ImagesFiles);

                }
                var data = _garmentServices.Edit(new GarmentDto
                { 
                    Id = garmentApiDto.Id,
                    Name = garmentApiDto.Name,
                    Description = garmentApiDto.Description,
                    Brand = garmentApiDto.Brand,
                    Price = garmentApiDto.Price,
                    CategoryId = garmentApiDto.CategoryId,
                    StoreId = garmentApiDto.StoreId,
                    Images = images,
                    ColorsOfId = garmentApiDto.Colors,
                    Properties = garmentApiDto.Properties,
                    SizesOfId = garmentApiDto.Sizes
                });

                if (data != null)
                {
                    respons.Data = new GarmentApiDto
                    {
                        Id = data.Id,
                        Name = data.Name,
                        Description = data.Description,
                        Brand = data.Brand,
                        Price = data.Price,
                        CategoryId = data.CategoryId,
                        StoreId = data.StoreId,
                        Images = data.Images,
                        Colors = data.Colors,
                        Sizes = data.Sizes
                        //Properties = data.Properties.Select(p => p).ToList(),
                    };

                }
            }
            catch (Exception ex)
            {
                respons.AddError(ex.Message);
                return BadRequest(respons);
            }
            return Ok(respons);
        }

        [HttpDelete]
        public IActionResult DeleteGarmentById(long id)
        {
            //TODO
            var respons = new ResponsApiDto<string, string>();
            _garmentServices.DeleteById(id);
            respons.Data = "Deleted Garment";
            return Ok(respons);
        }
        
        [HttpGet("GetColors")]
        public IActionResult GetColors()
        {
            var respons = new ResponsApiDto<ICollection<ColorApiDto>, string>();

            try
            {
                var data = _garmentServices.GetColors();

                respons.Data = data.Select(color => new ColorApiDto
                {
                    Id = color.Id,
                    Name = color.Name,
                }).ToList();

            }catch(Exception ex)
            {
                respons.AddError(ex.Message);
                return NotFound(respons);
            }

            return Ok(respons);
        }

        [HttpGet("GetSizeByCategory/{categoryId:long}")]
        public IActionResult GetSizeByCategory(long categoryId)
        {
            var respons = new ResponsApiDto<ICollection<SizeApiDto>, string>();

            try
            {
                var data = _garmentServices.GetSizeByCategory(categoryId);

                respons.Data = data.Select(size => new SizeApiDto
                {
                    Id = size.Id,
                    Name = size.Name,
                    CM = size.CM,
                    CategoryId = size.CategoryId,
                }).ToList();

            }
            catch (Exception ex)
            {
                respons.AddError(ex.Message);
                return NotFound(respons);
            }

            return Ok(respons);
        }

    }
}