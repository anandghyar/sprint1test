using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using System.IO;


namespace MRA_UI_RegressionTests
{
    public class BaseScreen
    {
        public const string packageFamilyName = "Mobility.IncidentResponse.UWP_9ewnw99xdqrn4!App";
        public const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723/";
        public WindowsDriver<WindowsElement> app;

        static BaseScreen()
        {
            try
            {
                var path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)));
                Process myProcess;
                myProcess = new Process();
                myProcess = Process.Start(path + "\\TestData\\BaseTestData\\killWinAppDriver.bat");
                myProcess.WaitForExit(2400);
                myProcess = Process.Start(path + "\\TestData\\BaseTestData\\startWinAppDriver.bat");
                myProcess.Close();
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Exception occured " + e);
            }
        }

        public void LaunchApp()
        {
            var appCapabilities = new DesiredCapabilities();
            appCapabilities.SetCapability("app", packageFamilyName);
            app = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appCapabilities);
            Assert.IsNotNull(app, "Unable to activate the app");
        }

        protected void CloseApp()
        {
            app.Quit();
        }
    }
}
