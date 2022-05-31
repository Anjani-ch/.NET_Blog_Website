using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Controllers
{
    public class ErrorController : Controller
    {
        // GET - NON-EXISTING ROUTES
        [Route("Error/404")]
        public IActionResult NotFoundPage()
        {
            return View("404");
        }
    }
}