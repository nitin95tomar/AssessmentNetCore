// See https://aka.ms/new-console-template for more information
using SwaggerClient;

Console.WriteLine("Hello, World!");
var httpClient = new HttpClient();
var client = new swaggerClient("https://localhost:51665/", httpClient);
//patients = await Http.GetAsync("") GetAsyn
var result = await client.GetPatientAsync(1);
Console.WriteLine(result);

