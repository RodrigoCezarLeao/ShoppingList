This app is used as a tool for shopping list production and management.

Be aware of how much you must pay before go to the cashier.



## Learnings from development

### C#

#### Working with JSON
```
    // Install package (version for dotnet 6+)
    // https://www.nuget.org/packages/Newtonsoft.Json
    dotnet add package Newtonsoft.Json --version 13.0.3

    // Import
    using Newtonsoft.Json.Linq;

    // Parse string to JsonObject (dynamic)
    var obj = JObject.Parse(jsonString);

    // Access data stored (must convert to some type)
    Console.WriteLine((string) obj["name"]);
```


### HTTP Request - Get Body Data from Request
```
    // Request Body is a Stream
    using(StreamReader s = new StreamReader(context.Request.Body))
    {
        // Read all json string content from request body
        var jsonString = await streamReader.ReadToEndAsync();
    }

```
    