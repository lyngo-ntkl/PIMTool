using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIMTool.Core.Dtos.CustomAttributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Parameter)]
    public class DateEarlierThanAttribute : ValidationAttribute
    {
        private string ComparedDateFieldName { get; set; }
        public DateEarlierThanAttribute(string comparedDateFieldName)
        {
            ComparedDateFieldName = comparedDateFieldName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            DateTime? earlierDate = (DateTime?)value;
            DateTime? laterDate = (DateTime?)validationContext.ObjectType.GetProperty(ComparedDateFieldName).GetValue(validationContext.ObjectInstance);
            if(earlierDate == null || laterDate == null)
            {
                return ValidationResult.Success;
            }
            if (laterDate > earlierDate)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Date is not earlier");
            }
        }
    }
}
