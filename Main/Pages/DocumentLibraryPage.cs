using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ViewerTestFramework.Utilities;

namespace ViewerTestFramework.Main.Pages
{
    public class DocumentLibraryPage
    {
        public IWebDriver driver;
        Waits wait;
        ElementMethods em;
        ActionsMethods actionMethod;

        public DocumentLibraryPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
            wait = new Waits(driver);
            actionMethod = new ActionsMethods(driver);
            em = new ElementMethods(driver);
        }

        [FindsBy(How = How.XPath, Using = "//input[@value='favorites']")]
        public IWebElement favoritesRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='index']")]
        public IWebElement indexRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='tree']")]
        public IWebElement treeViewRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[contains(@ng-if,'details.BulkPrintInd')]/span")]
        public IWebElement bulkPrintBtn { get; set; }

        [FindsBy(How = How.Id, Using = "tab-admin")]
        public IWebElement adminTab { get; set; }

        [FindsBy(How = How.Id, Using = "tab-users")]
        public IWebElement usersTab { get; set; }

        [FindsBy(How = How.Id, Using = "tab-search")]
        public IWebElement searchTab { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'_rbProjectSettings')]")]
        public IWebElement settingsRadioBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'btnGlobalProjectSettingsEditDetails_input')]")]
        public IWebElement editSettingsBtn { get; set; }

        [FindsBy(How=How.XPath, Using = "//input[contains(@id,'_cmbSecureViewer_Input')]")]
        public IWebElement defaultSecureViewerDpdwn { get; set; }

        [FindsBy(How=How.XPath, Using = "//div[contains(@id,'_cmbbxSecureViewerSetting') and not(contains(@style,'display: block'))]")]
        public IWebElement displayRestrictedOfficeFilesDpdwn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'_cmbbxNotesFunctionality_Input')]")]
        public IWebElement projectNotesDpdwn { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[contains(@id,'_btnGlobalProjectSettingsSave_input')]")]
        public IWebElement saveSettingsBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@id,'_cmbSecureViewerAltLinks') and @class='RadComboBox RadComboBox_Default']")]
        public IWebElement showSecureViewerLinkDpdwn { get; set; }

        [FindsBy(How = How.XPath, Using = "(//input[contains(@id,'_rwConfirmGlobalProjectSettings_')])[1]")]
        public IWebElement confirmButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@id='userActions']//button[@class='btn dropdown-toggle ng-binding']")]
        public IWebElement userActionsMenu { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[@ng-click='signOut()']")]
        public IWebElement adminSignOutLink { get; set; }

        [FindsBy(How= How.XPath, Using = "//div[@id='divAdminRibbonControl']")]
        public IWebElement adminRibbonControl { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='LinkButton']//a[text()='View One HTML5 Viewer']")]
        public IWebElement viewOneHTML5ViewerLink { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='LinkButton']//a[text()='View One Java Viewer']")]
        public IWebElement viewOneJavaViewerLink { get; set; }

        [FindsBy(How=How.XPath, Using = "//tbody/tr[contains(@class,'ng-scope movecopydelete')]")]
        public IWebElement favoritesGridRows { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='pcc-tab-item pcc-active']//span[@class='pcc-icon pcc-icon-view']")]
        public IWebElement viewIconDocumentViewer { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@class='daejaHX daejaLFB']")]
        public IWebElement viewOnTabHeadDocumentViewer { get; set; }

        [FindsBy(How = How.XPath, Using = "//span[@class='k-link']//span[text()='View Index as this Group']")]
        public IWebElement viewIndexAsThisGroupContextmenu { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@ng-model='searchForm.SearchTerm']")]
        public IWebElement searchTxtBx { get; set; }

        [FindsBy(How = How.XPath, Using = "//button[@ng-click='searchBtnClick()']")]
        public IWebElement searchBtn { get; set; }

        public By javaViewer = By.XPath("//div[@class='LinkButton']//a[text()='Java Viewer']");

        public By accusoftHTMLViewer = By.XPath("//div[@class='LinkButton']//a[text()='HTML Viewer']");

        public By alternateHTML5Viewer = By.XPath("//div[@class='LinkButton']//a[text()='Alternate HTML5 Viewer']");

        public void SelectFavoritesRadioBtn()
        {
            wait.WaitForElementToBeClickable(favoritesRadioBtn);
            favoritesRadioBtn.Click();
            IWebElement allFavoritesLabel = driver.FindElement(By.XPath("//span[text()='All Favorite Documents']"));
            wait.WaitForElementToDisplay(allFavoritesLabel);
            Thread.Sleep(2000);
        }

        public void SelectIndexRadioBtn()
        {
            wait.WaitForElementToBeClickable(indexRadioBtn);
            indexRadioBtn.Click();
            Thread.Sleep(3000);
        }

        public void DoBulkPrint()
        {
            wait.WaitForElementToBeClickable(bulkPrintBtn);
            bulkPrintBtn.Click();
        }

        public void GoToAdminTab()
        {
            wait.WaitForElementToBeClickable(adminTab);
            adminTab.Click();
            wait.WaitforBrowserLoad();
            wait.WaitForElementToDisplay(adminRibbonControl);            
        }

        public void GoToUsersTab()
        {
            wait.WaitForElementToBeClickable(usersTab);
            usersTab.Click();
            wait.WaitforBrowserLoad();
            wait.WaitForElementToBeClickable(em.GetElement("//div[@class='ng-scope k-top k-bot']//span[text()='Automation Testing']"));
        }

        public void GoToSearchTab()
        {
            wait.WaitForElementToBeClickable(searchTab);
            searchTab.Click();
            wait.WaitforBrowserLoad();
            wait.WaitForElementToBeClickable(searchBtn);
        }

        public void SelectViewIndexContextMenuTreeView(string userType)
        {
            IWebElement ele = em.GetElement("//span[@class='preWrap ng-binding' and text()=\"" + userType + "\"]");
            Thread.Sleep(5000);
            wait.WaitForElementToBeClickable(ele);
            actionMethod.RightClickOnElement(ele);
            Thread.Sleep(2000);
            wait.WaitForElementToBeClickable(viewIndexAsThisGroupContextmenu);
            viewIndexAsThisGroupContextmenu.Click();
        }

        public void GoToSettings()
        {
            settingsRadioBtn.Click();
            IWebElement ele = driver.FindElement(By.XPath("//span[@class='rpText' and text()='GLOBAL PROJECT SETTINGS']"));
            wait.WaitForElementToDisplay(ele);
        }

        public void ClickOnEditSettings()
        {
            editSettingsBtn.Click();
            wait.WaitforBrowserLoad();            
            wait.WaitForElementToBeClickable(saveSettingsBtn); 
        }

        public void SelectDefaultSecureViewer(string viewerName)
        {
            defaultSecureViewerDpdwn.Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[@class='rcbScroll rcbWidth']//ul//li[text()=\"" + viewerName + "\"]")).Click();
            Thread.Sleep(2000);
        }

        public void SelectDisplayRestrictedOfficeFiles(string settingSwitch)
        {
            displayRestrictedOfficeFilesDpdwn.Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//div[contains(@id,'_cmbbxSecureViewerSetting') and (contains(@style,'display: block'))]//ul//li[text()=\"" + settingSwitch + "\"]")).Click();
            Thread.Sleep(2000);
        }

        public void SelectProjectNotesFunctionality(string settingSwitch)
        {
            projectNotesDpdwn.Click();
            Thread.Sleep(2000);            
            driver.FindElement(By.XPath("//div[@class='rcbScroll rcbWidth']//ul[@class='rcbList']//li[text()=\"" + settingSwitch + "\"]")).Click();
            Thread.Sleep(2000);
        }

        public void SetSecureViewerShowLinks(string settingSwitch)
        {
            showSecureViewerLinkDpdwn.Click();
            IWebElement switchEle = driver.FindElement(By.XPath("//div[@class='rcbScroll rcbWidth']//ul[@class='rcbList']//li[text()=\"" + settingSwitch + "\"]"));
            wait.WaitForElementToBeClickable(switchEle);
            switchEle.Click();
            Thread.Sleep(2000);
        }

        public void SaveProjectSettings()
        {
            saveSettingsBtn.Click();
            wait.WaitforBrowserLoad();
            wait.WaitForElementToBeClickable(confirmButton);
        }

        public void ConfirmSettings()
        {
            confirmButton.Click();            
            Thread.Sleep(3000);
        }

        public void MoveToUserActions()
        {
            //actionMethod.MoveToElement(userActionsMenu);
            wait.WaitForElementToBeClickable(userActionsMenu);
            userActionsMenu.Click();
        }

        public void ClickOnAdminSignout()
        {
            wait.WaitForElementToDisplay(adminSignOutLink);
            adminSignOutLink.Click();
        }

        public void GoToTreeViewUsersTab()
        {
            wait.WaitForElementToBeClickable(treeViewRadioBtn);
            treeViewRadioBtn.Click();
        }

        public void DoQuickSearch(string searchValue)
        {
            wait.WaitForElementToDisplay(searchTxtBx);
            searchTxtBx.SendKeys(searchValue);            
            wait.WaitForElementToBeClickable(searchBtn);
            searchBtn.Click();
            wait.WaitForLoader();
        }
    }
}
