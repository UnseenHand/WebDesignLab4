using Microsoft.AspNetCore.Mvc;

namespace WebDesignLab4.Controllers
{
    public class ContactsController : Controller
    {
        public IActionResult Contact()
        {
            return View();
        }
    }
}
