using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RazorMVC.UI.Models;
using UILibrary.Helpers;

namespace RazorMVC.UI.Controllers
{
    public class TypeController : Controller
    {
        private readonly IDeserializeJsonHelper _deserializeJsonHelper; // IoC: field + ctor + Startup.cs

        public TypeController(IDeserializeJsonHelper deserializeJsonHelper) => _deserializeJsonHelper = deserializeJsonHelper;

        public IActionResult Index()
        {
            var apiUrl = "http://localhost:5000/api/book/get/" + Book.ToString() + "/" + bookPage.ToString();
            var modelFromAPI = _deserializeJsonHelper.DeserializeJsonData<Book>(apiUrl);

            return View(modelFromAPI);
        }


    }
}