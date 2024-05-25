using BlazorApp1;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

#if (!DEBUG)
builder.Services.AddResponseCompression(options =>
{
    options.EnableForHttps = true;
});
#endif

//builder.Services.AddWebOptimizer(pipeline => {
//    pipeline.AddCssBundle("/css/bundle.css", new NUglify.Css.CssSettings
//    {
//        CommentMode = NUglify.Css.CssComment.None,

//    }, "app.css", "css/bootstrap.css", "style.css",
//    "css/plugins.css", "css/colors.css", "css/responsive.css");
//    pipeline.MinifyJsFiles("/js/jqueryCustom.js");
//});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
