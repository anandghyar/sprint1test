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
    }
}
