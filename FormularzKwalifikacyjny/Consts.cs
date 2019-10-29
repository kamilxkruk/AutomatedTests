using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormularzKwalifikacyjny
{
    public static class Consts
    {
        public const string CompetitionFormURL = @"https://lamp.ii.us.edu.pl/~mtdyd/zawody/";
        public const string NameXPath = @"//*[@id='inputEmail3']";
        public const string SurnameXPath = @"//*[@id='inputPassword3']";
        public const string BirthDateXPath = @"//*[@id='dataU']";
        public const string ParentalConsentCheckboxXPath = @"//*[@id='rodzice']";
        public const string DoctorsPermissionCheckboxXPath = @"//*[@id='lekarz']";
        public const string SubmitButtonXPath = @"//*[@id='formma']/div[6]/div/button";

        public const string ExpectedNotQualified = "Brak kwalifikacji";
        public const string ExpectedSprat = "Skrzat";
        public const string ExpectedYoungster = "Mlodzik";
        public const string ExpectedJunior = "Junior";
        public const string ExpectedAdult = "Dorosly";
        public const string ExpectedSenior = "Senior";
        public const string ExpectedWrongData = "Blad danych";

    }
}
