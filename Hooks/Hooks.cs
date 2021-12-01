using JECognizantProject.Drivers;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace JECognizantProject.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly DriverHelper driverHelper;
        ChromeOptions? options;
        public Hooks(DriverHelper _driverHelper)
        {
            this.driverHelper = _driverHelper;
        }

        [BeforeScenario]
        public void BeforeScenarioWithTag()
        {
            options = new ChromeOptions();
            options.AddArguments("start-maximized", "incognito");
            driverHelper.browser = new ChromeDriver(options);
        }


        [AfterScenario]
        public void AfterScenario()
        {
            driverHelper.browser?.Quit();
            driverHelper.browser = null;
        }
    }
}