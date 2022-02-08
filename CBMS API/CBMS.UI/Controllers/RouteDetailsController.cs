using CBMS.Entity.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CBMS.UI.Controllers
{
    public class RouteDetailsController : Controller
    {
        private IConfiguration _configuration;
        public RouteDetailsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IActionResult> RouteDetails()
        {
            IEnumerable<RouteDetails> routeDetails = null;
            using (HttpClient client = new HttpClient())
            {
                string endPoint = _configuration["WebApiBaseUrl"] + "RouteDetails/GetRouteDetails";
                using (var response = await client.GetAsync(endPoint))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        var result = await response.Content.ReadAsStringAsync();
                        routeDetails = JsonConvert.DeserializeObject<IEnumerable<RouteDetails>>(result);
                    }
                }
            }
            return View(routeDetails);
        }
        public IActionResult RouteDetailsEntry()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RouteDetailsEntry(RouteDetails routeDetails)
        {
            ViewBag.status = "";
            using (HttpClient client = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(routeDetails), Encoding.UTF8, "application/json");
                string endPoint = _configuration["WebApiBaseUrl"] + "RouteDetails/AddRouteDetails";
                using (var response = await client.PostAsync(endPoint, content))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        ViewBag.status = "Ok";
                        ViewBag.message = "RouteDetails details saved successfully!";
                    }
                    else
                    {
                        ViewBag.status = "Error";
                        ViewBag.message = "Wrong entries!";
                    }
                }
            }
            return View();
        }
    }
}
