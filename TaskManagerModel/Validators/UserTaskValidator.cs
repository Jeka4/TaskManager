using FluentValidation;

namespace TaskManagerModel.Validators
{
    public class UserTaskValidator : AbstractValidator<UserTask>
    {
        public UserTaskValidator()
        {
            RuleSet("Id", () =>
            {
                RuleFor(task => task.Id).GreaterThan(0).WithMessage("should be greater than 0");
            });

            RuleSet("Body", () =>
            {
                RuleFor(task => task.Name).NotNull().NotEmpty().WithMessage("should be not empty");
                RuleFor(task => task.Description).NotNull().NotEmpty().WithMessage("should be not empty");
                RuleFor(task => task.Priority).NotEqual(0).WithMessage("should be defined");
            });
        }
    }
}
