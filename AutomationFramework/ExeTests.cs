using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace AutomationFramework.Tests
{
    public class ExeTests
    {
        DriverWrapper driver;

        [Test]
        public void ExeTest()
        {

            driver.GoToUrl("https://exe.ua/ua/");
            ElementWrapper btnPcComplect = driver.FindElementByXpath("(//a[@href='/ua/category/c524/'])[3]");
            btnPcComplect.Click();

            List<ElementWrapper> refCategories = driver.FindElementsByClassName("cat_name");
            List<string> actualList = new List<string>();
            List<string> expectedList = new List<string>
            {
                "Відеокарти",
                "Материнські плати",
                "Оперативна пам'ять",
                "Кулери і системи охолодження",
                "Корпуси",
                "Жорсткі диски",
                "Блоки живлення",
                "Процесори",
                "Контролери, адаптери",
                "SSD накопичувачі",
                "Оптичні накопичувачі",
                "Аксесуари для моддінгу",
                "Звукові карти"
            };

            foreach (var i in refCategories)
            {
                actualList.Add(i.GetText());
            }

            CollectionAssert.AreEqual(expectedList, actualList, $"Expectec list is not equal to actual list");

            ElementWrapper btnVideocards = driver.FindElementByXpath("//h4[@class='cat_name'][text()='Відеокарти']");
            btnVideocards.Click();

            List<ElementWrapper> chkMakerList = driver.FindElementsByXpath("//input[@name='proizvoditel-133[]']/following-sibling::a");
            List<string> checkboxesActualResult = new List<string>();
            List<string> checkboxesExpectedResult = new List<string>
            {
                "AMD",
                "Asus",
                "Dell",
                "Gigabyte",
                "HP",
                "MSI",
                "Palit",
                "PNY",
                "Sapphire",
                "Green"
            };

            foreach (var element in chkMakerList)
            {
                string text = element.GetText();
                checkboxesActualResult.Add(text);

            }
            CollectionAssert.Contains(checkboxesExpectedResult, "MSI");

            ElementWrapper header = driver.FindElementByXpath("//h1[normalize-space()='Відеокарти']");
            StringAssert.Contains(header.GetText(), "Відеокарти и смартфоны");

            ElementWrapper txtSearch = driver.FindElementById("search_query");
            txtSearch.SendText("Відеокарта ASUS GeForce RTX3060");
            ElementWrapper btnSearch = driver.FindElementByClass("ssearch-right");
            btnSearch.Click();

            ElementWrapper hdrError = driver.FindElementByTag("h1");
            string errorText = hdrError.GetText();
            Console.WriteLine(errorText);
        }


        [SetUp]
        public void PreCondition()
        {
            driver = new DriverFactory().GetDriver("Chrome");
            driver.Maximize();
        }

        [TearDown]
        public void PostCondition()
        {
            driver.Close();
        }
    }
}
