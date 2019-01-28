using MobileResponseApplicationUI.Views;
using MRA_UI_RegressionTests;
using MRA_UI_RegressionTests.Util;
using NUnit.Framework;
using System.Threading;

namespace MobileResponseApplicationUI.Tests
{
    [TestFixture]
    public class CorrectIncidentInformationOnTurnoutScreenForRimutakaTest : BaseScreen
    {
        public string replayedCadnumber;
        TurnoutScreen turnoutScreen;
        TopBannerInfo topBannerInfo;

        [OneTimeSetUp]
        public void BeginExecution()
        {
            DataPool.PopulateInCollection("EventDetails.csv");
            replayedCadnumber = ReplayAnIncident(1);

        }
        [SetUp]
        public void TestInitialize()
        {
            LaunchApp();
            turnoutScreen = new TurnoutScreen(app);
            topBannerInfo = new TopBannerInfo(app);
        }

        [Test]
        public void TurnOutScreenDisplaysCorrectTopBannerInfo()
        {
            //Given there is turnout
            turnoutScreen.WhenTheCadNumberIsTheReplayedOne(replayedCadnumber);
            topBannerInfo.ThenTheTurnOutScreenDisplaysCorrectTopBannerInfo(1);
        }

        [Test]
        public void TurnOutScreenDisplaysCorrectEventDetails()
        {
            //Given there is turnout
            turnoutScreen.WhenTheCadNumberIsTheReplayedOne(replayedCadnumber);
            turnoutScreen.ThenTurnOutScreenDisplaysCorrectEventDetails(1);
        }

        [Test]
        public void TurnOutScreenDisplaysCorrectEventAddressDetails()
        {
            //Given there is turnout
            turnoutScreen.WhenTheCadNumberIsTheReplayedOne(replayedCadnumber);
            turnoutScreen.ThenTurnOutScreenDisplaysCorrectEventAddressDetails(1);

        }

        [Test]
        public void TurnOutScreenDisplaysCorrectRespondingAppliances()
        {
            //Given there is turnout
            turnoutScreen.WhenTheCadNumberIsTheReplayedOne(replayedCadnumber);
            turnoutScreen.ThenTurnOutScreenDisplaysCorrectRespondingAppliance(1);
        }

        [TearDown]
        public void CloseTheApp()
        {
            CloseApp();
        }

        [OneTimeTearDown]
        public void tearDown()
        {
            ManageRestCalls.CancelReplayedJob(replayedCadnumber);
        }

    }
}