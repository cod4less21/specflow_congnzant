using JECognizantProject.Drivers;
using JECognizantProject.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace JECognizantProject.StepDefinitions
{
    [Binding]
    public sealed class AccountsSteps
    {
        private readonly DriverHelper driverHelper;
        HomePage homePage;
        private string timeStamp => DateTime.Now.ToString("ddMMyyyyhhMMssfff");
        public AccountsSteps(DriverHelper _driverHelper, HomePage _homePage)
        {
            this.driverHelper = _driverHelper;
            homePage = _homePage;
        }


        [Given(@"I am on automationpractice page")]
        public void GivenIAmOnAutomationpracticePage()
        {
            homePage.NavigateTosite();
        }

        [When(@"I choose item '(.*)' and select size as '(.*)' from dropDown, colour '(White|Black)'")]
        public void WhenISelectItemWithName(string itemAlias, string dropdownAlias, string colourAlias)
        {
            homePage.scrollIntoViewofElement(itemAlias);
            homePage.ChooseItemWithParam(itemAlias);
            homePage.selectFromDropdown(dropdownAlias);
            homePage.SelectItemColour(colourAlias);
        }

        [When(@"I click '(.*)' of '(.*)'")]
        public void WhenIClickProceedToCheckOut(string btnNameAlias, string paramName)
        {
            homePage.ClickproceedToCheckOutbtn(paramName, btnNameAlias);
        }

        [When(@"I click Terms of service check box")]
        public void WhenIClickTermsOfServiceCheckBox()
        {
            homePage.ClickTermsOfServiceChkbox();
        }


        [When(@"I click '(.*)' to add item to basket")]
        public void WhenIClickAddToCartButton(string btnNameAlias)
        {
            homePage.ClickAddToCartButton(btnNameAlias);
        }

        [When(@"I enter email as '(.*)'")]
        public void WhenIEnterEmailAs(string emailAlias)
        {
            homePage.enterEmail(
                string.Format(emailAlias, timeStamp));
        }

        [When(@"I click create account button")]
        public void WhenIClickCreatAccountButton()
        {
            homePage.ClickCreateAccountbtn();
        }

        [Then(@"I am on '(.*)' page")]
        public void ThenIAmOnCreateAccountPage(string headerTxtAlias)
        {
            Assert.IsTrue(homePage.IsCreateAccountPageDisplayed(headerTxtAlias));
        }

        [When(@"I select title Mr radio button")]
        public void WhenISelectTitleMr()
        {
            homePage.SelectMaleGender();
        }

        [When(@"I create account with the following personal details:")]
        public void WhenICreateAccountWithTheFollowingPersonalDetails(Table table)
        {
            dynamic tabledetails = 
                table.CreateDynamicInstance();
            homePage.EnterPersonalDetails((string)tabledetails.FirName,
                (string)tabledetails.LastName, (string)tabledetails.Password,
                (string)tabledetails.DOB);
        }

        [When(@"I enter address details as:")]
        public void WhenIEnterAddressDetailsAs(Table table)
        {
            dynamic tabledetails = 
                table.CreateDynamicInstance();
            homePage.EnterAddressDetails((string)tabledetails.Address,
                (string)tabledetails.City, (string)tabledetails.State, 
                (int)tabledetails.ZipCode, (string)tabledetails.Country,
                (long)tabledetails.MobilePhone, (string)tabledetails.AddressAlias);
        }

        [When(@"I click register button")]
        public void WhenIClickRegisterButton()
        {
            homePage.ClickregisterBtn();
        }

        [When(@"I select pay by '(.*)'")]
        public void WhenISelectPayBy(string option)
        {
            homePage.SelectPayoptions(option);
        }

        [Then(@"I see '(.*)' on order confirmation page")]
        public void ThenISeeOnOrderConfirmationPage(string confirmAlias)
        {
            Assert.IsTrue(homePage.IsConfirmationMsgDisplayed(confirmAlias));
        }

        [Then(@"I Logout")]
        public void ThenILogout()
        {
            homePage.ClickSignOutbtn();
        }
    }
}
