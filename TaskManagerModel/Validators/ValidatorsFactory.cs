using System;
using FluentValidation;

namespace TaskManagerModel.Validators
{
    internal class ValidatorsFactory
    {
        private readonly AbstractValidator<UserTask> _userTaskValidator;
        private readonly AbstractValidator<DateTime> _todadyDateValidator;

        public ValidatorsFactory()
        {
            _userTaskValidator = new UserTaskValidator();
            _todadyDateValidator = new TodayDateValidator();
        }

        public AbstractValidator<UserTask> GetUserTaskValidator()
        {
            return _userTaskValidator;
        }

        public AbstractValidator<DateTime> GetTodayDateValidator()
        {
            return _todadyDateValidator;
        }
    }
}
