using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repositories.Admin.IRepository;
using ECommerce.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repositories.Admin.Repository
{
    public class MeasurmentRepository : IMeasurmentRepository
    {
        private readonly DatabaseContext _db;
        public MeasurmentRepository(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<List<Measurment>> GetMeasurments()
        {
            return await _db.Measurments.ToListAsync();
        }

        public async Task<Measurment> GetMeasurmentById(long id)
        {
            return await _db.Measurments.FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<(bool Success, bool IsExist)> CreateMeasurment(Measurment model)
        {
            bool success = false;
            bool isExist = true;
            var isExistColor = await _db.Measurments.FirstOrDefaultAsync(x => x.Name.ToLower() == model.Name.ToLower());
            if (isExistColor is null)
            {
                model.Create = DateTime.Now;
                model.Modify = DateTime.Now;
                await _db.Measurments.AddAsync(model);
                await _db.SaveChangesAsync();
                success = true;
                isExist = false;
            }
            return (success, isExist);
        }

        public async Task<(bool Success, bool IsExist)> UpdateMeasurment(Measurment model)
        {
            bool success = false;
            bool isExist = true;
            var isExistColor = await _db.Measurments.FirstOrDefaultAsync(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != model.Id);
            if (isExistColor is null)
            {
                var obj = await _db.Measurments.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (obj != null)
                {
                    obj.Name = model.Name;
                    obj.Type = model.Type;
                    obj.Status = model.Status;
                    obj.Modify = DateTime.Now;
                    obj.ModifyUser = model.ModifyUser;
                    _db.Measurments.Update(obj);
                    await _db.SaveChangesAsync();
                    success = true;
                    isExist = false;
                }
            }
            return (success, isExist);
        }

        public async Task DeleteMeasurment(long id)
        {
            _db.Measurments.Remove(await _db.Measurments?.FirstOrDefaultAsync(x=>x.Id == id));
            await _db.SaveChangesAsync();
        }

        public async Task<bool> IsMeasurmentExist(string Name, long Id)
        {
            bool isMeasurExist = false;
            if (Id > 0)
            {
                var measur = await _db.Measurments.FirstOrDefaultAsync(x => x.Name.ToUpper() == Name.ToUpper() && x.Id != Id);
                if (measur != null)
                {
                    isMeasurExist = true;
                }
            }
            else
            {
                var measur = await _db.Measurments.FirstOrDefaultAsync(x => x.Name.ToUpper() == Name.ToUpper());
                if (measur != null)
                {
                    isMeasurExist = true;
                }
            }
            return isMeasurExist;
        }

    }
}
