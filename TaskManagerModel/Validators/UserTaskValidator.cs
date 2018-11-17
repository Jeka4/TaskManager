using FluentValidation;

namespace TaskManagerModel.Validators
{
    public class UserTaskValidator : AbstractValidator<UserTask>
    {
        public UserTaskValidator() //Можно добавить сообщения при ошибках валидации
        {
            RuleSet("Id", () => {
                RuleFor(task => task.Id).GreaterThan(0).WithMessage("ID should be greater than 0");
            });

            RuleSet("Body", () => {
                RuleFor(task => task.Name).NotNull().NotEmpty();
                RuleFor(task => task.Description).NotNull().NotEmpty();
            });
        }
    }
}
