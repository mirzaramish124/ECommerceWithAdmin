using Dapper;
using ECommerce.Entities.Admin;
using ECommerce.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DataAccess.Repositories.Admin.IRepository
{
    public interface IColorRepository
    {
        Task<List<Color>> GetColors();
        Task<Color> GetColorById(long id);
        Task DeleteColor(long id);
        Task<(bool Success, bool IsExist)> CreateColor(Color obj);
        //Task CreateColor(Color model);
        Task<(bool Success, bool IsExist)> UpdateColor(Color obj);
        //Task<bool> UpdateColor(Color model);
    }
}
