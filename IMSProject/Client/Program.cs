global using IMSProject.Client.Services.ItemServices;
global using System.Net.Http.Json;
global using IMSProject.Shared;
using IMSProject.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using IMSProject.Client.Services.CategoryGroupService;
using IMSProject.Client.Services.UnitService;
using IMSProject.Client.Services.CategoryService;
using IMSProject.Client.Services.COFService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<ICategoryGroupService, CategoryGroupService>();
builder.Services.AddScoped<ICOFService, COFService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUnitService, UnitService>();
await builder.Build().RunAsync();
