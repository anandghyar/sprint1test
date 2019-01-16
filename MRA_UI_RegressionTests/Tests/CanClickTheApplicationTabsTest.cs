using MobileResponseApplicationUI.Views;
using MRA_UI_RegressionTests.Screens;
using NUnit.Framework;

namespace MRA_UI_RegressionTests.Tests
{
    [TestFixture]
    public class CanClickTheApplicationTabsTest : BaseScreen
    {
        [SetUp]
        public void TestInitialize()
        {
            LaunchApp();
        }

        [Test]
        public void RouteTabShouldBeClickable()
        {
            //Given the user is on the TurnoutScreen
            WhenRouteTabIsClicked();
            ThenRouteScreenIsDisplayed();
        }


        [Test]
        public void TurnoutTabShouldBeClickable()
        {
            IncidentTabShouldBeClickable();

            WhenTurnoutTabIsClicked();
            ThenTurnoutScreenIsDisplayed();

        }


        [Test]
        public void IncidentTabShouldBeClickable()
        {
            //Given the user is on the LogsScreen
            WhenIncidentTabIsClicked();
            ThenBuildingDetailsAreDisplayed();
        }

        [Test]
        public void LogsTabShouldBeClickable()
        {
            //Given the user is on the RouteScreen
            WhenLogsTabIsClicked();
            ThenMessagesScreenIsDisplayed();
        }

        [Test]
        public void ToolboxTabShouldBeClickable()
        {
            //Given the user is on the IncidentScreen
            WhenToolboxTabIsClicked();
            ThenToolboxDetailsAreDisplayed();
        }

        [TearDown]
        public void CloseTheApp()
        {
            CloseApp();
        }

        public void WhenLogsTabIsClicked()
        {
            var sideBannerScreen = new SideBannerScreen(app);
            app.Mouse.Click(sideBannerScreen.logsTab.Coordinates);
        }

        public void ThenMessagesScreenIsDisplayed()
        {
            var messageScreen = new LogsScreen(app).messages;
            Assert.IsTrue(messageScreen.Displayed);
        }

        public void WhenRouteTabIsClicked()
        {
            var sideBannerScreen = new SideBannerScreen(app);
            app.Mouse.Click(sideBannerScreen.routeTab.Coordinates);
        }

        public void ThenRouteScreenIsDisplayed()
        {
            var routeMapScreen = new RouteMapSettings(app);
            Assert.IsTrue(routeMapScreen.appliancesCheckbox.Displayed);
        }


        public void WhenIncidentTabIsClicked()
        {
            var sideBannerScreen = new SideBannerScreen(app);
            app.Mouse.Click(sideBannerScreen.incidentTab.Coordinates);
        }

        public void ThenBuildingDetailsAreDisplayed()
        {
            var incidentBanner = new IncidentScreen(app);
            Assert.IsTrue(incidentBanner.site.Displayed);
            Assert.IsTrue(incidentBanner.diagrams.Displayed);
            Assert.IsTrue(incidentBanner.contacts.Displayed);
            Assert.IsTrue(incidentBanner.tactical.Displayed);
        }

        public void WhenToolboxTabIsClicked()
        {
            var sideBannerScreen = new SideBannerScreen(app);
            app.Mouse.Click(sideBannerScreen.toolboxTab.Coordinates);
        }

        public void ThenToolboxDetailsAreDisplayed()
        {
            var toolboxFirstEntry = new ToolboxScreen(app).accuweatherIcon;
            Assert.IsTrue(toolboxFirstEntry.Displayed);
        }

        public void WhenTurnoutTabIsClicked()
        {
            var sideBannerScreen = new SideBannerScreen(app);
            app.Mouse.Click(sideBannerScreen.turnoutTab.Coordinates);
        }

        public void ThenTurnoutScreenIsDisplayed()
        {
            var turnoutScreen = new TurnoutScreen(app);
            Assert.IsTrue(turnoutScreen.alarmLevelButton.Displayed);
        }

    }
}