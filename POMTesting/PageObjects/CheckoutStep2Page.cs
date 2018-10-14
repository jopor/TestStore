using NLog;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Store.Helpers;

namespace Store.PageObjects
{
    public class CheckoutStep2Page
    {
        private IWebDriver driver;
        protected static readonly Logger log = LogManager.GetCurrentClassLogger();

        public CheckoutStep2Page(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            Wait.WaitForElementVisible(driver, step2Content);
        }

        [FindsBy(How = How.CssSelector, Using = "div#collapse-payment-address .row")]
        private IWebElement step2Content { get; set; }
        [FindsBy(How = How.ClassName, Using = "alert-danger")]
        private IWebElement warningMessage { get; set; }
        [FindsBy(How = How.ClassName, Using = "text-danger")]
        private IWebElement validationMessage { get; set; }

        #region Step 2: Billing Details 

        #region Personal Details

        [FindsBy(How = How.Id, Using = "input-payment-firstname")]
        private IWebElement firstNameInput { get; set; }
        [FindsBy(How = How.Id, Using = "input-payment-lastname")]
        private IWebElement lastNameInput { get; set; }
        [FindsBy(How = How.Id, Using = "input-payment-email")]
        private IWebElement emailInput { get; set; }
        [FindsBy(How = How.Id, Using = "input-payment-telephone")]
        private IWebElement telephoneInput { get; set; }

        virtual public void SetPersonalDetails()
        {
            var personalDetails = Step2TestObject.GetPersonalDetails();
            firstNameInput.SendKeys(personalDetails.FirstName);
            lastNameInput.SendKeys(personalDetails.LastName);
            emailInput.SendKeys(personalDetails.Email);
            telephoneInput.SendKeys(personalDetails.Telephone);
            log.Info($"Set Personal Details on Checkout Step 2");
        }

        #endregion Personal Details

        #region Password (For Register)

        [FindsBy(How = How.Id, Using = "input-payment-password")]
        private IWebElement passwordInput { get; set; }
        [FindsBy(How = How.Id, Using = "input-payment-confirm")]
        private IWebElement confirmPasswordInput { get; set; }
        [FindsBy(How = How.CssSelector, Using = "div#collapse-payment-address input[name=agree]")]
        private IWebElement privacyPolicyCheckbox { get; set; }
        [FindsBy(How = How.Id, Using = "button-register")]
        protected IWebElement continueAsRegisterButton { get; set; }
        [FindsBy(How = How.Id, Using = "button-payment-address")]
        protected IWebElement continueAsRegiste2rButton { get; set; }

        virtual public void SetPassword()
        {
            var password = Step2TestObject.GetPassword();
            passwordInput.SendKeys(password.Password);
            confirmPasswordInput.SendKeys(password.ConfirmPassword);
            log.Info($"Set Passwords on Checkout Step 2");
        }

        virtual public void CheckPrivacyPolicy()
        {
            if (privacyPolicyCheckbox.GetAttribute("checked") != "checked")
            {
                privacyPolicyCheckbox.Click();
                log.Info($"Check Privacy Policy on Checkout Step 2");
            }
        }

        #endregion Password (For Register)

        #region Address

        [FindsBy(How = How.Id, Using = "input-payment-company")]
        private IWebElement companyInput { get; set; }
        [FindsBy(How = How.Id, Using = "input-payment-address-1")]
        private IWebElement address1Input { get; set; }
        [FindsBy(How = How.Id, Using = "input-payment-address-2")]
        private IWebElement address2Input { get; set; }
        [FindsBy(How = How.Id, Using = "input-payment-city")]
        private IWebElement cityInput { get; set; }
        [FindsBy(How = How.Id, Using = "input-payment-postcode")]
        private IWebElement postcodeInput { get; set; }
        [FindsBy(How = How.Id, Using = "input-payment-country")]
        private IWebElement countryDropdown { get; set; }
        [FindsBy(How = How.Id, Using = "input-payment-zone")]
        private IWebElement regionDropdown { get; set; }

        [FindsBy(How = How.Name, Using = "shipping_address")]
        private IWebElement deliveryAndBilingAddressesCheckbox { get; set; }

        virtual public void SetAddress()
        {
            var address = Step2TestObject.GetAddress();
            companyInput.SendKeys(address.CompanyName);
            address1Input.SendKeys(address.Address1);
            address2Input.SendKeys(address.Address2);
            cityInput.SendKeys(address.City);
            postcodeInput.SendKeys(address.Postcode);
            Actions.Select(countryDropdown, address.Country);
            Actions.Select(regionDropdown, address.Region);
            log.Info($"Set Address on Checkout Step 2");
        }

        virtual public void CheckTheSameAddressForDeliveryAndBiling()
        {
            if (deliveryAndBilingAddressesCheckbox.GetAttribute("checked") != "checked")
            {
                deliveryAndBilingAddressesCheckbox.Click();
                log.Info($"Check 'My delivery and billing addresses are the same' on Checkout Step 2");
            }
        }

        #endregion Address

        virtual public CheckoutStep3Page FinishStep2()
        {
            return new CheckoutStep3Page(driver);
        }

        virtual public void TryToFinishStep2()
        {
        }

        public string GetValidationMessage()
        {
            Wait.WaitForElementVisible(driver, validationMessage);
            log.Info($"Verify validation message on Checkout Step 2");
            return validationMessage.Text.ToString();
        }

        public string GetAlertMessage()
        {
            Wait.WaitForElementVisible(driver, warningMessage);
            log.Info($"Verify alert message on Checkout Step 2");
            return warningMessage.Text.ToString();
        }

        #endregion Step 2: Billing Details 
    }
}