using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MyFarm;
using MudBlazor.Services;
using MyFarm.Services;
using System.Net.Http;
using MyFarm.Models;
using MyFarm.DataApi;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Rejestracja globalnego HttpClient z ustawionym BaseAddress
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7111/") });

// Rejestracja IOrderService z jego implementacją
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<Order>();

// Dodanie MudBlazor Services
builder.Services.AddMudServices();

await builder.Build().RunAsync();