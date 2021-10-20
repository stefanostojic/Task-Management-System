using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models.Dtos;
using Task_Management_System.Services.ProPlanService;

namespace Task_Management_System.Controllers
{
    [ApiController]
    [Route("api/proPlans")]
    [Produces("application/json")]
    public class ProPlansController : ControllerBase
    {
        private readonly IProPlanService proPlanService;
        private readonly IMapper mapper;

        public ProPlansController(IProPlanService proPlanService, IMapper mapper)
        {
            this.proPlanService = proPlanService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<PagedResponse<ProPlanResponseDto>>> GetProPlans([FromQuery] PaginationFilter paginationFilter)
        {
            var proPlans = await proPlanService.GetAllAsync(paginationFilter);

            var pagedResponse = new PagedResponse<ProPlanResponseDto>()
            {
                CurrentPage = proPlans.CurrentPage,
                PageSize = proPlans.PageSize,
                TotalItems = proPlans.TotalItems,
                TotalPages = proPlans.TotalPages,
                Items = mapper.Map<IEnumerable<ProPlanResponseDto>>(proPlans.Items)
            };

            return Ok(pagedResponse);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProPlanById(Guid id)
        {
            var proPlan = await proPlanService.GetByIdAsync(id);

            if (proPlan == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ProPlanResponseDto>(proPlan));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewProPlan([FromBody] ProPlanPostDto proPlanPostDto)
        {
            var proPlanResp = await proPlanService.AddAsync(proPlanPostDto);

            return CreatedAtAction("GetClient", new { id = proPlanResp.ID }, mapper.Map<ProPlanResponseDto>(proPlanResp));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit([FromQuery] Guid id, [FromBody] ProPlanPutDto proPlanPutDto)
        {
            if (id != proPlanPutDto.ID)
            {
                return BadRequest();
            }

            await proPlanService.UpdateAsync(proPlanPutDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProPlan(Guid id)
        {
            var success = await proPlanService.RemoveByIdAsync(id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
