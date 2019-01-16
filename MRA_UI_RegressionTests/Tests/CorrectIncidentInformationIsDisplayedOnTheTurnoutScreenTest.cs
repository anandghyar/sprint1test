using MobileResponseApplicationUI.Views;
using MRA_UI_RegressionTests;
using MRA_UI_RegressionTests.Util;
using NUnit.Framework;

namespace MobileResponseApplicationUI.Tests
{
    [TestFixture]
    public class CorrectIncidentInformationIsDisplayedOnTheTurnoutScreenTest : BaseScreen
    {
        [OneTimeSetUp]
        public void BeginExecution()
        {
            DataPool.PopulateInCollection("EventDetails.csv");
        }
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

        [OneTimeTearDown]
        public void tearDown()
        {
           
        }

        public void WhenTheCadNumberIsTheReplayedOne()
        {
            var turnoutScreen = new TurnoutScreen(app);
            Assert.That(turnoutScreen.displayedCadNumber.Text, Is.EqualTo("F9000162"));
        }

        public void ThenTheTurnOutScreenDisplaysCorrectTopBannerInfo()
        {
            var topBannerIncidentInfo = new TopBannerInfo(app);
            string environment = DataPool.ReadData(1, "Environment");
            string callSign = DataPool.ReadData(1, "CallSign");
            string cpn = DataPool.ReadData(1, "CPN");
            string address1 = DataPool.ReadData(1, "Address1");
            string address2 = DataPool.ReadData(1, "Address2");
            string address3 = DataPool.ReadData(1, "Address3");
            string address = address1 + ", " + address2 + "," + address3;
            Assert.That(topBannerIncidentInfo.topBannerEnvironment.Text, Is.EqualTo(environment));
            Assert.That(topBannerIncidentInfo.topBannerCallSign.Text, Is.EqualTo(callSign));
            Assert.That(topBannerIncidentInfo.topBannerCPN.Text, Is.EqualTo(cpn));
            Assert.That(topBannerIncidentInfo.topBannerAddress.Text, Is.EqualTo(address));
            Assert.IsTrue(topBannerIncidentInfo.topBannerBatteryPercentage.Displayed);
        }

        public void ThenTurnOutScreenDisplaysCorrectEventDetails()
        {
            var turnoutScreen = new TurnoutScreen(app);
            string turnoutTime = DataPool.ReadData(1, "TurnoutTime");
            string turnoutDate1 = DataPool.ReadData(1, "TurnoutDate1");
            string turnoutDate2 = DataPool.ReadData(1, "TurnoutDate2");
            string turnoutDate = turnoutDate1 + "," + turnoutDate2;
            string eventType = DataPool.ReadData(1, "EventType");
            string eventDescription = DataPool.ReadData(1, "EventDescription");
            Assert.That(turnoutScreen.turnoutTime.Text, Is.EqualTo(turnoutTime));
            Assert.That(turnoutScreen.turnoutDate.Text, Is.EqualTo(turnoutDate));
            Assert.That(turnoutScreen.eventType.Text, Is.EqualTo(eventType));
            Assert.That(turnoutScreen.eventdescription.Text, Is.EqualTo(eventDescription));
        }

        public void ThenTurnOutScreenDisplaysCorrectEventAddressDetails()
        {
            var turnoutScreen = new TurnoutScreen(app);
            string cpn = DataPool.ReadData(1, "CPN");
            string address1 = DataPool.ReadData(1, "Address1");
            string address2 = DataPool.ReadData(1, "Address2");
            string address3 = DataPool.ReadData(1, "Address3");
            string address = address1 + ", " + address2 + "," + address3;
            string dsa = DataPool.ReadData(1, "DSA");
            string callSourceCode = DataPool.ReadData(1, "CallSourceCode");
            string alarmLevel = DataPool.ReadData(1, "AlarmLevel");
            Assert.That(turnoutScreen.turnoutCPN.Text, Is.EqualTo(cpn));
            Assert.That(turnoutScreen.turnoutFullAddress.Text, Is.EqualTo(address));
            Assert.IsTrue(turnoutScreen.turnoutLocationChange.Displayed);
            Assert.That(turnoutScreen.turnoutNearestDSAValue.Text, Is.EqualTo(dsa));
            Assert.That(turnoutScreen.turnoutCallSourceCode.Text, Is.EqualTo(callSourceCode));
            Assert.That(turnoutScreen.alarmLevelButton.Text, Is.EqualTo(alarmLevel));
        }

        public void ThenTurnOutScreenDisplaysCorrectRespondingAppliance()
        {
            var turnoutScreen = new TurnoutScreen(app);
            string RespondingAppliance1 = DataPool.ReadData(1, "RespondingAppliance1");
            string RespondingAppliance2 = DataPool.ReadData(1, "RespondingAppliance2");
            string RespondingAppliance = RespondingAppliance1 + "," + RespondingAppliance2;
            Assert.That(turnoutScreen.turnoutRespondingAppliance.Text, Is.EqualTo(RespondingAppliance));
        }

    }
}
