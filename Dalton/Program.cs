using Dalton;
using Dalton.Models;
using Dalton.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var apiSettings = new ApiSettings();
builder.Configuration.GetSection("ApiSettings").Bind(apiSettings);
builder.Services.AddSingleton(apiSettings);

builder.Services.AddScoped<MyApiService>(); // Registro del servicio aqu�

builder.Services.AddScoped(sp =>
{
    var apiUrl = "https://localhost:7202"; // Reemplaza con la URL base de tu API
    return new HttpClient { BaseAddress = new Uri(apiUrl) };
});

await builder.Build().RunAsync();
