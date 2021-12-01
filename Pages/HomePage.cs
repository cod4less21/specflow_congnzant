using JECognizantProject.ConfigReader;
using JECognizantProject.Drivers;
using JECognizantProject.Extensions;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace JECognizantProject.Pages
{
    public class HomePage
    {
        private readonly DriverHelper driverHelper;
        private string url => jsonReader.getAutoUrl();

        public HomePage(DriverHelper driverHelper)
        {
            this.driverHelper = driverHelper;
        }

        private IWebElement? ItemToChoose(string name) =>
            driverHelper.browser?
            .FinthisElement(By.XPath($"//*[@id='homefeatured']//li//div//a[contains(text(), '{name}')]//ancestor::li")).single;

        private IWebElement? Quickview =>
            driverHelper.browser?.FinthisElement(By.XPath("(//*[@class='quick-view'])[2]")).single;

        private IWebElement? selectsize =>
            driverHelper.browser?
            .FinthisElement(By.XPath("//select[@name='group_1']")).single;

        private IWebElement? addtobasket(string param) =>
            driverHelper.browser?.FinthisElement(By.Id($"{param}")).single;

        private IWebElement? iframeFancybox =>
            driverHelper.browser?
            .FinthisElement(By.XPath("//iframe[@class='fancybox-iframe']")).single;

        private IWebElement? ChooseColour(string text) =>
            driverHelper.browser?.FinthisElement(By.XPath($"//a[@name='{text}']"))
            .single;

        private IWebElement? proceedToCheckOut(string param,string btnName) =>
            driverHelper.browser?
            .FinthisElement(By.XPath($"//*[@id='{param}' or @name='{param}']//span[contains(text(), '{btnName}')]")).single;
        
        private IWebElement? emailfield =>
            driverHelper.browser?.FinthisElement(By.Id("email_create")).single;


        private IWebElement? signOut =>
            driverHelper.browser?.FinthisElement(By.LinkText("Sign out")).single;

        private IWebElement? createAccountbtn =>
            driverHelper.browser?.FinthisElement(By.Id("SubmitCreate")).single;

        private IWebElement? createAccountPage(string headerTxt) =>
            driverHelper.browser?
            .FinthisElement(By.XPath($"//h1[@class='page-heading'][.='{headerTxt}']")).single;


        private IWebElement? submitAccount =>
            driverHelper.browser?
            .FinthisElement(By.XPath("//*[@id='submitAccount']/span")).single;

        private IWebElement? MaleGender =>
            driverHelper.browser?
            .FinthisElement(By.XPath("//*[@for='id_gender1']")).single;


        private IWebElement? FirstName =>
             driverHelper.browser?
            .FinthisElement(By.Id("customer_firstname")).single;
        private IWebElement? LastName =>
            driverHelper.browser?
            .FinthisElement(By.Id("customer_lastname")).single;
        private IWebElement? PassWord =>
            driverHelper.browser?
            .FinthisElement(By.Id("passwd")).single;
        private IWebElement? Day =>
            driverHelper.browser?
            .FinthisElement(By.Id("days")).single;
        private IWebElement? Months =>
            driverHelper.browser?
            .FinthisElement(By.Id("months")).single;
        private IWebElement? Years =>
            driverHelper.browser?
            .FinthisElement(By.Id("years")).single;


        private IWebElement? Address =>
            driverHelper.browser?
            .FinthisElement(By.Id("address1")).single;
        private IWebElement? City =>
           driverHelper.browser?
           .FinthisElement(By.Id("city")).single;
        private IWebElement? State =>
           driverHelper.browser?
           .FinthisElement(By.Id("id_state")).single;
        private IWebElement? PostCode =>
           driverHelper.browser?
           .FinthisElement(By.Id("postcode")).single;
        private IWebElement? Country =>
          driverHelper.browser?
          .FinthisElement(By.Id("id_country")).single;
        private IWebElement? Mobile =>
          driverHelper.browser?
          .FinthisElement(By.Id("phone_mobile")).single;
        private IWebElement? Alias =>
         driverHelper.browser?
         .FinthisElement(By.Id("alias")).single;


        private IWebElement? TermsOfServiceChkbox =>
            driverHelper.browser?
         .FinthisElement(By.XPath("//p[@class='checkbox']/label")).single;

        private IWebElement? Payoptions(string option) =>
             driverHelper.browser?
         .FinthisElement(By.XPath($"//*[@id='HOOK_PAYMENT']//a[@class='{option}']")).single;

        private IWebElement? confirmationMsg(string headerTxt) =>
            driverHelper.browser?
            .FinthisElement(By.XPath($"//h1[@class='page-heading'][.='Order confirmation']//parent::div/div/p")).single;
        

        public void NavigateTosite()
        {
            driverHelper.browser?.Navigate().GoToUrl(url);
            driverHelper.browser?.waitForPageLoad();
        }
            
        public void ChooseItemWithParam(string text)=>
            ItemToChoose(text)?.MoveToElementAndClick(Quickview,driverHelper.browser);

        public void selectFromDropdown(string text)
        {
            driverHelper.browser?.SwitchToIframe(iframeFancybox);
            selectsize?.SelectByText(text);
        }

        public void scrollIntoViewofElement(string name) =>
            driverHelper.browser?.ScrollIntoViewViaJs(ItemToChoose(name));

        public void SelectItemColour(string text) => ChooseColour(text)?.Click();

        public void ClickAddToCartButton(string param)
        {
            addtobasket(param)?.Click();
            driverHelper.browser?.SwitchToDefaultContent();
        }

        public void ClickproceedToCheckOutbtn(string param, string name)
        {
            Thread.Sleep(2000);
            proceedToCheckOut(param, name)?.Click();
            Thread.Sleep(2000);
        }
            

        public void enterEmail(string txt)=> emailfield?.SendKeys(txt);

        public void ClickCreateAccountbtn() => createAccountbtn?.Click();

        public bool? IsCreateAccountPageDisplayed(string param)
        {
            Thread.Sleep(2000);
            return createAccountPage(param)?.Displayed;
        }

        public bool? IsConfirmMsgDisplayed(string param) => createAccountPage(param)?.Displayed;

        public bool? IsConfirmationMsgDisplayed(string param) => confirmationMsg(param)?.Displayed;

        public void SelectMaleGender() => MaleGender?.Click();

        public void ClickregisterBtn() => submitAccount?.Click();

        public void EnterPersonalDetails(string fName, string LName, string pass, string dob)
        {
            FirstName?.SendKeys(fName);
            LastName?.SendKeys(LName);
            PassWord?.SendKeys(pass);
            var dateOfBirth = dob.Split(':');
            Day?.SelectByValue(dateOfBirth[0].ToString());
            Months?.SelectByValue(dateOfBirth[1].ToString());
            Years?.SelectByValue(dateOfBirth[2].ToString());
        }

        public void EnterAddressDetails(string address, string city,
            string state, int pCode, string country, long mobile, string alias)
        {
            Address?.SendKeys(address);
            City?.SendKeys(city);
            State?.SelectByText(state);
            PostCode?.SendKeys(pCode.ToString());
            Country?.SelectByText(country);
            Mobile?.SendKeys(mobile.ToString());
            Alias?.SendKeys(alias);
        }

        public void ClickTermsOfServiceChkbox() => TermsOfServiceChkbox?.Click();

        public void SelectPayoptions(string option)=> Payoptions(option)?.Click();

        public void ClickSignOutbtn()=> signOut?.Click();
    }
}
