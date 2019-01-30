using MobileResponseApplicationUI.Views;
using MRA_UI_RegressionTests.Util;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;

namespace MRA_UI_RegressionTests.Tests
{
    class CorrectIncidentInfoOnTurnoutScreenForMSDAnimalHealthTest : BaseScreen
    {
        public string replayedCadnumber;
        TurnoutScreen turnoutScreen;
        TopBannerInfo topBannerInfo;
        Dictionary<string, string> dict;
        [OneTimeSetUp]
        public void BeginExecution()
        {
            dict=DataPool.PopulateInCollection("EventDetails.csv",2);
            replayedCadnumber = ReplayAnIncident(2);
        }


        [SetUp]
        public void TestInitialize()
        {
            LaunchApp();
            Thread.Sleep(70000);
            turnoutScreen = new TurnoutScreen(app);
            topBannerInfo = new TopBannerInfo(app);
        }


        [Test]
        public void TurnOutScreenDisplaysCorrectTopBannerInfo()
        {
            //Given there is turnout
            turnoutScreen.WhenTheCadNumberIsTheReplayedOne(replayedCadnumber);
            topBannerInfo.ThenTheTurnOutScreenDisplaysCorrectTopBannerInfo(dict);
        }

        [Test]
        public void TurnOutScreenDisplaysCorrectEventDetails()
        {
            //Given there is turnout
            turnoutScreen.WhenTheCadNumberIsTheReplayedOne(replayedCadnumber);
            turnoutScreen.ThenTurnOutScreenDisplaysCorrectEventDetails(dict);
        }

        [Test]
        public void TurnOutScreenDisplaysCorrectEventAddressDetails()
        {
            //Given there is turnout
            turnoutScreen.WhenTheCadNumberIsTheReplayedOne(replayedCadnumber);
            turnoutScreen.ThenTurnOutScreenDisplaysCorrectEventAddressDetails(dict);
        }

        [Test]
        public void TurnOutScreenDisplaysCorrectRespondingAppliances()
        {
            //Given there is turnout
            turnoutScreen.WhenTheCadNumberIsTheReplayedOne(replayedCadnumber);
            turnoutScreen.ThenTurnOutScreenDisplaysCorrectRespondingAppliance(dict);
        }

        [TearDown]
        public void CloseTheApp()
        {
            CloseApp();
        }

        [OneTimeTearDown]
        public void tearDown()
        {
            CancelReplayedJob(replayedCadnumber);
        }
    }
}

