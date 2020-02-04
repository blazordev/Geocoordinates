using Geocoordinates.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Geocoordinates.Services
{
    public class CrawlerService
    {
        public Coordinates StartChrome(string city, string country)
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            var input = driver.FindElementByXPath("//input[@class='gLFyf gsfi']");


            input.SendKeys($"{city}, {country} coordinates");
            input.SendKeys(Keys.Enter);

            if (String.IsNullOrEmpty(city) || String.IsNullOrEmpty(country))
            {
                return null;
            }            

            var latLong = driver.FindElementByXPath("//div[@class='Z0LcW']").Text;
            string[] latLongArray = latLong.Split(",");
            var coordinates = new Coordinates();
            coordinates.Latitude = latLongArray[0];
            coordinates.Longitude = latLongArray[1];
            coordinates.City = city;
            coordinates.Country = country;
            return coordinates;
        }

    }
}
