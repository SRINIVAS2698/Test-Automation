using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewerTestFramework.Utilities
{
    public class BrowserWindows
    {
        IWebDriver driver;
        public BrowserWindows(IWebDriver driver)
        {
            this.driver = driver;
        }

        public List<string> GetCurrentWindows()
        {
            return driver.WindowHandles.ToList();
        }

        public void SwitchToWindow(string window)
        {
            driver.SwitchTo().Window(window);
        }

        public void CloseSwitchedToWindow(string window)
        {
            driver.SwitchTo().Window(window).Close();
        }

        public void SwitchToLastWindow()
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }
    }
}
