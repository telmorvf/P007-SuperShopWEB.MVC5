﻿using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P007_SuperShopWEB.MVC5.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace P007_SuperShopWEB.MVC5.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly DataContext _context;

        public ProductRepository(DataContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable GetAllWithUser()
        {
            return _context.Products.Include(p => p.User);
        }

        public IEnumerable<SelectListItem> GetComboProducts()
        {
            var list = _context.Products.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select new product...)",
                Value = "0"
            });

            return list;
        }
    }
}
