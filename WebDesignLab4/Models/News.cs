using System;

namespace WebDesignLab4.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public DateTime PostDate { get; set; }
    }
}