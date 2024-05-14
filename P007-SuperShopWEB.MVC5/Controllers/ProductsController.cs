using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P007_SuperShopWEB.MVC5.Data.Entities;
using P007_SuperShopWEB.MVC5.Data.Repositories;
using P007_SuperShopWEB.MVC5.Helpers;
using P007_SuperShopWEB.MVC5.Models;

namespace P007_SuperShopWEB.MVC5.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserHelper _userHelper;
        private readonly IImageHelper _imageHelper;
        private readonly IConverterHelper _converterHelper;

        // 1 Constructor
        public ProductsController(
            IProductRepository productRepository,
            IUserHelper userHelper,
            IImageHelper imageHelper,
            IConverterHelper converterHelper)
        {
            _productRepository = productRepository;
            _userHelper = userHelper;
            _imageHelper = imageHelper;
            _converterHelper = converterHelper;
        }

        // GET: Products, ordered by name
        public IActionResult Index()
        {
            return View(_productRepository.GetAll().OrderBy(p => p.Name));
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                var path = string.Empty;
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    path = await _imageHelper.UploadImageAsync(model.ImageFile, "products");
                }

                //var product = this.ToProduct(model, path);
                var product = _converterHelper.ToProduct(model, path, true);

                // TODO Modificar para o user que estiver logado
                product.User = await _userHelper.GetUserByEmailAsync("telmorf@yopmail.com");
                await _productRepository.CreateAsync(product);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        //private Product ToProduct(ProductViewModel model, string path)
        //{
        //    return new Product
        //    {
        //        Id = model.Id,
        //        ImageUrl = path,
        //        IsAvailable = model.IsAvailable,
        //        LastPurchase = model.LastPurchase,
        //        LastSale = model.LastSale,
        //        Name = model.Name,
        //        Price = model.Price,
        //        Stock = model.Stock,
        //        User = model.User
        //    };
        //}

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }
            
            //var model = this.ToProductViewModel(product);
            var model = _converterHelper.ToProductViewModel(product);

            return View(model);
        }

        //private ProductViewModel ToProductViewModel(Product product)
        //{
        //    return new ProductViewModel
        //    {
        //        Id = product.Id,
        //        IsAvailable = product.IsAvailable,
        //        LastPurchase = product.LastPurchase,
        //        LastSale = product.LastSale,
        //        ImageUrl= product.ImageUrl,
        //        Name = product.Name,
        //        Price = product.Price,
        //        Stock = product.Stock,
        //        User = product.User
        //    };
        //}

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var path = model.ImageUrl;                   
                    
                    if(model.ImageFile != null  && model.ImageFile.Length > 0)
                    {
                        path = await _imageHelper.UploadImageAsync(model.ImageFile, "products");
                    }

                    //var product = this.ToProduct(model, path);
                    var product = _converterHelper.ToProduct(model, path, false);

                    // TODO Modificar para o user que estiver logado
                    product.User = await _userHelper.GetUserByEmailAsync("telmorf@yopmail.com");
                    await _productRepository.UpdateAsync(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await _productRepository.ExistAsync(model.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetByIdAsync(id.Value);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            await _productRepository.DeleteAsync(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
