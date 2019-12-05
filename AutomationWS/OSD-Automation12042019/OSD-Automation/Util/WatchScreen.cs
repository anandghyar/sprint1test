using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;


namespace OSD_Automation.Util
{
    class WatchScreen:BaseTest
    {

        public WindowsElement selectWatchColor { get; set; }
        public WindowsElement watchColor { get; set; }
        public WindowsElement signInButton { get; set; }
        public WindowsElement applicationVersion { get; set; }
        public WindowsElement applicationVersionLabel { get; set; }

        public WatchScreen(WindowsDriver<WindowsElement> app)
        {
            selectWatchColor = app.FindElementByAccessibilityId("WatchCodesComboBox");
            signInButton = app.FindElementByAccessibilityId("CustomButtonText");
            applicationVersion = app.FindElementByAccessibilityId("TbkAppVer");
            applicationVersionLabel = app.FindElementByAccessibilityId("TbkAppVer");

        }


        public void ApplicationVersionsAreDisplayed()
        {
           Assert.IsTrue(this.applicationVersionLabel.Displayed);
           Assert.IsTrue(this.applicationVersion.Displayed);
           
        }

        public void WatchColorsAreDisplayed()
        {
            Assert.IsTrue(this.selectWatchColor.Displayed);          

        }
        public void SelectWatchColor(WindowsDriver<WindowsElement> app)
        {
            app.Mouse.Click(this.selectWatchColor.Coordinates);          
        }

        public void SignIn(WindowsDriver<WindowsElement> app)
        {
            //this.signInButton.Click();
            app.Mouse.Click(this.signInButton.Coordinates);
            
        }
    }


    class WatchColor : BaseTest
    {

        public WindowsElement BlueWatch { get; set; }
        public WindowsElement GreenWatch { get; set; }
        public WindowsElement RedWatch { get; set; }
        public WindowsElement BrownWatch { get; set; }
        public WindowsElement YellowWatch { get; set; }
        public WindowsElement BlackWatch { get; set; }
        public WindowsElement selectWatchColor { get; set; }

        public WatchColor(WindowsDriver<WindowsElement> app)
        {

          
            BlueWatch = app.FindElementByName("Blue Watch");
            GreenWatch = app.FindElementByName("Green Watch");
            RedWatch = app.FindElementByName("Red Watch");
            BrownWatch = app.FindElementByName("Brown Watch");
            YellowWatch = app.FindElementByName("Yellow Watch");
            BlackWatch = app.FindElementByName("Black Watch");
        }

        public void Verifywatchcolor(WindowsDriver<WindowsElement> app)
        {

          
            Assert.That(this.BlueWatch.Text, Is.EqualTo("Blue Watch"));
            Assert.That(this.GreenWatch.Text, Is.EqualTo("Green Watch"));

            Assert.That(this.RedWatch.Text, Is.EqualTo("Red Watch"));

            Assert.That(this.BrownWatch.Text, Is.EqualTo("Brown Watch"));

            Assert.That(this.YellowWatch.Text, Is.EqualTo("Yellow Watch"));

            Assert.That(this.BlackWatch.Text, Is.EqualTo("Black Watch"));

        }
    }
}
