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

    public static Result<Address, Error> Create(string country, 
                                            string city, 
                                            string streetName, 
                                            int number, 
                                            int zipCode)
    {
        if (string.IsNullOrWhiteSpace(country) || country.Length > Constants.MAX_LOW_TEXT_LENGTH)
            return Errors.General.ValueIsInvalide("Country");
        
        if(string.IsNullOrWhiteSpace(city) || city.Length > Constants.MAX_LOW_TEXT_LENGTH)
            return Errors.General.ValueIsInvalide("City");
        
        if(string.IsNullOrWhiteSpace(streetName) || streetName.Length > Constants.MAX_LOW_TEXT_LENGTH)
            return Errors.General.ValueIsInvalide("StreetName");
        
        if (number <= 0 || number > Constants.MAX_HOUSE_NUMBER)
            return Errors.General.ValueIsInvalide("HouseNumber");
        
        if (zipCode <= 0 )
            return Errors.General.ValueIsInvalide("HouseNumber");
        
        return new Address(country, city, streetName, number, zipCode);
    }
    
}