using FluentValidation;
using MediatrPlayground.Dal;
using MediatrPlayground.Models.Requests;

namespace MediatrPlayground.Validators;

public class PostUserValidator : AbstractValidator<PostUserRequest>
{
    private readonly IUserRepository _repository;

    public PostUserValidator(IUserRepository repository)
    {
        _repository = repository;

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MustAsync(BeANewUser)
            .WithMessage("User already exists.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required.")
            .MinimumLength(8)
            .WithMessage("Password must be at least 8 characters long.")
            .Matches("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$")
            .WithMessage("Password must contain one letter, one number, and one special character.");

        RuleFor(x => x.ConfirmPassword)
            .NotEmpty()
            .WithMessage("Confirm password is required.")
            .Equal(x => x.Password)
            .WithMessage("Confirm password must match password.");
    }

    private async Task<bool> BeANewUser(string? name, CancellationToken cancellationToken)
    {
        var user = await _repository.FindUserByName(name);
        return user is null;
    }
}