using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Threading;

namespace JECognizantProject.Extensions
{
    public static class ActionsExtensions
    {
        public static void MoveToElement(this IWebElement element, IWebDriver? browser)
        {
            new Actions(browser).MoveToElement(element).Perform();
        }

        public static void MoveToElementAndClick(this IWebElement element, IWebElement? element2, IWebDriver? browser)
        {
            Actions actions = new Actions(browser);
            actions.MoveToElement(element).Perform();
            Thread.Sleep(1000);
            actions.Click(element2).Perform();
        }
    }
}
