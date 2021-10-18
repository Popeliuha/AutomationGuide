using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationFramework.Tests
{
    public class ElementWrapper
    {
        IWebElement element;

        public ElementWrapper(IWebElement element)
        {
            this.element = element;
        }

        public void Click()
        {
            element.Click();
        }

        public void SendText(string text)
        {
            element.SendKeys(text);
        }

        public string GetText()
        {
            return element.Text;
        }
    }
}
