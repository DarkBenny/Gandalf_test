using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gandalf.Backend;
using Gandalf.Admin.Models;
using Gandalf.Backend.Models;
using Gandalf.Backend.Services;
using Microsoft.CodeAnalysis.CSharp.Syntax;


namespace Gandalf.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductService productService;
        private readonly CategoryService categoryService;

        //private int productId = 0;

        public ProductsController(ProductService productService, CategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService=categoryService;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(productService.GetProducts());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = productService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            
            ViewBag.Categories = categoryService.GetCategories();
            
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CategoryId,Description,ImageLink")] Product product)
        {     
            
            //product.Category = category;
            if (ModelState.IsValid)
            {
                productService.CreateProduct(product);

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Categories = categoryService.GetCategories();

            if (id == null)
            {
                return NotFound();
            }

            var product = productService.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CategoryId,Description,ImageLink")] Product product)
        {

            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                productService.Update(product);

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var product = productService.DeleteProduct(id);

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = productService.DeleteProduct(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
