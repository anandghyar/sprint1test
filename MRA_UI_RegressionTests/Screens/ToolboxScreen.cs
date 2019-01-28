using OpenQA.Selenium.Appium.Windows;

namespace MobileResponseApplicationUI.Views
{
    public class ToolboxScreen
    {
        public WindowsElement accuweatherIcon { get; set; }


        public ToolboxScreen(WindowsDriver<WindowsElement> app)
        {
            System.Threading.Thread.Sleep(10000);
            accuweatherIcon = app.FindElementByName("AccuWeather");
        }
    }
}
