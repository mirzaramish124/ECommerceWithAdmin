using ECommerce.DataAccess.Data;
using ECommerce.DataAccess.Repositories.Admin.IRepository;
using ECommerce.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repositories.Admin.Repository
{
    public class ColorRepository : IColorRepository
    {
        private readonly DatabaseContext _db;
        public ColorRepository(DatabaseContext db)
        {
            _db = db;
        }
        public async Task<List<Color>> GetColors()
        {
            return await _db.Colors.ToListAsync();
        }

        public async Task<Color> GetColorById(long id)
        {
            return await _db.Colors.FirstOrDefaultAsync(x => x.Id == id);
        }


        public async Task<(bool Success, bool IsExist)> CreateColor(Color model)
        {
            bool success = false;
            bool isExist = true;
            var isExistColor = await _db.Colors.FirstOrDefaultAsync(x => x.Name.ToLower() == model.Name.ToLower());
            if (isExistColor is null)
            {
                model.Create = DateTime.Now;
                model.Modify = DateTime.Now;
                await _db.Colors.AddAsync(model);
                await _db.SaveChangesAsync();
                success = true;
                isExist = false;
            }
            return (success, isExist);
        }
        
        public async Task<(bool Success, bool IsExist)> UpdateColor(Color model)
        {

            bool success = false;
            bool isExist = true;
            var isExistColor = await _db.Colors.FirstOrDefaultAsync(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != model.Id);
            if (isExistColor is null)
            {
                var color = await _db.Colors.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (color != null)
                {
                    color.Name = model.Name;
                    color.ColorCode = model.ColorCode;
                    color.Status = model.Status;
                    color.Create = DateTime.Now;
                    color.Modify = DateTime.Now;
                    color.CreateUser = model.CreateUser;
                    color.ModifyUser = model.ModifyUser;
                    _db.Colors.Update(color);
                    await _db.SaveChangesAsync();
                    success = true;
                    isExist = false;
                }
            }

            return (success, isExist);

        }


        public async Task DeleteColor(long id)
        {
            _db.Colors.Remove(await _db.Colors?.FirstOrDefaultAsync(x => x.Id == id));
            await _db.SaveChangesAsync();
        }
    }
}
