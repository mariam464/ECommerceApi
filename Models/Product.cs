﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApi.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; } 
        public int QuantityAvaliable { get; set; }
       
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

    }
}
