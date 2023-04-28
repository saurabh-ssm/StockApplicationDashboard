using DataAccessLayer.Repository.IRepository;
using ModelsLayer;
using Microsoft.AspNetCore.Mvc;
using ModelsLayer.Model;
using Newtonsoft.Json;
using StocksMvc.Models;

namespace StocksMvc.Controllers
{
    public class UserController : Controller
    {
        Uri baseAddress = new Uri("http://localhost:5115/api/Stock/");
        HttpClient client;
        public UserController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public IActionResult Index()
        {
            
           // Response.AddHeader("Refresh", "5");
            List<StockApi> modelList=new List<StockApi>();
            HttpResponseMessage response=client.GetAsync(client.BaseAddress).Result;
            if (response.IsSuccessStatusCode)
            {
                string data=response.Content.ReadAsStringAsync().Result;
                modelList=JsonConvert.DeserializeObject<List<StockApi>>(data);
            }
            Response.Headers.Add("Refresh", "3");
            return View(modelList);
        }

    }
}
