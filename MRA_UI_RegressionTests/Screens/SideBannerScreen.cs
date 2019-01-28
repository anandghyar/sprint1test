using OpenQA.Selenium.Appium.Windows;


namespace MRA_UI_RegressionTests.Screens
{
    public class SideBannerScreen
    {
        public WindowsElement turnoutTab { get; set; }
        public WindowsElement routeTab { get; set; }
        public WindowsElement incidentTab { get; set; }
        public WindowsElement logsTab { get; set; }
        public WindowsElement toolboxTab { get; set; }



        public SideBannerScreen(WindowsDriver<WindowsElement> app)
        {
            System.Threading.Thread.Sleep(10000);
            turnoutTab = app.FindElementByName("Turnout");
            routeTab = app.FindElementByName("Route");
            incidentTab = app.FindElementByName("Incident");
            logsTab = app.FindElementByName("Logs");
            toolboxTab = app.FindElementByName("Toolbox");
        }
    }
}
