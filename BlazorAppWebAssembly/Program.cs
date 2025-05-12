using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorAppWebAssembly;
using FluentValidation;
using BlazorAppWebAssembly.Features.Comments.DTO;
using BlazorAppWebAssembly.Features.Comments.Validators;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//  service:
//      Signleton   - keep 1 instance always
//      Scoped      - keep 1 instnace inside scope (for ex., request to Action)
//      Transient   - always new instance

//  builder.HostEnvironment.BaseAddress
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5062") });
builder.Services.AddScoped<IValidator<CommentDto>, CommentDtoValidator>();

await builder.Build().RunAsync();