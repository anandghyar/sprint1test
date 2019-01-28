using MobileResponseApplicationUI.Views;
using MRA_UI_RegressionTests.Util;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MRA_UI_RegressionTests.Tests
{
    class CorrectIncidentInfoOnTurnoutScreenForMSDAnimalHealthTest : BaseScreen
    {
        public string replayedCadnumber;
        TurnoutScreen turnoutScreen;
        TopBannerInfo topBannerInfo;

        [OneTimeSetUp]
        public void BeginExecution()
        {
            DataPool.PopulateInCollection("EventDetails.csv");
            replayedCadnumber = ReplayAnIncident(2);
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
            topBannerInfo.ThenTheTurnOutScreenDisplaysCorrectTopBannerInfo(2);
        }

        [Test]
        public void TurnOutScreenDisplaysCorrectEventDetails()
        {
            //Given there is turnout
            turnoutScreen.WhenTheCadNumberIsTheReplayedOne(replayedCadnumber);
            turnoutScreen.ThenTurnOutScreenDisplaysCorrectEventDetails(2);
        }

        [Test]
        public void TurnOutScreenDisplaysCorrectEventAddressDetails()
        {
            //Given there is turnout
            turnoutScreen.WhenTheCadNumberIsTheReplayedOne(replayedCadnumber);
            turnoutScreen.ThenTurnOutScreenDisplaysCorrectEventAddressDetails(2);
        }

        [Test]
        public void TurnOutScreenDisplaysCorrectRespondingAppliances()
        {
            //Given there is turnout
            turnoutScreen.WhenTheCadNumberIsTheReplayedOne(replayedCadnumber);
            turnoutScreen.ThenTurnOutScreenDisplaysCorrectRespondingAppliance(2);
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

