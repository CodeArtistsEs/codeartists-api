using System.Collections.Generic;
using System.Linq;
using codeartistsapi.Models;
using codeartistsapi.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using codeartistsapi.Helpers;

namespace codeartistsapi.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : Controller
    {
        private readonly INewsRepository _newsRepository;

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var newsList = _newsRepository.FindAll().ToList();

            var response = new JsonDataResponse() {Data = newsList, Error = "", Ok = true};

            return Ok(response);
        }
    }
}