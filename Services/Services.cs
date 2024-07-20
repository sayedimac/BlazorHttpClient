using System.Net.Http.Json;
using azureSamples.Models;

namespace azureSamples.Services
{
    // public class ForecastHttpClient(HttpClient http)
    // {
    //     public async Task<Forecast[]> GetForecastAsync()
    //     {
    //         return await http.GetFromJsonAsync<Forecast[]>("forecast") ?? [];
    //     }
    // }
    public class ForecastHttpClient(HttpClient http)
    {
        public async Task<WeatherForecast[]> GetForecastAsync()
        {
            return await http.GetFromJsonAsync<WeatherForecast[]>("api/getweather") ?? [];
        }
    }

    public class SearchHttpClient(HttpClient http)
    {
        public async Task<azureSearchIndex[]> GetIndexesAsync()
        {
            // http.DefaultRequestHeaders.Add("api-key", "9mqjeGidy1kZn0kXWu1LqCW2sb61mfgfXYuSxZqM9GAzSeAgIUdh");
            return await http.GetFromJsonAsync<azureSearchIndex[]>("/indexes?api-version=2023-11-01") ?? [];
        }
    }

}