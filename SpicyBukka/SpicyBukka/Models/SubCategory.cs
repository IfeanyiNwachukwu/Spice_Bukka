﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpicyBukka.Models
{
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "SubCategory Name")]
        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
