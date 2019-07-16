using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewerTestFramework.Utilities
{
    public static class ImageUtils
    {
        /// <summary>
        /// This method will take a screenshot and save it to a local folder
        /// </summary>
        /// <returns></returns>
        public static string TakeScreenShot()
        {
            var imgName = DateTime.Now.Ticks.ToString();
            ITakesScreenshot ts = (ITakesScreenshot)Hooks.driver;
            Screenshot scr = ts.GetScreenshot();
            var screenshotPath = Operations.GetFolderPath("Screenshots")+@"\"+imgName+".png";
            scr.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            return screenshotPath;
        }

        /// <summary>
        /// This method will generate the base64 format of an image
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public static string ConvertToBase64Image(string imagePath)
        {
            string imgFormat;
            using (System.Drawing.Image image = System.Drawing.Image.FromFile(imagePath))
            {
                using (MemoryStream m = new MemoryStream())
                {
                    string base64String;
                    image.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();
                    base64String = Convert.ToBase64String(imageBytes);
                    imgFormat = "data:image/png;base64," + base64String;
                }
            }
            return imgFormat;
        }

        /// <summary>
        /// This method will genereate the HTML string for the base64 Image format
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        public static string GenerateHTMLForBase64(string imagePath)
        {
            var title = ConvertToBase64Image(imagePath);
            var base64HTMLContent = $@"<img src=""{title}""</img>";  //Note the order of the $@
            return base64HTMLContent;
        }

    }
}
