using MobileResponseApplicationUI.Views;
using MRA_UI_RegressionTests;
using NUnit.Framework;

namespace MobileResponseApplicationUI.Tests
{
    [TestFixture]
    public class CorrectIncidentInformationIsDisplayedOnTheTurnoutScreenTest : BaseScreen
    {
        [SetUp]
        public void TestInitialize()
        {
            LaunchApp();
        }

        [Test]
        public void TurnOutScreenDisplaysCorrectTopBannerInfo()
        {
            //Given there is turnout
            WhenTheCadNumberIsTheReplayedOne();
            ThenTheTurnOutScreenDisplaysCorrectTopBannerInfo();
        }

        [Test]
        public void TurnOutScreenDisplaysCorrectEventDetails()
        {
            //Given there is turnout
            WhenTheCadNumberIsTheReplayedOne();
            ThenTurnOutScreenDisplaysCorrectEventDetails();
        }

        [Test]
        public void TurnOutScreenDisplaysCorrectEventAddressDetails()
        {
            //Given there is turnout
            WhenTheCadNumberIsTheReplayedOne();
            ThenTurnOutScreenDisplaysCorrectEventAddressDetails();

        }

        [Test]
        public void TurnOutScreenDisplaysCorrectRespondingAppliances()
        {
            //Given there is turnout
            WhenTheCadNumberIsTheReplayedOne();
            ThenTurnOutScreenDisplaysCorrectRespondingAppliance();
        }

        [TearDown]
        public void CloseTheApp()
        {
            CloseApp();
        }


        public void WhenTheCadNumberIsTheReplayedOne()
        {
            var turnoutScreen = new TurnoutScreen(app);
            Assert.That(turnoutScreen.displayedCadNumber.Text, Is.EqualTo("F9000162"));
        }

        public void ThenTheTurnOutScreenDisplaysCorrectTopBannerInfo()
        {
            var topBannerIncidentInfo = new TopBannerInfo(app);
            Assert.That(topBannerIncidentInfo.topBannerEnvironment.Text, Is.EqualTo("Stg"));
            Assert.That(topBannerIncidentInfo.topBannerCallSign.Text, Is.EqualTo("TEST001013"));
            Assert.That(topBannerIncidentInfo.topBannerCPN.Text, Is.EqualTo("RIMUTAKA RAIL TUNNEL MAYMORN PORTAL"));
            Assert.That(topBannerIncidentInfo.topBannerAddress.Text, Is.EqualTo("UNKN0003 PARKES LINE RD, MAYMORN, UPPER HUTT CITY"));
            Assert.IsTrue(topBannerIncidentInfo.topBannerBatteryPercentage.Displayed);
        }

        public void ThenTurnOutScreenDisplaysCorrectEventDetails()
        {
            var turnoutScreen = new TurnoutScreen(app);
            Assert.That(turnoutScreen.turnoutTime.Text, Is.EqualTo("Turnout Time  13:44"));
            Assert.That(turnoutScreen.turnoutDate.Text, Is.EqualTo("Tuesday, 10 April 2018"));
            Assert.That(turnoutScreen.eventType.Text, Is.EqualTo("Structure Fire"));
            Assert.That(turnoutScreen.eventdescription.Text, Is.EqualTo("SMOKE COMING FROM TUNNEL"));
        }

        public void ThenTurnOutScreenDisplaysCorrectEventAddressDetails()
        {
            var turnoutScreen = new TurnoutScreen(app);
            Assert.That(turnoutScreen.turnoutCPN.Text, Is.EqualTo("RIMUTAKA RAILWAY TUNNEL"));
            Assert.That(turnoutScreen.turnoutFullAddress.Text, Is.EqualTo("UNKN0001 MAYMORN RD, MAYMORN, UPPER HUTT CITY"));
            Assert.IsTrue(turnoutScreen.turnoutLocationChange.Displayed);
            Assert.That(turnoutScreen.turnoutNearestDSAValue.Text, Is.EqualTo("1m"));
            Assert.That(turnoutScreen.turnoutCallSourceCode.Text, Is.EqualTo("111"));
            Assert.That(turnoutScreen.alarmLevelButton.Text, Is.EqualTo("1"));
        }

        public void ThenTurnOutScreenDisplaysCorrectRespondingAppliance()
        {
            var turnoutScreen = new TurnoutScreen(app);
            Assert.That(turnoutScreen.turnoutRespondingAppliance.Text, Is.EqualTo("TEST001012, TEST001013"));
        }

    }
}
