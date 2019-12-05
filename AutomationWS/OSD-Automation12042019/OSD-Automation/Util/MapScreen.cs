using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OSD_Automation.Util
{
    class MapScreen : BaseTest
    {
        public WindowsElement BuildingSearchText { get; set; }
        public WindowsElement BuildingSearchBtn { get; set; }


        public MapScreen(WindowsDriver<WindowsElement> app)
        {
            BuildingSearchText = app.FindElementByName("Building Search");
            BuildingSearchBtn = app.FindElementByAccessibilityId("QueryButton");

        }

        public void SearchByStreetName(WindowsDriver<WindowsElement> app, string address)
        {
            BuildingSearchText.SendKeys(address);
            this.BuildingSearchText.Click();
            this.BuildingSearchBtn.Click();
            Thread.Sleep(8000);
            app.Keyboard.SendKeys(Keys.Down);
            app.Keyboard.PressKey(Keys.Enter);

        }
    }
    class MapView
    {
        public WindowsElement MapTick { get; set; }
        public MapView(WindowsDriver<WindowsElement> app)
        {
            MapTick = app.FindElementByAccessibilityId("MyMapView");

        }

        public void SelectBuildingFromMap()
        {
            this.MapTick.Click();

        }
    }
        class BuildingSummary
        {
            public WindowsElement Summary { get; set; }
            public BuildingSummary(WindowsDriver<WindowsElement> app)
            {
            //Summary = app.FindElementByAccessibilityId("HlbRightArrow");
            
            Summary = app.FindElementByName("ImgRightArrow");

        }
        public void SelectBuildingFromSummary()

            {
                this.Summary.Click();

            }
        }


    }


    

