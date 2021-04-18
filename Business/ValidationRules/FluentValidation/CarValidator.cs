using System;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.Description).MinimumLength(2);
            RuleFor(p => p.CarId).NotEmpty();
            RuleFor(p => p.ColorId).NotEmpty();
            RuleFor(p => p.DailyPrice).GreaterThan(0).When(p => p.ColorId == 1);
            RuleFor(p => p.Description).Must(StartWithA).WithMessage("Description A Harfi ile başlamalı");

        }

        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
