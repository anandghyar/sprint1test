using OpenQA.Selenium.Appium.Windows;

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


        public TurnoutScreen(WindowsDriver<WindowsElement> app)
        {
            System.Threading.Thread.Sleep(10000);
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
        }
    }



    public class TopBannerInfo
    {
        public WindowsElement topBannerCPN { get; set; }
        public WindowsElement topBannerCallSign { get; set; }
        public WindowsElement topBannerAddress { get; set; }
        public WindowsElement topBannerBatteryPercentage { get; set; }
        public WindowsElement topBannerEnvironment { get; set; }


        public TopBannerInfo(WindowsDriver<WindowsElement> app)
        {
            topBannerCPN = app.FindElementByAccessibilityId("LabelCommonPlace");
            topBannerCallSign = app.FindElementByAccessibilityId("ButtonCallSign");
            topBannerAddress = app.FindElementByAccessibilityId("LabelStreetAddress");
            topBannerBatteryPercentage = app.FindElementByAccessibilityId("LabelBatteryPercentage");
            topBannerEnvironment = app.FindElementByAccessibilityId("LabelEnvironment");
        }

    }
}







