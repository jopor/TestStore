using Bogus;

namespace Store.Helpers
{
    public class Randomizer
    {
        public static string GenerateFirstName() => new Faker().Person.FirstName;

        public static string GenerateLastName() => new Faker().Person.LastName;

        public static string GenerateEmail() => new Faker().Person.Email;

        public static string GeneratePhone() => new Faker().Person.Phone;

        public static string GenerateCompany() => new Faker().Company.CompanyName();

        public static string GenerateAddress() => new Faker().Address.StreetAddress();

        public static string GenerateCity() => new Faker().Address.City();

        public static string GenerateCountryCode() => new Faker().Address.CountryCode();

        public static string GeneratePassword() => new Faker().Internet.Password();
    }
}

