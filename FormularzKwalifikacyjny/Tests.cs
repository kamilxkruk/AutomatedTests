using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using static FormularzKwalifikacyjny.Program;

namespace FormularzKwalifikacyjny
{
    public static class Tests
    {

        //Validation tests 
        public static List<Func<IWebDriver, bool>> validationTests { get; } = new List<Func<IWebDriver, bool>>
        {
            (driver) => { return driver.TestForm("$!@$","Test",5,Consts.ExpectedWrongData); },
            (driver) => { return driver.TestForm("$!@$","Test",5,Consts.ExpectedWrongData, true, false); },
            (driver) => { return driver.TestForm("$!@$","Test",5,Consts.ExpectedWrongData, false, true); },
            (driver) => { return driver.TestForm("$!@$","Test",5,Consts.ExpectedWrongData, true, true); },

            (driver) => { return driver.TestForm("Test","$!@$",5,Consts.ExpectedWrongData); },
            (driver) => { return driver.TestForm("Test","$!@$",5,Consts.ExpectedWrongData ,true, false); },
            (driver) => { return driver.TestForm("Test","$!@$",5,Consts.ExpectedWrongData, false, true); },
            (driver) => { return driver.TestForm("Test","$!@$",5,Consts.ExpectedWrongData, true, true); },

            (driver) => { return driver.TestForm("Test","Test",5,Consts.ExpectedWrongData, rawDate:"$!@$"); },
            (driver) => { return driver.TestForm("Test","Test",5,Consts.ExpectedWrongData,true, false, rawDate:"$!@$"); },
            (driver) => { return driver.TestForm("Test","Test",5,Consts.ExpectedWrongData, false, true, rawDate:"$!@$"); },
            (driver) => { return driver.TestForm("Test","Test",5,Consts.ExpectedWrongData, true, true, rawDate:"$!@$"); },

            (driver) => { return driver.TestForm("10","Test",5,Consts.ExpectedWrongData); },
            (driver) => { return driver.TestForm("10","Test",5,Consts.ExpectedWrongData, true, false); },
            (driver) => { return driver.TestForm("10","Test",5,Consts.ExpectedWrongData, false, true); },
            (driver) => { return driver.TestForm("10","Test",5,Consts.ExpectedWrongData, true, true); },

            (driver) => { return driver.TestForm("Test","10",5,Consts.ExpectedWrongData, rawDate: "Totally wrong date format"); },
            (driver) => { return driver.TestForm("Test","10",5,Consts.ExpectedWrongData, false, true, rawDate: "Totally wrong date format"); },
            (driver) => { return driver.TestForm("Test","10",5,Consts.ExpectedWrongData, true, false, rawDate: "Totally wrong date format"); },
            (driver) => { return driver.TestForm("Test","10",5,Consts.ExpectedWrongData, true, true ,rawDate: "Totally wrong date format"); },

            (driver) => { return driver.TestForm("Test","Test",5,Consts.ExpectedWrongData, rawDate: "1"); },
            (driver) => { return driver.TestForm("Test","Test",5,Consts.ExpectedWrongData, false, true, rawDate: "1"); },
            (driver) => { return driver.TestForm("Test","Test",5,Consts.ExpectedWrongData, true, false, rawDate: "1"); },
            (driver) => { return driver.TestForm("Test","Test",5,Consts.ExpectedWrongData, true, true, rawDate: "1"); },

            (driver) => { return driver.TestForm("Test","Test",5,Consts.ExpectedWrongData, rawDate: "1x"); },
        };

        //Functional tests
        public static List<Func<IWebDriver,bool>> functionalTests { get; } = new List<Func<IWebDriver,bool>>
        {
            (driver) => { return driver.TestForm("Test","Test",5,Consts.ExpectedNotQualified); },
            (driver) => { return driver.TestForm("Test","Test",10,Consts.ExpectedNotQualified); },
            (driver) => { return driver.TestForm("Test","Test",10,Consts.ExpectedNotQualified,true, false); },
            (driver) => { return driver.TestForm("Test","Test",10,Consts.ExpectedNotQualified, false,true); },
            (driver) => { return driver.TestForm("Test","Test",10,Consts.ExpectedSprat,true,true); },

            (driver) => { return driver.TestForm("Test","Test",12,Consts.ExpectedNotQualified); },
            (driver) => { return driver.TestForm("Test","Test",12,Consts.ExpectedNotQualified,true, false); },
            (driver) => { return driver.TestForm("Test","Test",12,Consts.ExpectedNotQualified, false,true); },
            (driver) => { return driver.TestForm("Test","Test",12,Consts.ExpectedYoungster,true,true); },

            (driver) => { return driver.TestForm("Test","Test",16,Consts.ExpectedNotQualified); },
            (driver) => { return driver.TestForm("Test","Test",16,Consts.ExpectedNotQualified,true, false); },
            (driver) => { return driver.TestForm("Test","Test",16,Consts.ExpectedNotQualified, false,true); },
            (driver) => { return driver.TestForm("Test","Test",16,Consts.ExpectedJunior,true,true); },

            (driver) => { return driver.TestForm("Test","Test",20,Consts.ExpectedAdult); },
            (driver) => { return driver.TestForm("Test","Test",20,Consts.ExpectedAdult,true, false); },
            (driver) => { return driver.TestForm("Test","Test",20,Consts.ExpectedAdult, false,true); },
            (driver) => { return driver.TestForm("Test","Test",20,Consts.ExpectedAdult,true,true); },

            (driver) => { return driver.TestForm("Test","Test",70,Consts.ExpectedNotQualified); },
            (driver) => { return driver.TestForm("Test","Test",70,Consts.ExpectedNotQualified,false,true); },
            (driver) => { return driver.TestForm("Test","Test",70,Consts.ExpectedSenior, true, false); },
            (driver) => { return driver.TestForm("Test","Test",70,Consts.ExpectedSenior, true, true); },
        };

        private static bool TestForm(this IWebDriver driver, string nameValue, string surnameValue, int yearsOld, string expectedValue,bool doctorChecked = false, bool parentsChecked = false, string rawDate = null)
        {
            pageElements[Consts.NameXPath].Clear();
            pageElements[Consts.SurnameXPath].Clear();
            pageElements[Consts.BirthDateXPath].Clear();
            if (pageElements[Consts.DoctorsPermissionCheckboxXPath].Selected) pageElements[Consts.DoctorsPermissionCheckboxXPath].Click();
            if (pageElements[Consts.ParentalConsentCheckboxXPath].Selected) pageElements[Consts.ParentalConsentCheckboxXPath].Click();

            pageElements[Consts.NameXPath].SendKeys(nameValue);
            pageElements[Consts.SurnameXPath].SendKeys(surnameValue);
            pageElements[Consts.BirthDateXPath].SendKeys( rawDate ?? DateTime.Now.AddYears(-yearsOld).ToString("dd-MM-yyyy"));
            if(doctorChecked) pageElements[Consts.DoctorsPermissionCheckboxXPath].Click();
            if(parentsChecked) pageElements[Consts.ParentalConsentCheckboxXPath].Click();
            pageElements[Consts.SubmitButtonXPath].Click();
            Thread.Sleep(500);
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            var alertText = alert.Text;
            var result = alertText == expectedValue;
            alert.Accept();
            if (!result)
            {
                Console.WriteLine($@"For parameters
Name: {nameValue},
Surname: {surnameValue},
Years old: {yearsOld},
Doctors permission: {doctorChecked},
Parental consent: {parentsChecked},
Raw date: {rawDate}
Expected value: {expectedValue}, Was: {alertText}
");
            }

            return result;
        }


    }
}
