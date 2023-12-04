using System;
using DVP.Project.Domain.Exception;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using DVP.Project.Api.Application.Commands.User;

namespace DVP.Project.Api.Controllers.User
{
	public class UserController : DVPController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
		{
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(CreateUserCommand user)
        {
            try
            {
                var result = await _mediator.Send(user);
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

        [HttpPost]
        [Route("validator/")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ValidatorUser(ValidatorUserCommand user)
        {
            try
            {
                var result = await _mediator.Send(user);
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


    }
}

