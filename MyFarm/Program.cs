using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;
using MyFarm;
using MyFarm.Models;
using MyFarm.Services;
using MyFarm.DataApi;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var baseAddress = builder.Configuration.GetValue<string>("ApiSettings:BaseUrl");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(baseAddress) });


builder.Services.AddScoped<OrderService>();
builder.Services.AddScoped<OrderDataProvider>();
builder.Services.AddScoped<Order>();


builder.Services.AddMudServices();
await builder.Build().RunAsync();
