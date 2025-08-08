﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceApi.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public string UserId { get; set; } 
        public ApplicationUser User { get; set; }

        public ICollection<CartItem> Items { get; set; }
    }


}
