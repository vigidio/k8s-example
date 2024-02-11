var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.Urls.Add("http://*:5274");

app.MapGet("/", () => "Hello World4!");

app.Run();
