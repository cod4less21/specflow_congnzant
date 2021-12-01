using JECognizantProject.ConfigReader;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JECognizantProject.Extensions
{
    public static class DriverExtensions
    {
        public static (IWebElement single, IList<IWebElement> List) FinthisElement(this IWebDriver browser, By element, TimeSpan? time = null)
        {
            WebDriverWait wait = new WebDriverWait(browser, time ?? jsonReader.getTimeOut());
            return (wait.Until(_ => _.FindElement(element)),
                wait.Until(_ => _.FindElements(element)));
        }

        public static void SwitchToIframe(this IWebDriver browser, IWebElement? element) =>
            browser.SwitchTo().Frame(element);

        public static void SwitchToDefaultContent(this IWebDriver browser) =>
            browser.SwitchTo().DefaultContent();

        public static void ScrollIntoViewViaJs(this IWebDriver browser, IWebElement? element) =>
            ((IJavaScriptExecutor)browser).ExecuteScript("arguments[0].scrollIntoView(true);", element);
    }
}
