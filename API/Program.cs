
using API.Models;
using API.Services;
using Newtonsoft.Json.Linq;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/products", async (context) =>
{
    var lst = ProductService.getAllProducts();
    context.Response.Headers.Add("Content-Type", "text/html; charset=utf-8");
    context.Response.WriteAsync($"{string.Join("<br/>", lst)}");
});
app.MapPost("/products", async (context) =>
{
    using(StreamReader streamReader = new StreamReader(context.Request.Body))
    {
        var aux = await streamReader.ReadToEndAsync();
        var converted = JObject.Parse(aux);
        var product = new Product(){
            Name = (string) converted["name"],
            UnitOfMeasure = (string) converted["unit_of_measure"]
        };
        var res = ProductService.insertProduct(product);
        context.Response.WriteAsync($"{product.Name} adicionado com sucesso? {res}");
    }    
});
app.MapDelete("/products", async (context) =>
{    
    var reqParams = context.Request.QueryString.Value;
    var parsedReqParams = System.Web.HttpUtility.ParseQueryString(reqParams);
    var id = Convert.ToInt32(parsedReqParams["id"]);
    var res = ProductService.deleteProduct(id);
    context.Response.WriteAsync($"Item excluído com sucesso? {res}");
});
app.MapPut("/producs", async (context) =>
{   
    using(StreamReader streamReader = new StreamReader(context.Request.Body))
    {
        var contentBody = await streamReader.ReadToEndAsync();
        var obj = JObject.Parse(contentBody);
        var product = new Product() {
            Id = Convert.ToInt32(obj["id"]),
            Name = obj["name"].ToString(),
            UnitOfMeasure = obj["unit_of_measure"].ToString()
        };
        var res = ProductService.updateProduct(product);
        context.Response.WriteAsync($"{product.Name } atualizado com sucesso? {res}");
    }
    
    
    
});

app.Run();
