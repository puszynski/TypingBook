using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorMVC.UI.Models;
using UILibrary.Helpers;

namespace RazorMVC.UI.Controllers
{
    public class TypingController : Controller
    {
        private readonly IDeserializeJsonHelper _deserializeJsonHelper; // IoC: field + ctor + Startup.cs

        public TypingController(IDeserializeJsonHelper deserializeJsonHelper) => _deserializeJsonHelper = deserializeJsonHelper;

        public IActionResult Index(int bookID = 1, int bookPage = 1)
        {
            var apiUrl = "http://localhost:5000/api/book/get/" + bookID.ToString() + "/" + bookPage.ToString();
            var modelFromAPI = _deserializeJsonHelper.DeserializeJsonData<Book>(apiUrl);

            return View(modelFromAPI);
        }


    }
}