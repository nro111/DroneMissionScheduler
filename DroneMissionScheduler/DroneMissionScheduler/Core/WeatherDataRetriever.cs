using DroneMissionScheduler.Core.Interfaces;
using RestSharp;
using System;

namespace DroneMissionScheduler.Core
{
    public class WeatherDataRetriever : IWeatherDataRetriever
    {
        public string PullWeatherData(string zip)
        {
            try
            {
                var client = new RestClient("https://community-open-weather-map.p.rapidapi.com/forecast?zip=" + zip);
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                request.AddHeader("x-rapidapi-key", "fe55c28620msh256399944b70185p112062jsnb48279ed3bf8");
                request.AddHeader("x-rapidapi-host", "community-open-weather-map.p.rapidapi.com");
                IRestResponse response = client.Execute(request);
                return response.Content;
            }
            catch(Exception ex)
            {
                return "Unable to pull weather data for this zip code. Please try again.";
            }            
        }
    }
}