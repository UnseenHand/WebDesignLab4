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
            ModelState.Clear();
            return View();
        }

        public IActionResult Create()
        {
            //needs better format
            var nowRounded = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return View(new News() { PostDate = DateTime.Parse(nowRounded) });
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult Edit()
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
