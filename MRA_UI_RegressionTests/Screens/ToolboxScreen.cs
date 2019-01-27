using OpenQA.Selenium.Appium.Windows;
using System.Threading;

namespace MobileResponseApplicationUI.Views
{
    public class ToolboxScreen
    {
        public WindowsElement accuweatherIcon { get; set; }


        public ToolboxScreen(WindowsDriver<WindowsElement> app)
        {
            Thread.Sleep(10000);
            accuweatherIcon = app.FindElementByName("AccuWeather");
        }
    }
}
