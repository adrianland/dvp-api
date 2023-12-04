using FluentValidation;
using MediatR;

namespace DVP.Project.Api.Application.Commands.Person;

public class UpdatePersonCommand : IRequest<bool>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string DocumentNumber { get; set; } = null!;
    public string DocumentType { get; set; } = null!;
    public string Email { get; set; } = null!;

    public UpdatePersonCommand() { }

    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.DocumentNumber).NotEmpty();
            RuleFor(x => x.DocumentType).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}