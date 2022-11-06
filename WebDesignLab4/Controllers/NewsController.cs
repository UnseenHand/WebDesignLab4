using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebDesignLab4.DAL;
using WebDesignLab4.Models;

namespace WebDesignLab4.Controllers
{
    public class NewsController : Controller
    {
        private readonly NewsContext db;

        public NewsController()
        {
            db = new NewsContext();
        }

        [HttpPost]
        public async Task<IActionResult> Create(News news)
        {
            await db.News.AddAsync(news);
            await db.SaveChangesAsync();
            return View();
        }

        public IActionResult Create()
        {
            //needs better format
            return View(new News() { PostDate = DateTime.Now });
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Insert()
        {
            return View();
        }

        public IActionResult Index()
        {
            var data = db.News.Select(n => n).ToList();
            return View(data);
        }
    }
}
