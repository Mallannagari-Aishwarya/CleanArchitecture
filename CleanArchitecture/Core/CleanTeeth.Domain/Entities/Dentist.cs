using cleanteeh.Domain.Exceptions;
using cleanTeeth.Domain.valueObjects;

namespace cleanTeeth.Domain.Entities{
public class Dentist
{
    public Guid Id{get ;private set;}
    public string Name{get;private set;}=null;
    public Email Email{get;private set;}=null;

    public Dentist(string name,Email email)
    {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BusinessRuleException($"the {nameof(name)} is required");
            }
            if(Email is null)
            {
                throw new BusinessRuleException($"The {nameof(name)} is required");
            }
            Name=name;
            Email=email;
            Id=Guid.CreateVersion7();
    }

}
}