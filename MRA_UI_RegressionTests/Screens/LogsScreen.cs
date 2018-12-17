using OpenQA.Selenium.Appium.Windows;

namespace MobileResponseApplicationUI.Views
{
    public class LogsScreen
    {
        public WindowsElement messages { get; set; }


        public LogsScreen(WindowsDriver<WindowsElement> app)
        {
            System.Threading.Thread.Sleep(10000);
            messages = app.FindElementByName("Messages");
        }
    }
}

