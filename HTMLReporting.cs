using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewerTestFramework.Utilities
{
    public class HTMLReporting
    {
        public static ExtentReports extent;
        public static ExtentTest featureName;
        public static ExtentTest scenario;

        public static ExtentHtmlReporter HTMLReporter()
        {
            var reportPath = Operations.GetFolderPath("HTMLReports") + @"\ViewerTestReport.html";
            return new ExtentHtmlReporter(reportPath);
        }

        public static void InitReports()
        {
            var htmlReporter = HTMLReporter();
            htmlReporter.Configuration().ChartVisibilityOnOpen = true;
            // report title
            htmlReporter.Configuration().DocumentTitle = "aventstack - ExtentReports";
            // encoding, default = UTF-8
            htmlReporter.Configuration().Encoding = "UTF-8";
            // protocol (http, https)
            htmlReporter.Configuration().Protocol = Protocol.HTTPS;
            htmlReporter.Configuration().Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            htmlReporter.AppendExisting = true;
            // chart location - top, bottom
            htmlReporter.Configuration().ChartLocation = ChartLocation.Bottom;
            // add custom css
            htmlReporter.Configuration().CSS = "css-string";
            // add custom javascript
            htmlReporter.Configuration().JS = "js-string";
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }
    }
}
