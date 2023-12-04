using FluentValidation;
using MediatR;

namespace DVP.Project.Api.Application.Commands.Person;

public class CreatePersonCommand : IRequest<bool>
{
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string DocumentNumber { get; set; } = null!;
    public string DocumentType { get; set; } = null!;
    public string Email { get; set; } = null!;

    public CreatePersonCommand() { }

    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DocumentNumber).NotEmpty();
            RuleFor(x => x.DocumentType).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}