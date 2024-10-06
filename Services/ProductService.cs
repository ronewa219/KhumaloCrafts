using KhumaloCrafts.Models;
using KhumaloCrafts.Web.Data.Repositories;

namespace KhumaloCrafts.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public object ImageURL { get; private set; }

        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return _productRepository.GetProductById(id);
        }

        public void AddProduct(Product product)
        {
            _productRepository.AddProduct(product);
        }

        public void UpdateProduct(Product product, object? imageUrl)
        {
            _productRepository.UpdateProduct(product, ImageURL);
        }

        public void DeleteProduct(int id)
        {
            _productRepository.DeleteProduct(id);
        }

        public override bool Equals(object? obj)
        {
            return obj is ProductService service &&
                   EqualityComparer<IProductRepository>.Default.Equals(_productRepository, service._productRepository) &&
                   EqualityComparer<object>.Default.Equals(ImageURL, service.ImageURL);
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
