using Microsoft.EntityFrameworkCore;
using BlogWebsite.Models;

namespace BlogWebsite.Data
{
    public class WebsiteDbContext : DbContext
    {
        public DbSet<Blog> Blogs { get; set; }

        public WebsiteDbContext(DbContextOptions<WebsiteDbContext> options) : base(options)
        {

        }
    }
}