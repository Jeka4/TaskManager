using FluentValidation;

namespace TaskManagerModel.Validators
{
    public class UserTaskValidator : AbstractValidator<UserTask>
    {
        public UserTaskValidator() //Можно добавить сообщения при ошибках валидации
        {
            RuleFor(task => task.Id).GreaterThan(0).WithMessage("ID should be greater than 0");
            RuleFor(task => task.Name).NotNull().NotEmpty();
            RuleFor(task => task.Description).NotNull().NotEmpty();
            //RuleFor(task => task.Priority).NotNull().NotEmpty();
        }
    }
}
