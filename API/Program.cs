
using API.Models;
using API.Services;
using API.Controllers;
using Newtonsoft.Json.Linq;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        new ProductController(app);
        
        app.Run();
    }
}