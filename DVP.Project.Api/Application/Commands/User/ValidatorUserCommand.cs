using FluentValidation;
using MediatR;

namespace DVP.Project.Api.Application.Commands.User;

public class ValidatorUserCommand : IRequest<string>
{
    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;

    public ValidatorUserCommand() { }

    public class ValidatorUserCommandValidator : AbstractValidator<ValidatorUserCommand>
    {
        public ValidatorUserCommandValidator()
        {
            RuleFor(x => x.Username).NotEmpty();
            RuleFor(x => x.Username).NotEmpty();
        }
    }
}