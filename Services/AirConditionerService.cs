using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class AirConditionerService
    {
        private AirConditionerRepositories _repo = new();

        public List<AirConditioner> LoadAllTable()
        {
            return _repo.LoadAllTable();
        }

        public void AddAC(AirConditioner airConditioner)
        {
            _repo.AddAC(airConditioner);
        }

        public AirConditioner? CheckIdExist(int id)
        {
            return _repo.CheckIdExist(id);
        }
        public List<SupplierCompany> GetAllCompany()
        {
            return _repo.GetAllCompany();
        }

        public void Delete(AirConditioner airConditioner)
        {
            _repo.Delete(airConditioner);
        }
    }
}
