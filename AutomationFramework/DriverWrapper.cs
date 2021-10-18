using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomationFramework.Tests
{
    public class DriverWrapper
    {
        public IWebDriver Driver { get; set; }

        public DriverWrapper(IWebDriver Driver)
        {
            this.Driver = Driver;
        }

        public void Refresh()
        {
            Driver.Navigate().Refresh();
        }

        public void GoToUrl(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        public void Maximize()
        {
            Driver.Manage().Window.Maximize();
        }

        public void Close()
        {
            Driver.Close();
        }

        public ElementWrapper FindElementByXpath(string XPath)
        {
            var result = new ElementWrapper(Driver.FindElement(By.XPath(XPath)));
            return result;
        }

        public ElementWrapper FindElementById(string id)
        {
            var result = new ElementWrapper(Driver.FindElement(By.Id(id)));
            return result;
        }

        public ElementWrapper FindElementByClass(string className)
        {
            var result = new ElementWrapper(Driver.FindElement(By.ClassName(className)));
            return result;
        }

        public ElementWrapper FindElementByTag(string tagName)
        {
            var result = new ElementWrapper(Driver.FindElement(By.TagName(tagName)));
            return result;
        }

        public List<ElementWrapper> FindElementsByXpath(string XPath)
        {
            var elements = Driver.FindElements(By.XPath(XPath));
            var result = elements.Select(x => new ElementWrapper(x));
            return result.ToList();
        }

        public List<ElementWrapper> FindElementsByClassName(string className)
        {
            var elements = Driver.FindElements(By.ClassName(className));
            var result = elements.Select(x => new ElementWrapper(x));
            return result.ToList();
        }
    }
}
