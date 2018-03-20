using System.Collections.Generic;
using codeartistsapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace codeartistsapi.Controllers
{
    public class NewsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            //return View();
            return null;
        }

        public List<New> GetAllNews()
        {
            var testProducts = new List<New>();
            
            testProducts.Add(new New() {Id=1,Header="New",Content=""}) ;
            return testProducts;
        }
    }
}