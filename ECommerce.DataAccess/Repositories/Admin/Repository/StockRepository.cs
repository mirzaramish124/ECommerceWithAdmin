using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repositories.Admin.IRepository;
using ECommerce.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repositories.Admin.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly DatabaseContext _db;
        public StockRepository(DatabaseContext db)
        {
            _db = db;
        }

        public async Task<List<Stock>> GetStock(long UserId)
        {
            return await _db.Stock.ToListAsync();
        }

        public async Task SaveStockBulk(IEnumerable<Stock> model)
        {
            foreach (var item in model)
            {
                await _db.Stock.AddAsync(item);
                await _db.SaveChangesAsync();
            }
        }

        public async Task<bool> UpdateStockBulk(IEnumerable<Stock_Temp> model)
        {
            bool hasSuccess = false;
            foreach (var item in model)
            {
                var tempStock = _db.Stock.FirstOrDefault(x => x.Id == item.StockId);
                if (tempStock != null)
                {
                    tempStock.ProductId = item.ProductId;
                    tempStock.MeasurmentTypeId = item.MeasurmentTypeId;
                    tempStock.MeasurmentId = item.MeasurmentId;
                    tempStock.ColorId = item.ColorId;
                    tempStock.PurchasePrice = item.PurchasePrice;
                    tempStock.SalePrice = item.SalePrice;
                    tempStock.Qty = item.Qty;
                    tempStock.Status = item.Status;
                    _db.Update(tempStock);
                    await _db.SaveChangesAsync();

                    hasSuccess = true;
                }
            }
            
            return hasSuccess;
        }

        public async Task DeleteStock(Stock model)
        {
            _db.Stock.RemoveRange(await _db.Stock.FirstOrDefaultAsync(x => x.Id == model.Id));
            await _db.SaveChangesAsync();
        }

        public async Task<List<Stock_Temp>> GetTempStock(long UserId)
        {
            return await _db.Stock_Temp.Where(x => x.UserId == UserId).Include(x=>x.Product).Include(x=>x.MeasurmentType).Include(x=>x.Measurment).Include(x=>x.Color).ToListAsync();
        }

        public async Task<string> SaveTempStock(Stock_Temp model)
        {
            string message = "";
            if (model is { MeasurmentTypeId: 1 })
            //if (model.MeasurmentTypeId == 0)
            {
                var stockExist = await _db.Stock.FirstOrDefaultAsync(x => x.ProductId == model.ProductId && x.MeasurmentId == model.MeasurmentId);
                if (stockExist != null)
                {
                    message = "This product is already exist";
                    return message;
                }
                else
                {
                    await _db.Stock_Temp.AddAsync(model);
                    await _db.SaveChangesAsync();
                }
            }
            else if (model is { MeasurmentTypeId: 1, ColorId: > 0 })
            //else if (model is { MeasurmentTypeId: 1 })
            //else if (model.MeasurmentTypeId == 1)
            {
                var stockExist = await _db.Stock.FirstOrDefaultAsync(x => x.ProductId == model.ProductId && x.ColorId == model.ColorId);
                if (stockExist == null)
                {
                    stockExist = await _db.Stock.FirstOrDefaultAsync(x => x.ProductId == model.ProductId && x.MeasurmentId == model.MeasurmentId);
                    if (stockExist == null)
                    {
                        stockExist = await _db.Stock.FirstOrDefaultAsync(x => x.ProductId == model.ProductId && x.MeasurmentId == model.MeasurmentId && x.ColorId == model.ColorId);
                    }
                }
                if (stockExist != null)
                {
                    //stockExist.ProductId = model.ProductId;
                    //stockExist.MeasurmentTypeId = model.MeasurmentTypeId;
                    //stockExist.MeasurmentId = model.MeasurmentId;
                    //stockExist.ColorId = model.ColorId;
                    //stockExist.PurchasePrice = model.PurchasePrice;
                    //stockExist.SalePrice = model.SalePrice;
                    //stockExist.Qty = model.Qty;
                    //stockExist.Status = model.Status;
                    //stockExist.UserId = model.UserId;
                    message = "This product is already exist";
                    return message;
                }
                else
                {
                    await _db.Stock_Temp.AddAsync(model);
                    await _db.SaveChangesAsync();
                }
            }
            await _db.Stock_Temp.AddAsync(model);
            await _db.SaveChangesAsync();
            return message;
        }

        public async Task<bool> UpdateTempStock(Stock_Temp model)
        {
            bool hasSuccess = false;
            var tempStock = _db.Stock_Temp.FirstOrDefault(x => x.Id == model.Id && x.UserId == model.UserId);
            if (tempStock != null)
            {
                tempStock.ProductId = model.ProductId;
                tempStock.MeasurmentTypeId = model.MeasurmentTypeId;
                tempStock.MeasurmentId = model.MeasurmentId;
                tempStock.ColorId = model.ColorId;
                tempStock.PurchasePrice = model.PurchasePrice;
                tempStock.SalePrice = model.SalePrice;
                tempStock.Qty = model.Qty;
                tempStock.Status = model.Status;
                _db.Update(tempStock);
                await _db.SaveChangesAsync();
                hasSuccess = true;
            }
            return hasSuccess;
        }

        public async Task DeleteTempStock(Stock_Temp model)
        {
            _db.Stock_Temp.RemoveRange(await _db.Stock_Temp?.FirstOrDefaultAsync(x => x.Id == model.Id && x.UserId == model.UserId));
            await _db.SaveChangesAsync();
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _db.Products.Where(x => x.Status == "0").Select(x => new Product()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
        }
    }
}
