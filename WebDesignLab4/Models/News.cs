using System;
using System.ComponentModel.DataAnnotations;

namespace WebDesignLab4.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter caption")]
        public string Caption { get; set; }

        [Required(ErrorMessage = "Please provide at least some description")]
        public string Description { get; set; }
        public DateTime PostDate { get; set; }
    }
}