using System;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorMVC.UI.Models;
using UILibrary.Helpers;

namespace RazorMVC.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDeserializeJsonHelper _deserializeJsonHelper; // IoC: field + ctor + Startup.cs

        public HomeController(IDeserializeJsonHelper deserializeJsonHelper) => _deserializeJsonHelper = deserializeJsonHelper;

        public IActionResult Index(int bookID = 1, int bookPage = 1)
        {
            var apiUrl = "http://localhost:5000/api/book/get/" + bookID.ToString() + "/" + bookPage.ToString();
            var modelFromAPI = _deserializeJsonHelper.DeserializeJsonData<Book>(apiUrl);           

            return View(modelFromAPI);
        }

        public IActionResult About()
        {
            // TODO - About jako okno modalne; Przeźroczystość modali? https://stackoverflow.com/questions/44155471/how-to-create-bootstrap-modal-with-transparent-background https://www.youtube.com/watch?v=YATsfCwwOMM 
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        //TODO
        public IActionResult ModalAbout()
        {
            ViewData["Message"] = "Your app;ication description page";

            return View("ModalMode");
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


        #region ComicAPI example 
        /// <summary>
        /// Check weather for your region using outher API, just for tutorial with ApiHelper https://www.youtube.com/watch?v=aWePkE2ReGw&t=1136s
        /// </summary>
        public IActionResult Weather(int imgNumber)
        {
            ApiHelper.InitializeClient();

            

            return View();
        }
        async Task LoadImage(int imgNumber)
        {
            var comic = await ComicProcessor.LoadComic(imgNumber);
            var uriSource = new Uri(comic.Img, UriKind.Absolute);
            //comicImage.Source = new BitmapImage(uriSource);
        }


         class ComicProcessor
        {
            public static async Task<ComicModel> LoadComic(int comicId = 0)
            {
                string url = "";

                if (comicId > 0)
                    url = $"https://xkcd.com/{ comicId }/info.0.json";
                else
                    url = $"https://xkcd.com/info.0.json";

                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        ComicModel comic = await response.Content.ReadAsAsync<ComicModel>(); // try convert json data to C# model - it will ignore other data (not used in C# model)
                        return comic;
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }
        }
        class ComicModel
        {
            public int Num { get; set; }
            public string Img { get; set; }
            // we can get more but we dont needen - names of properties should be same as JSON

            // JSON example: {"month": "9", "num": 2047, "link": "", "year": "2018", "news": "", "safe_title": "Beverages", "transcript": "", "alt": "If I wait a while, it's not so bad, because then it's just shaped like me, plus some pipes and tanks and probably eventually all of Earth's oceans.", "img": "https://imgs.xkcd.com/comics/beverages.png", "title": "Beverages", "day": "17"}
        }
        #endregion
        #region WatherAPI example 
        // https://www.youtube.com/watch?v=aWePkE2ReGw&t=1136s

        // (Api have two result - Result and Status - we must mach the model)
        class SunProcessor
        {
            public static async Task<SunModel> LoadData(int comicId = 0)
            {
                string url = "https://api.sunrise-sunset.org/json?lat=36.7201600&lng=-4.4203400";

                using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        SunResultModel sunModel = await response.Content.ReadAsAsync<SunResultModel>(); // try convert json data to C# model - it will ignore other data (not used in C# model)
                        return sunModel.Result; // We need only Result data
                    }
                    else
                        throw new Exception(response.ReasonPhrase);
                }
            }
        }
        class SunResultModel
        {
            public SunModel Result { get; set; }
            public string Status { get; set; }
        }
        class SunModel
        {
            public DateTime Sunrise { get; set; }
            public DateTime Sunset { get; set; }
        }
        #endregion
    }
}
