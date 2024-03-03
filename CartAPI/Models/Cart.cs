﻿using System.ComponentModel.DataAnnotations;

namespace CartAPI.Models
{
    public class Cart
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity {  get; set; }
        public decimal UnitPrice {  get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Item Item { get; set; }
    }
}
