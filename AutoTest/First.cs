using System;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace AutoTest
{
    class First
    {
        public static string igWorkDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); // рабочий каталог, относительно исполняемого файла (в нашем случае относительно DLL)
        public static IWebDriver driver;
        public string Language = "./html/body/header/div[1]/div/div/div[1]/div/div[2]/div/div[3]/div/div/span[2]";
        public string AllCatalogs = "./html/body/div[1]/div[1]/div[2]/aside/nav/ul/li[26]/a";
        public string DecorativeCosmetics = "./html/body/div[1]/div[1]/div/div/div/div[3]/div[8]/ul/li[2]/span";
        public string Brushes = "./html/body/div[1]/div[1]/div/div/div/div[3]/div[8]/ul/li[2]/ul/li[8]/a";
        public string MaxPrice = "./html/body/div[1]/div[1]/div[1]/aside/div/div[3]/div[1]/div[4]/div[2]/div/div[1]/input[3]";
        public string BaseBrush = "кисть для основи (127)";
        public string SkisSledges = "//div[4]/div[4]/ul/li[8]/span";
        public string buttonOk = "//input[@value='OK']";
        public string TestBaseBrush = "//body[@id='page-catalog']/div/div/div/aside/div/div[3]/div/div[2]/div[2]/ul/li[3]/label/i";

        public void OpenHotlineUA()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("--ignore-ssl-errors");
            driver = new ChromeDriver(igWorkDir, options);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://hotline.ua/");
            driver.FindElement(By.XPath(Language)).Click();
            driver.FindElement(By.XPath(AllCatalogs)).Click();
            Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains("Всі каталоги"));
            Console.Write("language is ukraine; all catallogs are selected");
        }

        public void FilterBrushes() //TEST_1
        {
            driver.FindElement(By.XPath(DecorativeCosmetics)).Click();
            driver.FindElement(By.XPath(Brushes)).Click();
            IWebElement textfield = driver.FindElement(By.XPath(MaxPrice));
            textfield.SendKeys(Keys.Delete);
            textfield.SendKeys(Keys.Delete);
            textfield.SendKeys(Keys.Delete);
            textfield.SendKeys(Keys.Delete);
            textfield.Clear();
            textfield.SendKeys("1250");
            driver.FindElement(By.XPath(buttonOk)).Click();
            driver.FindElement(By.LinkText(BaseBrush)).Click();
            this.Sleep(5);
            Assert.IsTrue(driver.FindElement(By.XPath(TestBaseBrush)).Selected);
            Console.Write("checkbox present is selected");

        }

        public void FilterSnowboards() //TEST_2
        {
            driver.FindElement(By.XPath(SkisSledges)).Click();
            driver.FindElement(By.LinkText("Сноуборди")).Click();
            var sort = driver.FindElement(By.Name("sort"));
            var selectElement = new SelectElement(sort);
            selectElement.SelectByText("зростанням ціни");
            Assert.IsTrue(driver.FindElement(By.TagName("body")).Text.Contains("зростанням ціни"));
            Console.Write("filter added");
        }

        public void Sleep(int t)
        {
            System.Threading.Thread.Sleep(t * 1000);
        }

        public void Quit()
        {
            driver.Quit();
        }
    }
}
