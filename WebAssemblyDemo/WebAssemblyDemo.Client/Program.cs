using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using WebAssemblyDemo.Client;
using WebAssemblyDemo.Client.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSingleton<ContainerStorage>();

builder.Services.AddHttpClient("ServersApi", client =>
{
    client.BaseAddress = new Uri("https://webassembly-demo-f47ec-default-rtdb.asia-southeast1.firebasedatabase.app/");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddTransient<IServersRepository, ServersApiRepository>();

await builder.Build().RunAsync();
