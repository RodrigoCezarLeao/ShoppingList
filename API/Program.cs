using API.Models;
using API.Services;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/products", async (context) => {
    var lst = ProductService.getAllProducts();
    context.Response.Headers.Add("Content-Type", "text/html; charset=utf-8");
    context.Response.WriteAsync($"{string.Join("<br/>", lst)}");
    
});

app.Run();
