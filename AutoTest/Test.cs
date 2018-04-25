using System;
using System.Collections.Generic;
using System.Linq;
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
    [TestFixture]
    public class Test
    {
        First data = new First();

        [SetUp] // вызывается перед каждым тестом
        public void SetUp()
        {
            data.OpenHotlineUA();
        }

        [TearDown] // вызывается после каждого теста
        public void TearDown()
        {
            data.Sleep(10);
            data.Quit();
        }

        [Test]
        public void TEST_1()
        {
            data.FilterBrushes();
        }

        [Test]
        public void TEST_2()
        {
            data.FilterSnowboards();
        }

        //[OneTimeSetUp] // вызывается перед началом запуска всех тестов
        //public void OneTimeSetUp()
        //{ }

        //[OneTimeTearDown] //вызывается после завершения всех тестов
        //public void OneTimeTearDown()
        //{ }
    }
}
