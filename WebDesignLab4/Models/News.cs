using System;
using System.ComponentModel.DataAnnotations;

namespace WebDesignLab4.Models
{
    public class News
    {
        public int Id { get; set; }

        [Required]
        public string Caption { get; set; }

        [Required]
        public string Description { get; set; }
        public DateTime PostDate { get; set; }
    }
}