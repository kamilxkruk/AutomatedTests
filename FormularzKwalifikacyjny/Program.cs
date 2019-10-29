using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static FormularzKwalifikacyjny.ExtensionMethods;

namespace FormularzKwalifikacyjny
{
    class Program
    {
        public static Dictionary<string, IWebElement> pageElements = new Dictionary<string, IWebElement>();

        static void Main(string[] args)
        {
            IWebDriver driver = ConfigureAndRunDriver();
            if (driver == null)
            {
                Console.WriteLine("Can't run Chrome WebDriver, press any key to continue...");
                Console.ReadKey();
                Environment.Exit(0);
            }
            Console.Clear();

            int positiveFunctionalTests = 0, negativeFunctionalTests = 0,
                positiveValidationTests = 0, negativeValidationTests = 0;


            //Run functional tests
            foreach (var test in Tests.functionalTests)
            {
                GetFreshWebElements(driver);
                bool result = test.Invoke(driver);
                if (result)
                {
                    positiveFunctionalTests++;
                }
                else
                {
                    negativeFunctionalTests++;
                }
            }

            //Run validation tests
            foreach (var test in Tests.validationTests)
            {
                GetFreshWebElements(driver);
                bool result = test.Invoke(driver);
                if (result)
                {
                    positiveValidationTests++;
                }
                else
                {
                    negativeValidationTests++;
                }
            }

            Console.WriteLine($@"Sum of tests ran: {positiveValidationTests+positiveFunctionalTests+negativeValidationTests+negativeFunctionalTests}
Validation tests passed: {positiveValidationTests},
Validation tests failed: {negativeValidationTests},
Functional tests passed: {positiveFunctionalTests},
Functional tests failed: {negativeFunctionalTests}");
            Console.ReadKey();
            driver.Quit();
        }

        private static IWebDriver ConfigureAndRunDriver()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            try
            {
                ChromeDriver driver = new ChromeDriver(options);
                return driver;

            }
            catch
            {
               Console.WriteLine("There was an error while configuring Chrome browser.");
               return null;
            }
        }

        private static void GetFreshWebElements(IWebDriver driver)
        {
            pageElements.Clear();
            driver.Navigate().GoToUrl(Consts.CompetitionFormURL);
            pageElements.AddWebElementToDictionary(driver, Consts.NameXPath);
            pageElements.AddWebElementToDictionary(driver, Consts.SurnameXPath);
            pageElements.AddWebElementToDictionary(driver, Consts.BirthDateXPath);
            pageElements.AddWebElementToDictionary(driver, Consts.ParentalConsentCheckboxXPath);
            pageElements.AddWebElementToDictionary(driver, Consts.DoctorsPermissionCheckboxXPath);
            pageElements.AddWebElementToDictionary(driver, Consts.SubmitButtonXPath);
        }

    }
}
