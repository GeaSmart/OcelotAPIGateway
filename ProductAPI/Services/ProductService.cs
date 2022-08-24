using ProductAPI.Data;
using ProductAPI.Model;

namespace ProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext context;

        public ProductService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public Product AddProduct(Product product)
        {
            var result = context.Products.Add(product);
            context.SaveChanges();
            return result.Entity;
        }

        public bool DeleteProduct(int Id)
        {
            var filteredData = context.Products.Where(x => x.ProductId == Id).FirstOrDefault();
            var result = context.Remove(filteredData);
            context.SaveChanges();
            return result != null ? true : false;
        }

        public Product GetProductById(int id)
        {
            return context.Products.Where(x => x.ProductId == id).FirstOrDefault();
        }

        public IEnumerable<Product> GetProductList()
        {
            return context.Products.ToList();
        }

        public Product UpdateProduct(Product product)
        {
            var result = context.Products.Update(product);
            context.SaveChanges();
            return result.Entity;
        }
    }
}
