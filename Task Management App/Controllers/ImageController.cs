using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models.DTO.Image;
using Task_Management_System.Models.Dtos;
using Task_Management_System.Services.ImageService;

namespace Task_Management_System.Controllers
{
    [ApiController]
    [Route("api/images")]
    [Produces("application/json")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageService imageService;
        private readonly IMapper mapper;

        public ImagesController(IImageService imageService, IMapper mapper)
        {
            this.imageService = imageService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<ImageResponseDto>>> GetImages([FromQuery] PaginationFilter paginationFilter)
        {
            var images = await imageService.GetAllAsync(paginationFilter);

            var pagedResponse = new PagedResponse<ImageResponseDto>()
            {
                CurrentPage = images.CurrentPage,
                PageSize = images.PageSize,
                TotalItems = images.TotalItems,
                TotalPages = images.TotalPages,
                Items = mapper.Map<IEnumerable<ImageResponseDto>>(images.Items)
            };

            return Ok(pagedResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageById(Guid id)
        {
            var image = await imageService.GetByIdAsync(id);

            if (image == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ImageResponseDto>(image));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewImage([FromBody] ImagePostDto imagePostDto)
        {
            var imageResp = await imageService.AddAsync(imagePostDto);

            return CreatedAtAction("GetClient", new { id = imageResp.ID }, mapper.Map<ImageResponseDto>(imageResp));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromQuery] Guid id, [FromBody] ImagePutDto imagePutDto)
        {
            if (id != imagePutDto.ID)
            {
                return BadRequest();
            }

            await imageService.UpdateAsync(imagePutDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(Guid id)
        {
            var success = await imageService.RemoveByIdAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
