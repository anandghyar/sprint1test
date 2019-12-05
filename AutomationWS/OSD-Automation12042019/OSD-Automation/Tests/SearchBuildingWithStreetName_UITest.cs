using NUnit.Framework;
using OSD_Automation.Util;
using System.Threading;

namespace OSD_Automation.Tests
{
    class SearchBuildingWithStreetName_UITest :BaseTest
    {
        WatchScreen watchscreen;
        MapScreen mapscreen;
        BuildingSummary buildingSummary;
        MapView mapview;
        SqliteService service;
        WatchColor watchColor;

        [OneTimeSetUp]
        public void TestInitialize()
        {
            service = new SqliteService();
            LaunchApp();
            Thread.Sleep(5000);
            watchscreen = new WatchScreen(app);
        }

        [Test, Order(1)]
        public void verifyApplicationVersionNumber()
        {
            watchscreen.ApplicationVersionsAreDisplayed();
        }
        [Test, Order(2)]
        public void VerifywatchColors()
        {
            watchscreen.SelectWatchColor(app);
            watchColor = new WatchColor(app);
            watchColor.Verifywatchcolor(app);
            watchscreen.SelectWatchColor(app);

        }
        [Test, Order(3)]
        public void SearchStreetAddress()
        {
            string address = service.Sqlites(1);
            watchscreen.SignIn(app);
            Thread.Sleep(5000);
            mapscreen = new MapScreen(app);
            mapscreen.SearchByStreetName(app, address);
            Thread.Sleep(5000);
            mapview = new MapView(app);
            mapview.SelectBuildingFromMap();
            buildingSummary = new BuildingSummary(app);
            buildingSummary.SelectBuildingFromSummary();
        }

        [OneTimeTearDown]
        public void CloseTheApp()
        {
            CloseApp();
        }

    }
}
