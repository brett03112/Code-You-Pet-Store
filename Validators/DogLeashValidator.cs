using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Store.App.Validators
{
    internal class DogLeashValidator: AbstractValidator<DogLeash>
    {
        /// <summary>
        /// Validates a DogLeash object. The object must have a non-empty name and description, and a price and quantity that are greater than zero.
        /// </summary>
        public DogLeashValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Price).GreaterThan(0);
            RuleFor(x => x.Quantity).GreaterThan(0);
        }
    }
}