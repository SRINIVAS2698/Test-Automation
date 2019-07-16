using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewerTestFramework.Utilities;

namespace ViewerTestFramework.Main.Pages
{
    
    public class LoginPage
    {
        public IWebDriver driver;
        Waits wait;
        ElementMethods em;

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new Waits(driver);
            em = new ElementMethods(driver);
        }

        [FindsBy(How =How.XPath, Using = "//input[contains(@id,'UserName')]")]
        public IWebElement userNameTxtBox { get; set; }

        [FindsBy(How=How.XPath,Using = "//input[contains(@id,'Password')]")]
        public IWebElement passwordTxtBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'LoginButton')]")]
        public IWebElement loginButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@ng-click='signOut()']")]
        public IWebElement logoutButton { get; set; }


        [FindsBy(How = How.XPath, Using = "//div[@id='userActions']//button[@class='btn dropdown-toggle ng-binding']")]
        public IWebElement toggleButton { get; set; }

        public void LoginToVenue(string username, string password)
        {
            userNameTxtBox.SendKeys(username);
            passwordTxtBox.Clear();
            passwordTxtBox.SendKeys(password);
            loginButton.Click();
            wait.WaitforBrowserLoad();
            wait.WaitForElementToDisplay(em.GetElement("//img[contains(@id,'_VenueDock_C_VenueLogo')]"));
        }

        public void Logout()
        {
            toggleButton.Click();
            logoutButton.Click();
            wait.WaitforBrowserLoad();
        }
    }
}
