using System;
using System.Text.Json;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BlogWebsite.Models;
using BlogWebsite.Data;
using System.Linq;

namespace BlogWebsite.Controllers
{
    public class BlogsController : Controller
    {
        private readonly WebsiteDbContext _db;

        public BlogsController(WebsiteDbContext db)
        {
            _db = db;
        }

        // GET - INDEX
        public IActionResult Index()
        {
            IEnumerable<Blog> blogs = _db.Blogs;

            ViewBag.showBtns = true;

            return View(blogs);
        }

        // GET - CREATE
        public IActionResult Create()
        {
            return View();
        }

        // POST - CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Blog obj)
        {
            ActionResult result;

            if(ModelState.IsValid)
            {
                // Create Blog Object
                Blog blog = new()
                {
                    Title = obj.Title,
                    Content = obj.Content,
                    CreatedAt = DateTime.Now,
                };

                // Add Blog To DB
                _db.Blogs.Add(blog);
                _db.SaveChanges();

                // Redirect To Blogs Index
                result = RedirectToAction("Index");
            }
            else
            {
                // Show Errors
                result = View(obj);
            }
            
            return result;
        }

        // GET - DETAILS
        [Route("/Blogs/Details/{Id}")]
        public IActionResult Details(int Id)
        {
            // Get Blog
            Blog blog = _db.Blogs.Find(Id);

            return View(blog);
        }

        // GET - EDIT
        [Route("/Blogs/Edit/{Id}")]
        public IActionResult Edit(int Id)
        {
            ActionResult result;

            // Get Blog
            Blog blog = _db.Blogs.Find(Id);

            if(blog != null)
            {
                result = View(blog);
            }
            else
            {
                result = RedirectToAction("/Error/404");
            }

            return result;
        }

        // POST - EDIT
        [Route("/Blogs/Edit/{Id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Blog obj)
        {
            ActionResult result;

            if(ModelState.IsValid)
            {
                // Update Blog In DB
                _db.Blogs.Update(obj);
                _db.SaveChanges();

                result = RedirectToAction("Index");
            }
            else
            {
                result = View("Edit", obj);
            }

            return result;
        }

        // GET - DELETE
        [Route("/Blogs/Delete/{Id}")]
        public IActionResult Delete(int Id)
        {
            // Get Blog
            var blog = _db.Blogs.Where(blog => blog.Id == Id).First();

            // Delete Blog From DB
            _db.Blogs.Remove(blog);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}