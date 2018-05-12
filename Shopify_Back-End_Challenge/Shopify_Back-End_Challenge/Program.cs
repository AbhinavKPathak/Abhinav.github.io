using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Shopify_Back_End_Challenge
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static List<JToken> product = new List<JToken>();
        static Boolean Flag = false, got_pages = false, displayed = false;
        static int total_pages = 0, per_page = 0, no_of_pages = 0, count = 1;
        static ProductCollection pc = new ProductCollection();
        static decimal total = 0;

        static void Main()
        {
            GetUserInput();
        }

        static void GetUserInput()
        {
            string input = Console.ReadLine();
            dynamic userinput = JsonConvert.DeserializeObject(input);

            GetDiscount(userinput);
        }
        static async Task RunAsync(int cartid, int pageid)
        {

            List<JToken> product = new List<JToken>();
            if (Flag == false)
            {
                got_pages = await GetPages($"http://backend-challenge-fall-2018.herokuapp.com/carts.json?id={cartid}&page=1");
                Flag = true;
            }
            if (got_pages)
            {
                product = await GetProductAsync(cartid, $"http://backend-challenge-fall-2018.herokuapp.com/carts.json?id={cartid}&page={pageid}");
            }
            AddProducts(product);
        }

        class ProductCollection : List<Product> { }
        class Product
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Collection { get; set; }
        }
        static void AddProducts(List<JToken> products)
        {
            if (displayed == false)
            {
                foreach (JToken p in products)
                {
                    if (p.ToArray().Length > 2)
                    {
                        pc.Add(new Product
                        {
                            Name = p["name"].ToString(),
                            Price = decimal.Parse(p["price"].ToString()),
                            Collection = (p["collection"].ToString() == "" ? "" : p["collection"].ToString())
                        });
                    }
                    else
                    {
                        pc.Add(new Product
                        {
                            Name = p["name"].ToString(),
                            Price = decimal.Parse(p["price"].ToString())
                        });
                    }
                }
                displayed = true;
            }
        }

        static void CalculateFinal(decimal total_before)
        {
            Console.WriteLine("{");
            Console.WriteLine("  " + "\"total_amount\"" + ":" + " " + total_before + ",");
            Console.WriteLine("  " + "\"total_after_discount\"" + ":" + " " + total + "");
            Console.WriteLine("}");
            Console.ReadLine();
        }

        static void GetDiscount(dynamic userinput)
        {
            int id = userinput.id;
            string d_type = userinput.discount_type;
            decimal d_value = userinput.discount_value;
            decimal cart_value = 0;
            decimal product_value = 0;
            string collection = "";
            try
            {
                cart_value = userinput.cart_value;
            }
            catch (Exception e) { }
            try
            {
                product_value = userinput.product_value;
            }
            catch (Exception e)
            { }
            try
            {
                collection = userinput.collection;
            }
            catch (Exception e) { }

            RunAsync(id, 1).GetAwaiter().GetResult();

            foreach (Product p in pc)
            {
                total += p.Price;
            }

            decimal totalbefore = total;
            if (cart_value != 0)
            {
                if (total >= cart_value)
                {
                    total -= d_value;
                }
            }
            else if (product_value != 0)
            {
                foreach (Product p in pc)
                {
                    if (p.Price >= product_value)
                    {
                        if ((p.Price - d_value) > 0)
                        {
                            total -= d_value;
                            p.Price -= d_value;
                        }
                        else
                        {
                            total -= p.Price;
                            p.Price = 0;
                        }
                    }
                }
            }
            else if (collection != String.Empty)
            {

                foreach (Product p in pc)
                {
                    if (p.Collection != null)
                    {
                        if (p.Collection.Equals(collection))
                        {
                            if ((p.Price >= d_value))
                                total -= d_value;
                            else
                                total -= p.Price;
                        }
                    }
                }
            }
            CalculateFinal(totalbefore);
        }

        private static async Task<Boolean> GetPages(string path)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string s = await response.Content.ReadAsStringAsync();
                JObject jObject = JObject.Parse(s);
                per_page = int.Parse(jObject["pagination"]["per_page"].ToString());
                total_pages = int.Parse(jObject["pagination"]["total"].ToString());
                no_of_pages = total_pages / per_page;
                no_of_pages++;
            }
            return true;
        }
        private static async Task<List<JToken>> GetProductAsync(int id, string path)
        {

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string s = await response.Content.ReadAsStringAsync();
                JObject jObject = JObject.Parse(s);
                foreach (JToken j in jObject["products"])
                {
                    product.Add(j);
                }
            }
            while (count <= no_of_pages)
                await RunAsync(id, ++count);

            return product;
        }
    }
}
