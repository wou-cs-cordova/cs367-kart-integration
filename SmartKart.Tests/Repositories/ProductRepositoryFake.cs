using SmartKart.Web.Models;
using SmartKart.Web.Repositories.Interfaces;

namespace SmartKart.Tests.Repositories;

internal class ProductRepositoryFake : IProductRepository
{
    public Task<IEnumerable<Product>> GetProducts()
    {
        throw new NotImplementedException();
    }

    public Task<Product?> GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetProductByName(string name)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Product>> GetProductByCategory(int categoryId)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<Category>> GetCategories()
    {
        throw new NotImplementedException();
    }
}