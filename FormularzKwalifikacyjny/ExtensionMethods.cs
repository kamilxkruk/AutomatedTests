using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace FormularzKwalifikacyjny
{
    public static class ExtensionMethods
    {
        public static void AddWebElementToDictionary(this Dictionary<string, IWebElement> dictionary, IWebDriver driver, string xpath)
        {
            dictionary.Add(xpath,driver.FindElement(By.XPath(xpath)));
        }
    }
}
