using CoreWCF;
using CoreWCF.Configuration;
using Presentation.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddServiceModelServices(); // Register CoreWCF services
var app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<MultimediaSoapService>();
    serviceBuilder.AddServiceEndpoint<MultimediaSoapService, IMultimediaSoapService>(
        new BasicHttpBinding(), "/soap/multimedia");
});

app.MapGet("/", () => "Hello World!");

app.Run();
