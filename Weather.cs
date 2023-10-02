using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMapAPI
{
    public class Weather
    {
        public static void WeatherByCity()
        {

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string apiKey = config.GetSection("WeatherAPI")["APIKey"];

            HttpClient client = new HttpClient();

            //Reminder - Put a varable of the API key instead of the API itself and find a way to retrive this via appsettings
            //Don't forget to add a gitignore and add the jsonfile in it!
            //string cityName = "London"; °F

            Console.WriteLine("What city would you like to see the tempature for?");
            string cityName = Console.ReadLine();

            //endpoint
            string endpoint = $"https://api.openweathermap.org/data/2.5/weather?q={cityName}&appid={apiKey}&units=imperial";

            //get response as a string

            string weatherResponse = client.GetStringAsync(endpoint).Result;

            JObject weatherObject = JObject.Parse(weatherResponse);

            Console.WriteLine($"The tempature for {cityName} is: " +
                $"{weatherObject["main"]["temp"]}°F");
            Console.ReadLine();
        }
    }
}
