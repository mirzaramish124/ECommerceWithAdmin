using ECommerce.Entities.Models;

namespace ECommerce.DataAccess.Repositories.Admin.IRepository
{
    public interface IStockRepository
    {
        Task<List<Stock>> GetStock(long UserId);
        Task SaveStockBulk(IEnumerable<Stock> model);
        Task<bool> UpdateStockBulk(IEnumerable<Stock_Temp> model);
        Task DeleteStock(Stock model);
        Task<List<Stock_Temp>> GetTempStock(long UserId);
        Task<string> SaveTempStock(Stock_Temp model);
        Task<bool> UpdateTempStock(Stock_Temp model);
        Task DeleteTempStock(Stock_Temp model);
        Task<List<Product>> GetProducts();
    }
}
