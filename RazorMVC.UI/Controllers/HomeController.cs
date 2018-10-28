using System;
using System.Collections.Generic;
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

        public IActionResult Index()
        {
            var IsUserLogged = false; // ToDo
            var typingMessage = IsUserLogged ? "Continue typing(space)" : "Start typing!(space)";

            var anchorList = new List<AnchorListViewModel>() {
                new AnchorListViewModel() { TextToDisplay = typingMessage, ControllerName = "Typing", ActionName = "Index" },
                new AnchorListViewModel() { TextToDisplay = "Change book(shift)", ControllerName = "Home", ActionName = "ChooseBook" },
                new AnchorListViewModel() { TextToDisplay = "Settings(esc)", ControllerName = "Home", ActionName = "Settings"}
            };
                        
            return View(anchorList);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page. JP.";

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
