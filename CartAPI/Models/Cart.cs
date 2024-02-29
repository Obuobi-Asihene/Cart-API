using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CartAPI.Models
{
    public class Cart
    {
        [Key]
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int Quantity {  get; set; }
        public decimal UnitPrice {  get; set; }
    }
}
