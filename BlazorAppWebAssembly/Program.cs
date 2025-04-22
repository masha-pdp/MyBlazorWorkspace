using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorAppWebAssembly;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//  service:
//      Signleton   - keep 1 instance always
//      Scoped      - keep 1 instnace inside scope (for ex., request to Action)
//      Transient   - always new instance

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5062") });

await builder.Build().RunAsync();