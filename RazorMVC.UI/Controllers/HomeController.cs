using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RazorMVC.UI.Models;

namespace RazorMVC.UI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // get data from API:
            var url = "http://localhost:5000/api/book/1";
            var modelFromAPI = _download_serialized_json_data<Book>(url);

            // ToDo - podzielić na partie Content - i czy get`em czy postem? - A może w ViewModel? pobierasz całość a wysyłasz jako array/liste rozdzielonych stringów?; Albo metoda z helpera?


            return View(modelFromAPI);
        }

        public IActionResult About()
        {
            // TODO - About jako okno modalne; Przeźroczystość modali? https://stackoverflow.com/questions/44155471/how-to-create-bootstrap-modal-with-transparent-background https://www.youtube.com/watch?v=YATsfCwwOMM 
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        #region data from API  
        // ToDo - przenieść do Helpera - wstrzyknąć przez IoC aby był dostępny globalnie (?)
        private static T _download_serialized_json_data<T>(string url) where T : new()
        {
            using (var w = new WebClient())
            {
                var json_data = string.Empty;
                // attempt to download JSON data as a string
                try
                {
                    json_data = w.DownloadString(url);
                }
                catch (Exception) { }
                // if string with JSON data is not empty, deserialize it to class and return its instance 
                return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();
            }
        }
        #endregion
    }
}
