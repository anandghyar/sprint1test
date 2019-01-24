﻿using MobileResponseApplicationUI.Views;
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
        [OneTimeSetUp]
        public void BeginExecution()
        {
            DataPool.PopulateInCollection("EventDetails.csv");
            replayedCadnumber = ManageRestCalls.ReplayAnIncident(2);
        }
        [SetUp]
        public void TestInitialize()
        {
            LaunchApp();
            Thread.Sleep(70000);
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
            ManageRestCalls.CancelReplayedJob(replayedCadnumber);
        }

        public void WhenTheCadNumberIsTheReplayedOne()
        {
            var turnoutScreen = new TurnoutScreen(app);
            Assert.That(turnoutScreen.displayedCadNumber.Text, Is.EqualTo(replayedCadnumber));
        }

        public void ThenTheTurnOutScreenDisplaysCorrectTopBannerInfo()
        {
            var topBannerIncidentInfo = new TopBannerInfo(app);
            string environment = DataPool.ReadData(2, "Environment");
            //string callSign = DataPool.ReadData(2, "CallSign");
            string cpn = DataPool.ReadData(2, "CPN");
            string address = DataPool.ReadData(2, "Address").Replace(":", ",");
            Assert.That(topBannerIncidentInfo.topBannerEnvironment.Text, Is.EqualTo(environment));
            //Assert.That(topBannerIncidentInfo.topBannerCallSign.Text, Is.EqualTo(callSign));
            Assert.That(topBannerIncidentInfo.topBannerCPN.Text, Is.EqualTo(cpn));
            Assert.That(topBannerIncidentInfo.topBannerAddress.Text, Is.EqualTo(address));
            Assert.IsTrue(topBannerIncidentInfo.topBannerBatteryPercentage.Displayed);
        }

        public void ThenTurnOutScreenDisplaysCorrectEventDetails()
        {
            var turnoutScreen = new TurnoutScreen(app);
            string turnoutTime = DataPool.ReadData(2, "TurnoutTime");
            string turnoutDate = DataPool.ReadData(2, "TurnoutDate").Replace(":", ",");
            string eventType = DataPool.ReadData(2, "EventType");
            string eventDescription = DataPool.ReadData(2, "EventDescription");
            string dangerousBuildingLabel = DataPool.ReadData(2, "DangerousBuildingLabel");
            Assert.That(turnoutScreen.turnoutTime.Text, Is.EqualTo(turnoutTime));
            Assert.That(turnoutScreen.turnoutDate.Text, Is.EqualTo(turnoutDate));
            Assert.That(turnoutScreen.eventType.Text, Is.EqualTo(eventType));
            Assert.That(turnoutScreen.eventdescription.Text, Is.EqualTo(eventDescription));
            Assert.That(turnoutScreen.dangerousBuildingLabel.Text, Is.EqualTo(dangerousBuildingLabel));

        }

        public void ThenTurnOutScreenDisplaysCorrectEventAddressDetails()
        {
            var turnoutScreen = new TurnoutScreen(app);
            string cpn = DataPool.ReadData(2, "CPN");
            string address = DataPool.ReadData(2, "Address").Replace(":", ",");
            string dsa = DataPool.ReadData(2, "DSA");
            string callSourceCode = DataPool.ReadData(2, "CallSourceCode");
            string alarmLevel = DataPool.ReadData(2, "AlarmLevel");
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
            string RespondingAppliance = DataPool.ReadData(2, "RespondingAppliance");
            string[] respondingAppl = turnoutScreen.turnoutRespondingAppliance.Text.Split(',');
            string numOfAppliances = respondingAppl.Length.ToString();
            Assert.That(numOfAppliances, Is.EqualTo(RespondingAppliance));
        }

    }
}

