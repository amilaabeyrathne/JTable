using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JTable.Models
{
    public class Marks
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string RollNumber { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int MarksObtained { get; set; }
        [Required]
        public int TotalMarks { get; set; }
    }
}