//using Inkript.VR.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Net.Http.Headers;
//using System.Threading.Tasks;
//using System.Web;

//namespace Inkript.VR.API.Helpers
//{
//    public class PaymentOrderAPIHelper
//    {
//        static HttpClient client = new HttpClient();

//        public static async Task<Uri> SubmitOrder(SubmitOrder submitOrder)
//        {
//            try
//            {
//                using (var client = new HttpClient())
//                {
//                    HttpResponseMessage response = await client.PostAsJsonAsync("api/submitOrder", submitOrder);
//                    response.EnsureSuccessStatusCode();

//                    // return URI of the created resource.
//                    return response.Headers.Location;
//                }
//            }
//            catch (Exception ex)
//            {
//                Log.ErrorFormat(" Method : GetAsyncWebApiCall, Date: '{0}', Error Message: '{1}'", DateTime.Now, ex.ToString());
//            }
//        }

//        public SubmitOrder CreateSubmitOrder(Application application)
//        {
//            SubmitOrder submitOrder = new SubmitOrder();

//        }

//        //static async Task RunAsync()
//        //{
//        //    // Update port # in the following line.
//        //    client.BaseAddress = new Uri("http://10.1.9.130:5511/");
//        //    client.DefaultRequestHeaders.Accept.Clear();
//        //    client.DefaultRequestHeaders.Accept.Add(
//        //        new MediaTypeWithQualityHeaderValue("application/json"));

//        //    try
//        //    {
//        //        // Create a new product
//        //        Product product = new Product
//        //        {
//        //            Name = "Gizmo",
//        //            Price = 100,
//        //            Category = "Widgets"
//        //        };

//        //        var url = await CreateProductAsync(product);
//        //        Console.WriteLine($"Created at {url}");

//        //        // Get the product
//        //        product = await GetProductAsync(url.PathAndQuery);
//        //        ShowProduct(product);

//        //        // Update the product
//        //        Console.WriteLine("Updating price...");
//        //        product.Price = 80;
//        //        await UpdateProductAsync(product);

//        //        // Get the updated product
//        //        product = await GetProductAsync(url.PathAndQuery);
//        //        ShowProduct(product);

//        //        // Delete the product
//        //        var statusCode = await DeleteProductAsync(product.Id);
//        //        Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

//        //    }
//        //    catch (Exception e)
//        //    {
//        //        Console.WriteLine(e.Message);
//        //    }

//        //    Console.ReadLine();
//        //}
//    }
//}