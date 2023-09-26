using System;
using System.ComponentModel.DataAnnotations;

namespace TestApp2.Models
{
    public class Min18YearIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
                return ValidationResult.Success;


            int age = DateTime.Today.Year - customer.BirthDay.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Min 18 Years Old");
        }
    }
}