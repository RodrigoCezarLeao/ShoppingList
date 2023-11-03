using System.Globalization;
using API.Models;
using API.Services;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace API.Controllers
{
    public class ProductController {
        public WebApplication _app { get; set; }
        public ProductController(WebApplication app)
        {
            this._app = app;
            this.initiateEndpoints();
        }

        public void initiateEndpoints()
        {
            this.getAllProducts();
            this.insertProduct();
            this.deleteProduct();
            this.updateProduct();
        }

        public void getAllProducts()
        {
            this._app.MapGet("/products", async (context) =>
            {
                var lst = ProductService.getAllProducts();
                context.Response.Headers.Add("Content-Type", "application/json;");
                context.Response.WriteAsync(JsonConvert.SerializeObject(lst));
            });
        }

        public void insertProduct()
        {
            this._app.MapPost("/products", async (context) =>
            {
                using (StreamReader streamReader = new StreamReader(context.Request.Body))
                {
                    var aux = await streamReader.ReadToEndAsync();
                    var converted = JObject.Parse(aux);
                    var product = new Product()
                    {
                        Name = (string)converted["name"],
                        UnitOfMeasure = (string)converted["unit_of_measure"]
                    };
                    var res = ProductService.insertProduct(product);
                    context.Response.Headers.Add("Content-Type", "application/json;");
                    context.Response.WriteAsync($"{res}");
                }
            });
        }

        
        public void deleteProduct()
        {
            this._app.MapDelete("/products", async (context) =>
            {
                var reqParams = context.Request.QueryString.Value;
                var parsedReqParams = System.Web.HttpUtility.ParseQueryString(reqParams);
                var id = Convert.ToInt32(parsedReqParams["id"]);
                var res = ProductService.deleteProduct(id);
                context.Response.Headers.Add("Content-Type", "application/json;");
                context.Response.WriteAsync($"{res}");
            });
        }
        
        public void updateProduct()
        {
            this._app.MapPut("/producs", async (context) =>
            {
                using (StreamReader streamReader = new StreamReader(context.Request.Body))
                {
                    var contentBody = await streamReader.ReadToEndAsync();
                    var obj = JObject.Parse(contentBody);
                    var product = new Product()
                    {
                        Id = Convert.ToInt32(obj["id"]),
                        Name = obj["name"].ToString(),
                        UnitOfMeasure = obj["unit_of_measure"].ToString()
                    };
                    var res = ProductService.updateProduct(product);
                    context.Response.Headers.Add("Content-Type", "application/json;");
                    context.Response.WriteAsync($"{res}");
                }
            });   
        }
    }
}