using System;
using cleanteeh.Domain.Exceptions;
namespace cleanTeeth.Domain.valueObjects
{
    public record Email
    {
        public string Value{get;}=null;
        public Email(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new BusinessRuleException($"the {nameof(email)} is required");
            }
            if (!email.Contains("@"))
            {
                throw new BusinessRuleException($"the {nameof(email)} is invalid");
            }
            Value=email;
        }
    }
}