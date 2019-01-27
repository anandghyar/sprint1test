using OpenQA.Selenium.Appium.Windows;
using System.Threading;

namespace MobileResponseApplicationUI.Views
{
    public class LogsScreen
    {
        public WindowsElement messages { get; set; }


        public LogsScreen(WindowsDriver<WindowsElement> app)
        {
            Thread.Sleep(10000);
            messages = app.FindElementByName("Messages");
        }
    }
}

