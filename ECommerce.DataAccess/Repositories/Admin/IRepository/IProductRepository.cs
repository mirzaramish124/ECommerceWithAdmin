using ECommerce.Entities.Models;

namespace ECommerce.DataAccess.Repositories.Admin.IRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(long id);
        Task DeleteProduct(long id);
        Task<(bool Success, bool IsExist)> CreateProduct(Product model);
        Task<(bool Success, bool IsExist)> UpdateProduct(Product model);
        Task<long> GetProductCount();
        Task<List<Brand>> GetBrands();
        Task<List<Category>> GetCats();
        Task<List<Category>> GetSubCats();
        Task<List<Category>> GetSubCatsByCatId(long id);
        //Task<List<Measurment>> GetMeasurments();
        Task<List<MeasurmentType>> GetMeasurmentTypes();
    }
}
