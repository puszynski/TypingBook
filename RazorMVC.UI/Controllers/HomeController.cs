using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RazorMVC.UI.Models;
using UILibrary.Helpers;

namespace RazorMVC.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly DeserializeJsonHelper _deserializeJsonHelper = new DeserializeJsonHelper();

        public IActionResult Index()
        {
            // get data from API:
            var apiUrl = "http://localhost:5000/api/book/1";
            var modelFromAPI = _deserializeJsonHelper.DeserializeJsonData<Book>(apiUrl);

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
    }
}
