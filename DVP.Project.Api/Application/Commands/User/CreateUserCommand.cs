using FluentValidation;
using MediatR;

namespace DVP.Project.Api.Application.Commands.User;

public class CreateUserCommand : IRequest<bool>
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;

    public CreateUserCommand() { }

    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();
        }
    }
}