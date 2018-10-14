using Store.Helpers;

namespace Store.PageObjects
{
    class Step2TestObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }

        public static Step2TestObject GetPersonalDetails()
        {
            return new Step2TestObject()
            {
                FirstName = Randomizer.GenerateFirstName(),
                LastName = Randomizer.GenerateLastName(),
                Email = Randomizer.GenerateEmail(),
                Telephone = Randomizer.GeneratePhone()
            };
        }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public static Step2TestObject GetPassword()
        {
            var password = Randomizer.GeneratePassword();
            return new Step2TestObject()
            {
                Password = password,
                ConfirmPassword = password
            };
        }

        #region Address

        public string CompanyName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }

        public static Step2TestObject GetAddress()
        {
            return new Step2TestObject()
            {
                CompanyName = Randomizer.GenerateCompany(),
                Address1 = Randomizer.GenerateAddress(),
                Address2 = Randomizer.GenerateAddress(),
                City = Randomizer.GenerateCity(),
                Postcode = Randomizer.GenerateCountryCode(),
                Country = "Poland",
                Region = "Slaskie"
            };
        }

        #endregion Address
    }
}