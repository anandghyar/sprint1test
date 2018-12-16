using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;


namespace MRA_UI_RegressionTests
{
    public class BaseScreen
    {
        public const string packageFamilyName = "Mobility.IncidentResponse.UWP_9ewnw99xdqrn4!App";
        public const string WindowsApplicationDriverUrl = "http://127.0.0.1:4723/";
        public WindowsDriver<WindowsElement> app;
       


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
