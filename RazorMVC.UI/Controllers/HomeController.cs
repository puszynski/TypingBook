using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RazorMVC.UI.Models;
using UILibrary.Helpers;

namespace RazorMVC.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDeserializeJsonHelper _deserializeJsonHelper; // IoC: field + ctor + Startup.cs

        public HomeController(IDeserializeJsonHelper deserializeJsonHelper) => _deserializeJsonHelper = deserializeJsonHelper;
        
        public IActionResult Index()
        {
            var apiUrl = "http://localhost:5000/api/book/1";
            var modelFromAPI = _deserializeJsonHelper.DeserializeJsonData<Book>(apiUrl);

            var msgFromExtensionMethod = _deserializeJsonHelper.HelloFromExtensionMethod();

            @ViewBag.ValidateCaps = false;
            @ViewBag.MoveForwardWhenWrong = false;
                       
            return View(modelFromAPI);
        }

        public IActionResult About()
        {
            // TODO - About jako okno modalne; Przeźroczystość modali? https://stackoverflow.com/questions/44155471/how-to-create-bootstrap-modal-with-transparent-background https://www.youtube.com/watch?v=YATsfCwwOMM 
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult ModalAbout() //ToDO
        {            
            ViewData["Message"] = "Your application description page.";

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
    }
}
