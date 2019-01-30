using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MobileResponseApplicationUI.Views
{
    class TurnoutScreen
    {
        public WindowsElement alarmLevelButton { get; set; }
        public WindowsElement displayedCadNumber { get; set; }
        public WindowsElement topBannerCPN { get; set; }
        public WindowsElement turnoutTime { get; set; }
        public WindowsElement turnoutDate { get; set; }
        public WindowsElement eventType { get; set; }
        public WindowsElement eventdescription { get; set; }
        public WindowsElement turnoutCPN { get; set; }
        public WindowsElement turnoutFullAddress { get; set; }
        public WindowsElement turnoutLocationChange { get; set; }
        public WindowsElement turnoutNearestDSAValue { get; set; }
        public WindowsElement turnoutCallSourceCode { get; set; }
        public WindowsElement turnoutRespondingAppliance { get; set; }
        public WindowsElement dangerousBuildingLabel { get; set; }


        public TurnoutScreen(WindowsDriver<WindowsElement> app)
        {
            Thread.Sleep(10000);
            alarmLevelButton = app.FindElementByAccessibilityId("LabelAlarmLevel");
            displayedCadNumber = app.FindElementByAccessibilityId("LabelCadNumber");
            turnoutTime = app.FindElementByAccessibilityId("LabelTurnoutTime");
            turnoutDate = app.FindElementByAccessibilityId("LabelTurnourDate");
            eventType = app.FindElementByAccessibilityId("LabelEventTypeDetails");
            eventdescription = app.FindElementByAccessibilityId("LabelIncidentNoteText");
            turnoutCPN = app.FindElementByAccessibilityId("LabelCommonPlace");
            turnoutFullAddress = app.FindElementByAccessibilityId("LabelFullAddress");
            turnoutLocationChange = app.FindElementByAccessibilityId("LabelLocationChangedText");
            turnoutNearestDSAValue = app.FindElementByAccessibilityId("LabelDispatchSafetyAlert");
            turnoutCallSourceCode = app.FindElementByAccessibilityId("LabelCallSourceCode");
            turnoutRespondingAppliance = app.FindElementByAccessibilityId("LabelRespondingApplianceNames");
            try
            {
                dangerousBuildingLabel = app.FindElementByAccessibilityId("LabelICadDirections");

            }
            catch (Exception)
            {
                Console.WriteLine("Not a Dangerous Building");
            }
        }


        public void WhenTheCadNumberIsTheReplayedOne(string replayedCadnumber)
        {
            try
            {
                Assert.That(displayedCadNumber.Text, Is.EqualTo(replayedCadnumber));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured " + e);
            }
        }

        public void ThenTurnOutScreenDisplaysCorrectEventDetails(Dictionary<string, string> dict)
        {
            try
            {
                string turnoutTime = dict["TurnoutTime"];
                string turnoutDate = dict["TurnoutDate"].Replace(":", ",");
                string eventType = dict["EventType"];
                string eventDescription = dict["EventDescription"];
                string dangerousBuildingLabel = dict["DangerousBuildingLabel"];
                Assert.That(this.turnoutTime.Text, Is.EqualTo(turnoutTime));
                Assert.That(this.turnoutDate.Text, Is.EqualTo(turnoutDate));
                Assert.That(this.eventType.Text, Is.EqualTo(eventType));
                Assert.That(this.eventdescription.Text, Is.EqualTo(eventDescription));
                Assert.That(this.dangerousBuildingLabel.Text, Is.EqualTo(dangerousBuildingLabel));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured " + e);
            }
        }

        public void ThenTurnOutScreenDisplaysCorrectEventAddressDetails(Dictionary<string, string> dict)
        {
            try
            {

                string cpn = dict["CPN"];
                string address = dict["Address"].Replace(":", ",");
                string dsa = dict["DSA"];
                string callSourceCode = dict["CallSourceCode"];
                string alarmLevel = dict["AlarmLevel"];
                Assert.That(this.turnoutCPN.Text, Is.EqualTo(cpn));
                Assert.That(this.turnoutFullAddress.Text, Is.EqualTo(address));
                Assert.IsTrue(this.turnoutLocationChange.Displayed);
                Assert.That(this.turnoutNearestDSAValue.Text, Is.EqualTo(dsa));
                Assert.That(this.turnoutCallSourceCode.Text, Is.EqualTo(callSourceCode));
                Assert.That(this.alarmLevelButton.Text, Is.EqualTo(alarmLevel));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured " + e);
            }
        }

        public void ThenTurnOutScreenDisplaysCorrectRespondingAppliance(Dictionary<string, string> dict)
        {
            try
            {
                string respondingAppliance = dict["RespondingAppliance"];
                string[] respondingAppl = turnoutRespondingAppliance.Text.Split(',');
                string numOfAppliances = respondingAppl.Length.ToString();
                Assert.That(numOfAppliances, Is.EqualTo(respondingAppliance));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured " + e);
            }
        }
    }

}

public class TopBannerInfo
{
    public WindowsElement topBannerCPN { get; set; }
    public WindowsElement topBannerAddress { get; set; }
    public WindowsElement topBannerBatteryPercentage { get; set; }
    public WindowsElement topBannerEnvironment { get; set; }


    public TopBannerInfo(WindowsDriver<WindowsElement> app)
    {
        topBannerCPN = app.FindElementByAccessibilityId("LabelCommonPlace");
        topBannerAddress = app.FindElementByAccessibilityId("LabelStreetAddress");
        topBannerBatteryPercentage = app.FindElementByAccessibilityId("LabelBatteryPercentage");
        topBannerEnvironment = app.FindElementByAccessibilityId("LabelEnvironment");
    }

    public void ThenTheTurnOutScreenDisplaysCorrectTopBannerInfo(Dictionary<string, string> dict)
    {
        try
        {
            string environment = dict["Environment"];
            string cpn = dict["CPN"];
            string address = dict["Address"].Replace(":", ",");
            Assert.That(topBannerEnvironment.Text, Is.EqualTo(environment));
            Assert.That(topBannerCPN.Text, Is.EqualTo(cpn));
            Assert.That(topBannerAddress.Text, Is.EqualTo(address));
            Assert.IsTrue(topBannerBatteryPercentage.Displayed);
        }
        catch (Exception e)
        {
            Console.WriteLine("Exception occured " + e);
        }
    }

}
