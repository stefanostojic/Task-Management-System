using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models.DTO.Label;
using Task_Management_System.Services.LabelService;

namespace Task_Management_System.Controllers
{
    [ApiController]
    [Route("api/labels")]
    [Produces("application/json")]
    public class LabelsController : ControllerBase
    {
        private readonly ILabelService labelService;
        private readonly IMapper mapper;

        public LabelsController(ILabelService labelService, IMapper mapper)
        {
            this.labelService = labelService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<LabelResponseDto>>> GetLabels([FromQuery] PaginationFilter paginationFilter)
        {
            var labels = await labelService.GetAllAsync(paginationFilter);

            var pagedResponse = new PagedResponse<LabelResponseDto>()
            {
                CurrentPage = labels.CurrentPage,
                PageSize = labels.PageSize,
                TotalItems = labels.TotalItems,
                TotalPages = labels.TotalPages,
                Items = mapper.Map<IEnumerable<LabelResponseDto>>(labels.Items)
            };

            return Ok(pagedResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLabelById(Guid id)
        {
            var label = await labelService.GetByIdAsync(id);

            if (label == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<LabelResponseDto>(label));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewLabel([FromBody] LabelPostDto labelPostDto)
        {
            var labelResp = await labelService.AddAsync(labelPostDto);

            return CreatedAtAction("GetClient", new { id = labelResp.ID }, mapper.Map<LabelResponseDto>(labelResp));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromQuery] Guid id, [FromBody] LabelPutDto labelPutDto)
        {
            if (id != labelPutDto.ID)
            {
                return BadRequest();
            }

            await labelService.UpdateAsync(labelPutDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLabel(Guid id)
        {
            var success = await labelService.RemoveByIdAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
