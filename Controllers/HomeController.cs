using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlogWebsite.Models;
using BlogWebsite.Data;

namespace BlogWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly WebsiteDbContext _db;

        public HomeController(WebsiteDbContext db)
        {
            _db = db;
        }

        // GET - INDEX
        public IActionResult Index()
        {
            DateTime today = DateTime.Today;

            List<Blog> sortedBlogs = _db.Blogs
                .OrderByDescending(blog => blog.CreatedAt)
                .ToList();
            
            List<Blog> recentBlogs = new List<Blog>();

            ViewBag.showBtns = false;

            if(sortedBlogs.Count > 0)
            {
                int maxCount = sortedBlogs.Count > 3 ? 3 : sortedBlogs.Count;

                for(int i = 0; i < maxCount; i++)
                {
                    recentBlogs.Add(sortedBlogs[i]);
                }
            }

            return View(recentBlogs);
        }
    }
}
