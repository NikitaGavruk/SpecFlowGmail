using GmailTA.Pages;
using GmailTA.WebDrvier;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace SpecFlowGmailProject.Specs.StepDefinitions
{
    [Binding]
    public class GmailMenuStepDefinitions
    {
        private ChooseAnAccountPage _chooseAnAccountPage = new ChooseAnAccountPage();
        private LoginPage _loginPage = new LoginPage();
        private SentPage _sentPage = new SentPage();
        private ComposeMessagePage _composeMessagePage = new ComposeMessagePage();
        private MainPage _mainPage = new MainPage();
        protected static Browser Browser = Browser.Instance;

        [BeforeTestRun]
        public static void CreateWebDriver()
        {
            Browser = Browser.Instance;
            Browser.WindowMaximaze();
            Browser.NavigateTo(Configuration.StartUrl);
        }

        [Given(@"Login to mail")]
        public void LoginToMail()
        {
            _loginPage.Login();
        }

        [When(@"Navigate to '([^']*)'")]
        public void NavigateToPage(string page)
        {
            _mainPage.NavigateToPage(page);
        }

        [Then(@"Verify that '([^']*)' title is correct")]
        public void VerifyThatTitleIsCorrect(string title)
        {
            Assert.True(AbstractPage.IsPageLoadedByTitle(title));
        }


        [When(@"Write mail to '(.*)' with '(.*)' subject and '(.*)' bodyMail")]
        public void WriteMailToWithSubjectAndBodyMail(string to,string subject, string bodyMail)
        {
            _composeMessagePage.FillFullMail(to, subject, bodyMail);
        }

        [When(@"Send mail")]
        public void SendMail()
        {
            _composeMessagePage.SendMail();
        }
        [When(@"Navigate to Sent page")]
        public void ThenNavigateToSentPage()
        {
            _mainPage.NavigateToSentPage();
        }

        [Then(@"Verfiy mail with '(.*)' subject succesfully sent")]
        public void VerfiyMailWithSubjectSuccesfullySent(string subject)
        {
            Assert.IsTrue(_sentPage.VerfiyMailAsSent(subject));
        }

        [AfterTestRun]
        public void LogOut()
        {
            _chooseAnAccountPage.LogoutFromAccount();
        }
        [AfterTestRun]
        public static void TestTearDown()
        {
            Browser.QuiteBrowser();
        }
    }
}
