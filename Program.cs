using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using azureSamples;
using azureSamples.Models;
using azureSamples.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Http;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

string baseAddress = "https://alwaysfunc.azurewebsites.net/";

// Scoped Client  - used forcalling a single API in the Application 
builder.Services.AddScoped(sp => 
    new HttpClient { BaseAddress = new Uri(baseAddress)});


// Named Client - used for calling multiple APIs in the Application
builder.Services.AddHttpClient("WeatherForecastAPI", client => 
    client.BaseAddress = new Uri(baseAddress));

// Typed client - used for calling multiple APIs in the Application
builder.Services.AddHttpClient<ForecastHttpClient>(client => 
    client.BaseAddress = new Uri(baseAddress));

await builder.Build().RunAsync();
