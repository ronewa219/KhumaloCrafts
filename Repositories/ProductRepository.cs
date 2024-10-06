using KhumaloCrafts.Models;
using System.Collections.Generic;
using System.Linq;

namespace KhumaloCrafts.Web.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products;

        public ProductRepository()
        {
            // In-memory data store for simplicity
            _products = new List<Product>
            {
                new Product { Id = 1, Name = "Handcrafted Mug", Description = "Beautiful ceramic mug", Price = 20.00M, ImageUrl = "C:\\Users\\Duncan\\Documents\\kh project\\Ceramic Mugs.jpeg" },
                new Product { Id = 2, Name = "Wooden Sculpture", Description = "Intricate wooden carving", Price = 150.00M, ImageUrl = "C:\\Users\\Duncan\\Documents\\kh project\\Wooden Sculpture.jpeg" }
            };
        }

        // Fetch all products
        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        // Fetch a product by ID
        public Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        // Add a new product
        public void AddProduct(Product product)
        {
            product.Id = _products.Max(p => p.Id) + 1;  // Generate new ID
            _products.Add(product);
        }

        public void UpdateProduct(Product product, string imageURL)
        {
            // Find the existing product by ID
            var existingProduct = GetProductById(product.Id);

            // Check if the existing product was found
            if (existingProduct != null)
            {
                // Update the product properties with the provided values
                existingProduct.Name = product.Name;
                existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;

                // Use the passed imageURL; if it's null or empty, set it to the default image path
                existingProduct.ImageUrl = string.IsNullOrEmpty(imageURL)
                    ? "C:\\Users\\Duncan\\Documents\\kh project\\download.jpeg"
                    : imageURL;
            }
        }

        // Delete a product by ID
        public void DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }

        public void UpdateProduct(Product product, object imageURL)
        {
            throw new NotImplementedException();
        }
    }
}
