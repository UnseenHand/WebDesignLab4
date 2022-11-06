using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebDesignLab4.DAL;
using WebDesignLab4.Models;

namespace WebDesignLab4.Controllers
{
    public class ContactsController : Controller
    {
        private readonly NewsContext db;

        public ContactsController()
        {
            db = new NewsContext();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Contacts contact)
        {
            await db.Contacts.AddAsync(contact);
            await db.SaveChangesAsync();
            ModelState.Clear();
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            var data = await db.Contacts.Select(n => n).ToListAsync();
            return View(data);
        }
    }
}
