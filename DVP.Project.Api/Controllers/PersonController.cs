using System;
using DVP.Project.Domain.Exception;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DVP.Project.Api.Application.Commands.Person;
using DVP.Project.Api.Application.Queries.Person;
using Microsoft.AspNetCore.Authorization;

namespace DVP.Project.Api.Controllers.Person
{
   [Authorize]
    public class PersonController : DVPController
    {
        private readonly IMediator _mediator;

        public PersonController(IMediator mediator)
		{
            _mediator = mediator;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreatePerson(CreatePersonCommand person)
        {
            try
            {
                var result = await _mediator.Send(person);
                Console.WriteLine(result);
                return await SuccessResquest(result);
            }
            catch (EntityNotFoundException r)
            {
                return await UnSuccessRequestNotFound(r.Message);
            }

            catch (DVPException r)
            {
                return await UnSuccessRequest(r.Message);
            }

            catch (BadRequestException b)
            {
                return await UnSuccessRequest(b.Message);
            }

            catch (Exception e)
            {
                return await UnSuccessRequest(e.Message);
            }
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetPersons()
        {
            try
            {
                var result = await _mediator.Send(new GetPersonsQuery());
                return await SuccessResquest(result);
            }
            catch (EntityNotFoundException r)
            {
                return await UnSuccessRequestNotFound(r.Message);
            }
            catch (DVPException r)
            {
                return await UnSuccessRequest(r.Message);
            }

            catch (BadRequestException b)
            {
                return await UnSuccessRequest(b.Message);
            }

            catch (Exception e)
            {
                return await UnSuccessRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePerson(int personId, UpdatePersonCommand person)
        {
            try
            {
                person.Id = personId;
                var result = await _mediator.Send(person);
                return await SuccessResquest(result);
            }
            catch (EntityNotFoundException r)
            {
                return await UnSuccessRequestNotFound(r.Message);
            }

            catch (DVPException r)
            {
                return await UnSuccessRequest(r.Message);
            }

            catch (BadRequestException b)
            {
                return await UnSuccessRequest(b.Message);
            }

            catch (Exception e)
            {
                return await UnSuccessRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("delete")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteUser(DeletePersonCommand person)
        {
            try
            {
                var result = await _mediator.Send(person);
                return await SuccessResquest(result);
            }
            catch (EntityNotFoundException r)
            {
                return await UnSuccessRequestNotFound(r.Message);
            }

            catch (DVPException r)
            {
                return await UnSuccessRequest(r.Message);
            }

            catch (BadRequestException b)
            {
                return await UnSuccessRequest(b.Message);
            }

            catch (Exception e)
            {
                return await UnSuccessRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("CountAllPersons")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CountAllPersons()
        {
            try
            {
                var result = await _mediator.Send(new CountAllPersonsQuery());
                return await SuccessResquest(result);
            }
            catch (EntityNotFoundException r)
            {
                return await UnSuccessRequestNotFound(r.Message);
            }
            catch (DVPException r)
            {
                return await UnSuccessRequest(r.Message);
            }

            catch (BadRequestException b)
            {
                return await UnSuccessRequest(b.Message);
            }

            catch (Exception e)
            {
                return await UnSuccessRequest(e.Message);
            }
        }


    }
}

