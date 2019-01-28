using OpenQA.Selenium.Appium.Windows;

namespace MRA_UI_RegressionTests.Screens
{
    public class RouteScreen
    {
        public WindowsElement mapSettings { get; set; }



        public RouteScreen(WindowsDriver<WindowsElement> app)
        {
            mapSettings = app.FindElementByName("ScrollViewer");
        }
    }
}


public class RouteMapSettings
{
    public WindowsElement appliancesCheckbox { get; set; }

    public RouteMapSettings(WindowsDriver<WindowsElement> app)
    {
        appliancesCheckbox = app.FindElementByClassName("Appliances");
    }
}


   
