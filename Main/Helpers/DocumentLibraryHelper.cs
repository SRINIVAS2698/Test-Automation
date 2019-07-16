using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using ViewerTestFramework.Main.Pages;
using ViewerTestFramework.Utilities;

namespace ViewerTestFramework.Main.Helpers
{
    class DocumentLibraryHelper
    {
        IWebDriver driver;
        LoginPage loginPage;
        DocumentLibraryPage documentLibraryPage;
        ElementMethods em;
        Waits wait;
        BrowserCommands browser;
        public DocumentLibraryHelper(IWebDriver driver)
        {
            this.driver = driver;
            documentLibraryPage = new DocumentLibraryPage(driver);
            loginPage = new LoginPage(driver);
            wait = new Waits(driver);
            em = new ElementMethods(driver);
            browser = new BrowserCommands(driver);
        }

        public void DoAdminSignout()
        {
            documentLibraryPage.MoveToUserActions();
            wait.WaitForElementToBeClickable(documentLibraryPage.adminSignOutLink);
            documentLibraryPage.ClickOnAdminSignout();
            wait.WaitforBrowserLoad();
            wait.WaitForElementToDisplay(loginPage.userNameTxtBox);
         }

        public void SignOut(string signouturl)
        {
            browser.OpenURL(signouturl);
            wait.WaitForElementToBeClickable(loginPage.loginButton);
        }

        public IWebElement GenerateDocumentLink(string fileName)
        {
            return em.GetElement("//td//a[text()=\"" + fileName + "\"]");
        }

        public void SecureViewerSetting(string secureViewer,string flag)
        {
            documentLibraryPage.GoToAdminTab();
            documentLibraryPage.GoToSettings();
            documentLibraryPage.ClickOnEditSettings();            
            documentLibraryPage.SelectDisplayRestrictedOfficeFiles("On");//NewAdd
            documentLibraryPage.SelectDefaultSecureViewer(secureViewer);
            documentLibraryPage.SetSecureViewerShowLinks(flag);
            documentLibraryPage.SaveProjectSettings();
            documentLibraryPage.ConfirmSettings();            
        }

        public void ViewDocumentLibraryAs(string userType)
        {
           // documentLibraryPage.GoToUsersTab();
            var url = browser.GetCurrentURL();            
            var urlParts = Regex.Split(url, "rrdsunprogs", RegexOptions.IgnoreCase);
            string usersTabURL = urlParts[0] + "/rrdsunprogs/DocumentLibrary.aspx?Tab=#/users";
            browser.OpenURL(usersTabURL);
            wait.WaitforBrowserLoad();
            documentLibraryPage.GoToTreeViewUsersTab();
            Thread.Sleep(2000);
            documentLibraryPage.SelectViewIndexContextMenuTreeView(userType);
            wait.WaitForBrowserPopup();
        }

        public void SelectDisplayRestrictedOfficeFiles(string viewerType,string flag)
        {            
            documentLibraryPage.GoToAdminTab();
            documentLibraryPage.GoToSettings();
            documentLibraryPage.ClickOnEditSettings();
            documentLibraryPage.SelectDefaultSecureViewer(viewerType);
            documentLibraryPage.SetSecureViewerShowLinks("Yes");
            documentLibraryPage.SelectDisplayRestrictedOfficeFiles(flag);
            documentLibraryPage.SaveProjectSettings();
            documentLibraryPage.ConfirmSettings();
        }

    }
}
