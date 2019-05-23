using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentCar.Entity;
          
namespace RentCar.Web.Controllers
{

    public class CarController : Controller
    {
        public async Task<IActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            using (HttpResponseMessage response = await client.GetAsync("https://localhost:44367/api/values"))
            using (HttpContent context = response.Content)
            {
                var data = context.ReadAsStringAsync().Result;

                Car c = JsonConvert.DeserializeObject<Car>(data);
                try
                {
                    Console.WriteLine(context.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            return View();
        }
    }
}