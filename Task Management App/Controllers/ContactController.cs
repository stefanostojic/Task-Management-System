using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task_Management_System.DTO;
using Task_Management_System.Models.DTO.Contact;
using Task_Management_System.Services.ContactService;

namespace Task_Management_System.Controllers
{
    [ApiController]
    [Route("api/contacts")]
    [Produces("application/json")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService contactService;
        private readonly IMapper mapper;

        public ContactsController(IContactService contactService, IMapper mapper)
        {
            this.contactService = contactService;
            this.mapper = mapper;
        }

        [HttpGet]
        [Route("GetContacts")]
        public async Task<ActionResult<PagedResponse<ContactResponseDto>>> GetContacts([FromQuery] PaginationFilter paginationFilter)
        {
            var contacts = await contactService.GetAllAsync(paginationFilter);

            var pagedResponse = new PagedResponse<ContactResponseDto>()
            {
                CurrentPage = contacts.CurrentPage,
                PageSize = contacts.PageSize,
                TotalItems = contacts.TotalItems,
                TotalPages = contacts.TotalPages,
                Items = mapper.Map<IEnumerable<ContactResponseDto>>(contacts.Items)
            };

            return Ok(pagedResponse);
        }

        [HttpGet]
        [Route("GetContactById")]
        /// <param name="user1Id">Used to specify the User1.</param>
        /// <param name="user2Id">Used to specify the User2.</param>
        public async Task<IActionResult> GetContactById([FromQuery] Guid user1Id, [FromQuery] Guid user2Id)
        {
            var contact = await contactService.GetByIdAsync(user1Id, user2Id);

            if (contact == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<ContactResponseDto>(contact));
        }

        [HttpPost]
        public async Task<IActionResult> AddNewContact([FromBody] ContactPostDto contactPostDto)
        {
            var contactResp = await contactService.AddAsync(contactPostDto);

            return CreatedAtAction("GetClient", new { user1Id = contactResp.User1ID, user2Id = contactResp.User2ID }, mapper.Map<ContactResponseDto>(contactResp));
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromQuery] Guid user1Id, [FromQuery] Guid user2Id, [FromBody] ContactPutDto contactPutDto)
        {
            if (user1Id != contactPutDto.User1ID || user2Id != contactPutDto.User2ID)
            {
                return BadRequest();
            }

            await contactService.UpdateAsync(contactPutDto);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContact([FromQuery] Guid user1Id, [FromQuery] Guid user2Id)
        {
            var success = await contactService.RemoveByIdAsync(user1Id, user2Id);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
