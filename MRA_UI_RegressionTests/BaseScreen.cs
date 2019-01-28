using MRA_UI_RegressionTests.Util;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace MRA_UI_RegressionTests
{
    public class BaseScreen :ManageRestCalls
    {
        public const string packageFamilyName = "Mobility.IncidentResponse.UWP_9ewnw99xdqrn4!App";
        public const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723/";
        public WindowsDriver<WindowsElement> app;

        static BaseScreen()
        {
            try
            {
                var path = Path.GetDirectoryName(Path.GetDirectoryName(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)));
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
            
            var appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", packageFamilyName);
            app = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            Assert.IsNotNull(app, "Unable to activate the app");
            Thread.Sleep(70000);
        }
        
        public void CloseApp()
        {
            app.Quit();
        }
    }
}
