using CSharpFunctionalExtensions;
using Kind_heart.Domain.Shared;

namespace Kind_heart.Domain.ValueObjects;

public record Address
{
    public string Country { get; } = default!;
    public string City { get; } = default!;
    public string StreetName { get; } = default!;
    public int Number { get; } = default!;
    public int ZipCode { get; } = default!;

    private Address(string country, 
                    string city, 
                    string streetName, 
                    int number, 
                    int zipCode)
    {
        Country = country;
        City = city;
        StreetName = streetName;
        Number = number;
        ZipCode = zipCode;
    }

    public static Result<Address> Create(string country, 
                                            string city, 
                                            string streetName, 
                                            int number, 
                                            int zipCode)
    {
        if(string.IsNullOrWhiteSpace(country) || country.Length > Constants.MAX_LOW_TEXT_LENGTH)
            return Result.Failure<Address>("Country is invalid");
        
        if(string.IsNullOrWhiteSpace(city) || city.Length > Constants.MAX_LOW_TEXT_LENGTH)
            return Result.Failure<Address>("City is invalid");
        
        if(string.IsNullOrWhiteSpace(streetName) || streetName.Length > Constants.MAX_LOW_TEXT_LENGTH)
            return Result.Failure<Address>("StreetName is invalid");
        
        if (number <= 0 || number > Constants.MAX_HOUSE_NUMBER)
            return Result.Failure<Address>("HouseNumber must be a positive number and within the allowed range.");
        
        if (zipCode <= 0 )
            return Result.Failure<Address>("HouseNumber must be a positive number.");
        
        return new Address(country, city, streetName, number, zipCode);
    }
    
}