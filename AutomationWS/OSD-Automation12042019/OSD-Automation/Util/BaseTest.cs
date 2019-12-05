using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OSD_Automation.Util;
using System;
using System.Diagnostics;

namespace OSD_Automation
{
    public class BaseTest
    {
        public const string packageFamilyName = "Osd.Mobile.Uwp_9ewnw99xdqrn4!App";
        public const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723/";
        public WindowsDriver<WindowsElement> app;

        static BaseTest()
        {
            try
            {
                //var path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)));
                var path = ExtendedUtilities.GetDirectoryName();
                Process winAppDriver;
                winAppDriver = new Process();
                winAppDriver = Process.Start(path + "\\TestData\\BaseTestData\\killMobileResponseApplication.bat");
                winAppDriver = Process.Start(path + "\\TestData\\BaseTestData\\killWinAppDriver.bat");
                winAppDriver.WaitForExit(2400);
                winAppDriver = Process.Start(path + "\\TestData\\BaseTestData\\startWinAppDriver.bat");
                winAppDriver.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured " + e);
            }
        }
      

        public void LaunchApp()
        {
            DesiredCapabilities appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", packageFamilyName);
            Console.WriteLine("Exception occured ");

            app = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            Assert.IsNotNull(app, "Unable to activate the app");

        }


        public void CloseApp()
        {
            app.Quit();
        }
    }
}
