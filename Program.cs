using Microsoft.Extensions.Configuration;
using System.Data;
using System.IO;
using System;


namespace OpenWeatherMapAPI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Weather.WeatherByCity();
           
        }
    }
}