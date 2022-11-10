using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            if (ModelState.IsValid)
            {
                await db.News.AddAsync(news);
                await db.SaveChangesAsync();
                ModelState.Clear();
            }
            return RedirectToAction("Create");
        }

        public IActionResult Create()
        {
            //needs better format
            var nowRounded = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return View(new News() { PostDate = DateTime.Parse(nowRounded) });
        }

        public async Task<IActionResult> Delete(int id)
        {
            db.News.Remove(await db.News.FindAsync(id));
            await db.SaveChangesAsync();
            return View("Index", db.News);
        }

        public async Task<IActionResult> Details(int id)
        {
            News news = await db.News.FindAsync(id);
            if (news != null)
            {
                return View(news);
            }
            return View("NewsNotFound", id);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            News news = await db.News.FindAsync(id);
            if (news != null)
            {
                return View(news);
            }
            return View("NewsNotFound", id);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(News news)
        {
            if (!ModelState.IsValid)
            {
                return View(db.News);
            }
            db.News.Attach(news);
            db.Entry(news).Property(n => n.Caption).IsModified = true;
            await db.SaveChangesAsync();
            return View("Index", db.News);
        }

        public async Task<IActionResult> Index()
        {
            var data = await db.News.Select(n => n).ToListAsync();
            return View(data);
        }
    }
}