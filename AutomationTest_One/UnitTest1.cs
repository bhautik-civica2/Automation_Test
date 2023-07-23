using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutomationTest_One
{
    public class Tests
    {
        public IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();

            // Navigate to 'Test Site' URL
            var url_1 = "https://angular.aspnetawesome.com/";
            driver.Navigate().GoToUrl(url_1);

            driver.Manage().Window.Maximize();

            // open 'Popup' page
            driver.FindElement(By.LinkText("Popup")).Click();
            Thread.Sleep(1000);
        }

        [Test]
        public void OpenPopUp_1()
        {

            // open 'popup with buttons'
            driver.FindElement(By.XPath("//button[text()='open popup with btns']")).Click();
            Thread.Sleep(1000);

            driver.FindElement(By.XPath("//button[text()='Add Hi']")).Click();


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            // click on 'add hi' popup button
            for (int i = 0; i < 3; i++)
            {
                driver.FindElement(By.XPath("//button[text()='Add Hi']")).Click();
                Thread.Sleep(1000);
            }


            // click on 'close' popup button
            driver.FindElement(By.XPath("//button[text()='Close']")).Click();
        }

        [Test]
        public void OpenPopUp_2()
        {
            // open 'popup with buttons'
            driver.FindElement(By.XPath("//button[text()='open popup with btns']")).Click();
            Thread.Sleep(1000);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement addHiBtn = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[text()='Add Hi']")));

            // click on 'add hi' popup button
            for (int i = 0; i < 3; i++)
            {
                addHiBtn.Click();
                Thread.Sleep(1000);
            }

            // click on 'close' popup button
            driver.FindElement(By.XPath("//button[text()='Close']")).Click();
        }
    }
}