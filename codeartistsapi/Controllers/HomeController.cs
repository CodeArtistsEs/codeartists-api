using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace codeartistsapi.Controllers
{
    public class HomeController: Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public ActionResult Index()
        {
            //The web root is the root directory from which static content is served, while the content root is the
            //application base path. You can then use either path in conjunction with Path.Combine() to construct a
            //physical file path to a specific file or directory.
            //TODO: enable only in debug mode
            string webRootPath = _hostingEnvironment.WebRootPath;
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            return Content("codeartistsapi started" + "\n \n webRootPath: " 
                                                    + webRootPath + "\n contentRootPath: " 
                                                    + contentRootPath);
        }
        
    }
}