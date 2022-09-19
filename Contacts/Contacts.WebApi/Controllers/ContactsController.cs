using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;
using Contacts.Application.Commands.CreateContact;
using Contacts.Application.Commands.DeleteContact;
using Contacts.Application.Commands.UpdateContact;
using Contacts.Application.Queries.GetContactById;
using Contacts.Application.Queries.GetContacts;
using Contacts.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Contacts.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly ISender _sender;
        
        public ContactsController(ISender sender)
        {
            _sender = sender;
        }
        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<long>> CreateContact([FromBody] CreateContactCommand request)
        {
            return await _sender.Send(request);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<ContactVM>>> GetContacts()
        {
            var query = new GetContactsQuery();
            var result = await _sender.Send(query);

            return result.ToList();
        }

        [HttpGet("{contactId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ContactVM>> GetContactById([FromRoute] long contactId)
        {
            var query = new GetContactByIdQuery { Id = contactId};
            var contact = await _sender.Send(query);

            if (contact == null)
            {
                return NotFound();
            }
            
            return contact;
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateContact([FromBody] UpdateContactCommand request)
        {
            await _sender.Send(request);
            
            return Ok();
        }

        [HttpDelete("{contactId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteContact([FromRoute] long contactId)
        {
            var request = new DeleteContactCommand { Id = contactId };
            var result = (int) await _sender.Send(request);
            
            return new StatusCodeResult(result);
        }
    }
}
