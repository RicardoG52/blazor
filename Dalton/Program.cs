using Dalton;
using Dalton.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<MyApiService>(); // Registro del servicio aqu�
builder.Services.AddScoped(sp =>
{
    return new HttpClient();
});

await builder.Build().RunAsync();
