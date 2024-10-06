using KhumaloCrafts.Models;
using System.Collections.Generic;

namespace KhumaloCrafts.Web.Data.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAllProducts();   // Fetch all products
        Product GetProductById(int id);          // Fetch product by ID
        void AddProduct(Product product);        // Add a new product
        void UpdateProduct(Product product, string imageURL);     // Update an existing product with an imageURL
        void DeleteProduct(int id);              // Delete a product by ID
        void UpdateProduct(Product product, object imageURL);
    }
}
