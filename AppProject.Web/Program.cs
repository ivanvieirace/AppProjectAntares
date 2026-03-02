using AppProject.Web;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

WebAssemblyHostBuilder.CreateDefault(args).RootComponents.Add<App>("#app");
WebAssemblyHostBuilder.CreateDefault(args).RootComponents.Add<HeadOutlet>("head::after");

WebAssemblyHostBuilder.CreateDefault(args).Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(WebAssemblyHostBuilder.CreateDefault(args).HostEnvironment.BaseAddress) });

await WebAssemblyHostBuilder.CreateDefault(args).Build().RunAsync();
