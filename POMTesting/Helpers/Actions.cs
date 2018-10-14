using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Configuration;

namespace Store.Helpers
{
    public class Actions
    {
        static public void Select(IWebElement element, string option)
        {
            SelectElement dropdown = new SelectElement(element);
            dropdown.SelectByText(option);
        }

        static public void GoToUrl(IWebDriver driver, string page)
        {
            driver.Navigate().GoToUrl($"{ConfigurationManager.AppSettings["address"]}{page}");
        }
    }
}
