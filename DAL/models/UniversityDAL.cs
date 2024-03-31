using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DAL.models
{
    public class UniversityDAL
    {
        [Key]
        public int IdUniversity { get; set; }
        public string Name { get; set; } = "University";

        public string ImagePath { get; set; } = "assets/";
    }
}