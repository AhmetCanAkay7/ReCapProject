﻿using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Email).NotEmpty();
            RuleFor(u => u.PasswordHash).NotEmpty();
            RuleFor(u => u.FirstName).NotEmpty();
            RuleFor(u => u.LastName).NotEmpty();
            //RuleFor(u => u.PasswordHash).Must(IncludeCertainCharachters);
        }

        private bool IncludeCertainCharachters(string arg)
        {
            if (arg.Contains('A') && arg.Contains("1")) {
                return true;
            }
            return false;
        }
    }
}
