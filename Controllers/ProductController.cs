using KhumaloCrafts.Models;
using KhumaloCrafts.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace KhumaloCrafts.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        // Constructor with dependency injection for the ProductService
        public ProductController(ProductService productService)
        {
            _productService = productService;

            // Adding predefined products to the system (could also be handled in the service)
            if (_productService.GetAllProducts().Count() == 0)
            {
                _productService.AddProduct(new Product { Name = "Handcrafted Mug", Description = "Beautiful ceramic mug", Price = 20.00M });
                _productService.AddProduct(new Product { Name = "Wooden Sculpture", Description = "Intricate wooden carving", Price = 150.00M });
            }
        }

        // Display all products
        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products); // Pass products to the view
        }

        // GET: Show product creation form
        public IActionResult Create()
        {
            return View();
        }

        // POST: Handle product creation form submission
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.AddProduct(product); // Add product via service layer
                return RedirectToAction("Index"); // Redirect back to the list
            }
            return View(product); // Return view with validation errors
        }

        // GET: Show product editing form
        public IActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound(); // Return 404 if product is not found
            }
            return View(product);
        }

        // POST: Handle product edit form submission
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(product, product.ImageUrl); // Pass the product and updated image URL to service
                return RedirectToAction("Index");
            }
            return View(product); // Return view with validation errors
        }

        // GET: Confirm product deletion
        public IActionResult Delete(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound(); // Handle not found case
            }

            return View(product); // Show confirmation page
        }

        // POST: Handle product deletion
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _productService.DeleteProduct(id); // Delete product via service layer
            return RedirectToAction("Index");
        }

        // GET: Show product details
        public IActionResult Details(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
