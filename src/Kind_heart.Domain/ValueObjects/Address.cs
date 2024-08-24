using CSharpFunctionalExtensions;
using Kind_heart.Domain.Shared;

namespace Kind_heart.Domain.ValueObjects;

public record Address
{
    public NotEmptyString Country { get; } = default!;
    public NotEmptyString City { get; } = default!;
    public NotEmptyString StreetName { get; } = default!;
    public int Number { get; } = default!;
    public int ZipCode { get; } = default!;

    private Address(NotEmptyString country, NotEmptyString city, NotEmptyString streetName, int number, int zipCode)
    {
        Country = country;
        City = city;
        StreetName = streetName;
        Number = number;
        ZipCode = zipCode;
    }

    public static Result<Address> Create(NotEmptyString country, NotEmptyString city, NotEmptyString streetName, int number, int zipCode)
    {
        if (number <= 0 || number > Constants.MAX_HOUSE_NUMBER)
            return Result.Failure<Address>("HouseNumber must be a positive number and within the allowed range.");
        
        if (zipCode <= 0 )
            return Result.Failure<Address>("HouseNumber must be a positive number.");
        
        return new Address(country, city, streetName, number, zipCode);
    }
    
}