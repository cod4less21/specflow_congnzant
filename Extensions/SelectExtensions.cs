

using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace JECognizantProject.Extensions
{
    public static class SelectExtensions
    {
       public static void SelectByText(this IWebElement element, string text)
       {
            SelectElement ss = new SelectElement(element);
            ss.SelectByText(text);
       }
        public static void SelectByValue(this IWebElement element, string text)
        {
            SelectElement ss = new SelectElement(element);
            ss.SelectByValue(text);
        }
    }
}
