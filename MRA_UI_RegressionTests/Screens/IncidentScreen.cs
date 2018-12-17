using OpenQA.Selenium.Appium.Windows;

namespace MobileResponseApplicationUI.Views
{
    public class IncidentScreen
    {
        public WindowsElement site { get; set; }
        public WindowsElement diagrams { get; set; }
        public WindowsElement contacts { get; set; }
        public WindowsElement tactical { get; set; }


        public IncidentScreen(WindowsDriver<WindowsElement> app)
        {
            System.Threading.Thread.Sleep(10000);
            site = app.FindElementByName("Site");
            diagrams = app.FindElementByName("Diagrams");
            contacts = app.FindElementByName("Contacts");
            tactical = app.FindElementByName("Tactical");

        }
    }

    public class IncidentMapSettings
    {
        public WindowsElement hydrantCheckbox { get; set; }

        public IncidentMapSettings(WindowsDriver<WindowsElement> app)
        {
            hydrantCheckbox = app.FindElementByClassName("Hydrant Locations");
        }
    }

}
