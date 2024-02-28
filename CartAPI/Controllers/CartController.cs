﻿using CartAPI.Data;
using CartAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CartAPI.Controllers
{
    public class CartController : Controller
    {
        private readonly CartDbContext _cartDbContext;
        public CartController(CartDbContext cartDbContext)
        {
            _cartDbContext = cartDbContext;
        }

        //Add cart item
        [HttpPost]
        public async Task<IActionResult> AddCartItem(Cart cartItem)
        {
            _cartDbContext.Carts.Add(cartItem);
            await _cartDbContext.SaveChangesAsync();

            return View(cartItem);
        }

        // get cart item
        [HttpGet]
        public IActionResult GetCarItems()
        {
            var cartItems = _cartDbContext.Carts.ToList();
            return Ok(cartItems);
        }

        //get item by id
        [HttpGet("{id}")]
        public IActionResult GetItemById(int id)
        {
            var cartItem = _cartDbContext.Carts.FirstOrDefault(c => c.ItemId == id);
            if (cartItem == null)
            {
                return NotFound();
            }
            return Ok(cartItem);
        }

        //update cart item
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartItem(Cart cartItem, int id)
        {
            var existingCartItem = await _cartDbContext.Carts.FindAsync(id);
            if (existingCartItem == null)
            {
                return NotFound();
            }

            existingCartItem.ItemName = cartItem.ItemName;
            existingCartItem.Quantity = cartItem.Quantity;
            existingCartItem.UnitPrice = cartItem.UnitPrice;

            await _cartDbContext.SaveChangesAsync();
            return View(existingCartItem);
            
        }

        //delete cart item
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItem(int id)
        {
            var cartItem = await _cartDbContext.Carts.FindAsync(id);
            if (cartItem == null)
            {
                return NotFound();
            }

            _cartDbContext.Carts.Remove(cartItem);
            await _cartDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
