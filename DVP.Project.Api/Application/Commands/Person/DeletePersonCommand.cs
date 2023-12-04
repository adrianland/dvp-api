using FluentValidation;
using MediatR;

namespace DVP.Project.Api.Application.Commands.Person;

public class DeletePersonCommand : IRequest<bool>
{
    public int Id { get; set; }

    public DeletePersonCommand() { }

    public class DeletePersonCommandValidator : AbstractValidator<DeletePersonCommand>
    {
        public DeletePersonCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}