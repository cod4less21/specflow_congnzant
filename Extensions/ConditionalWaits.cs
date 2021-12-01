using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JECognizantProject.Enums.EnumTypes;

namespace JECognizantProject.Extensions
{
    public static class ConditionalWaits
    {
        public static void waitForPageLoad(this IWebDriver browser)
        {
            browser.WaitForcondition(_ =>
            {
                string? state = ((IJavaScriptExecutor)browser)
                .ExecuteScript("return document.readyState").ToString();
                return state == "complete";
            }, (int)EnumType.Thirthy);
        }

        public static void WaitForcondition<T>(this T obj, Func<T, bool> condition, int timeout)
        {
            Func<T, bool> execute = (args) =>
            {
                try
                {
                    return condition(args);
                }
                catch (Exception)
                {
                    return false;
                }
            };
            var stopwatch = Stopwatch.StartNew();
            while (stopwatch.ElapsedMilliseconds < timeout)
            {
                if (execute(obj))
                {
                    break;
                }
            }
        }
    }
}
