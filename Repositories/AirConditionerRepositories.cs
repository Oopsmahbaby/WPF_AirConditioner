using Microsoft.EntityFrameworkCore;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AirConditionerRepositories
    {
        private AirConditionerShop2024DbContext _context = new();

        public List<AirConditioner> LoadAllTable()
        {
            return _context.AirConditioners.Include(a => a.Supplier).ToList();
        }

        public void AddAC(AirConditioner airConditioner)
        {
            _context.AirConditioners.Add(airConditioner);
            _context.SaveChanges();
        }

        public AirConditioner? CheckIdExist(int id)
        {
            return _context.AirConditioners.Find(id);
        }

        public List<SupplierCompany> GetAllCompany()
        {
            return _context.SupplierCompanies.ToList();
        }

        public void Delete(AirConditioner airConditioner)
        {
            _context.AirConditioners.Remove(airConditioner);
            _context.SaveChanges();
        }
    }
}
