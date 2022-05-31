using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace BlogWebsite.Models
{
    public class Blog
    {
        [Key]
        [BindProperty]
        public int Id { get; set; }

        [Required]
        [BindProperty]
        public string Title { get; set; }

        [Required]
        [BindProperty]
        [DisplayName("Blog Content")]
        public string Content { get; set; }

        [Column(TypeName = "date")]
        [BindProperty]
        public DateTime CreatedAt { get; set; }
    }
}