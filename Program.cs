using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using nstechevents;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

var http = builder.Services.BuildServiceProvider().GetRequiredService<HttpClient>();

using var response = await http.GetAsync("config.json");
using var stream = await response.Content.ReadAsStreamAsync();

builder.Configuration.AddJsonStream(stream);

builder.Services.Configure<State>((o) => builder.Configuration.Bind(o));

builder.Services.AddSingleton<StateService>();
builder.Services.AddSingleton<PeriodicExecutor>();


await builder.Build().RunAsync();
