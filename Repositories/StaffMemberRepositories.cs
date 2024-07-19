using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class StaffMemberRepositories
    {
        private AirConditionerShop2024DbContext _context = new();

        public StaffMember? CheckLogin(string email, string password)
        {
            return _context.StaffMembers.FirstOrDefault(a => a.EmailAddress == email && a.Password == password);
        }
    }
}
