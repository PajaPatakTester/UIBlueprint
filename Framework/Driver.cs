using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework
{
    public static class Driver
    {
        public static readonly TimeSpan ImplicitWaitTimeout = TimeSpan.FromSeconds(15);
        public static readonly TimeSpan PageLoad = TimeSpan.FromSeconds(45);
        public static IWebDriver Instance { get; set; }

        private static ChromeOptions GetChromeOptions()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            return chromeOptions;
        }

        public static void Initialize()
        {
            Instance?.Quit();

            Instance = new ChromeDriver(GetChromeOptions());

            // waits
            Instance.Manage().Timeouts().PageLoad = PageLoad;
            Instance.Manage().Timeouts().ImplicitWait = ImplicitWaitTimeout;

            try
            {
                Instance.Manage().Window.Maximize();
            }

            catch
            {
                // ignore error
            }
        }

        public static void Cleanup()
        {
            Instance?.Close();
            Instance?.Quit();
        }

        public static void Wait(double maxWaitSec, Func<bool> expression, string reason = null)
        {
            if (reason != null) Console.WriteLine($"*** Waiting max {maxWaitSec}s for: " + reason);
            while (maxWaitSec > 0 && !expression())
            {
                Thread.Sleep(TimeSpan.FromMilliseconds(300));
                maxWaitSec -= 0.3;
                Console.WriteLine($" Wait for it: {Math.Round(maxWaitSec, 1)}");
            }
        }

        public static string TakeScreenshot(string testName)
        {
            try
            {
                var fileName = Path.Combine($"{Path.GetTempPath()}", $"{testName}_{DateTime.UtcNow:ddMMM}.jpg");
                var screenShot = ((ITakesScreenshot)Instance).GetScreenshot();
                screenShot.SaveAsFile(fileName, ScreenshotImageFormat.Jpeg);
                return fileName;
            }
            catch (Exception e)
            {
                Log.Error($"Failed to take screenschot: {e}");
                return null;
            }
        }
    }
}
