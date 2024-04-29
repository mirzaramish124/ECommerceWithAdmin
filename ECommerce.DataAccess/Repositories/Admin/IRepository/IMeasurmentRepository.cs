using Dapper;
using ECommerce.DataAccess.UOW;
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
    public interface IMeasurmentRepository
    {
        Task<List<Measurment>> GetMeasurments();
        Task<Measurment> GetMeasurmentById(long id);
        Task DeleteMeasurment(long id);
        Task<(bool Success, bool IsExist)> CreateMeasurment(Measurment model);
        Task<(bool Success, bool IsExist)> UpdateMeasurment(Measurment model);
        Task<bool> IsMeasurmentExist(string Name, long Id);
    }
}
