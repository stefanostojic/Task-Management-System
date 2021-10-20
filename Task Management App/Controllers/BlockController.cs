using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models.DTO.Block;
using Task_Management_System.Services.BlockService;

namespace Task_Management_System.Controllers
{
    [ApiController]
    [Route("api/blocks")]
    [Produces("application/json")]
    public class BlocksController : ControllerBase
    {
        private readonly IBlockService blockService;
        private readonly IMapper mapper;

        public BlocksController(IBlockService blockService, IMapper mapper)
        {
            this.blockService = blockService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetBlocks")]
        public async Task<ActionResult<PagedResponse<BlockResponseDto>>> GetBlocks([FromQuery] PaginationFilter paginationFilter)
        {
            var blocks = await blockService.GetAllAsync(paginationFilter);

            var pagedResponse = new PagedResponse<BlockResponseDto>()
            {
                CurrentPage = blocks.CurrentPage,
                PageSize = blocks.PageSize,
                TotalItems = blocks.TotalItems,
                TotalPages = blocks.TotalPages,
                Items = mapper.Map<IEnumerable<BlockResponseDto>>(blocks.Items)
            };

            return Ok(pagedResponse);
        }

        [HttpGet]
        [Route("GetBlockById")]
        /// <param name="user1Id">Used to specify the User1.</param>
        /// <param name="user2Id">Used to specify the User2.</param>
        public async Task<IActionResult> GetBlockById([FromQuery] Guid user1Id, [FromQuery] Guid user2Id)
        {
            var block = await blockService.GetByIdAsync(user1Id, user2Id);

            if (block == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<BlockResponseDto>(block));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBlock([FromBody] BlockPostDto blockPostDto)
        {
            var blockResp = await blockService.AddAsync(blockPostDto);

            return CreatedAtAction("GetClient", new { user1Id = blockResp.User1ID, user2Id = blockResp.User2ID }, mapper.Map<BlockResponseDto>(blockResp));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBlock([FromQuery] Guid user1Id, [FromQuery] Guid user2Id)
        {
            var success = await blockService.RemoveByIdAsync(user1Id, user2Id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
