using Repositories;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StaffMemberService
    {
        private StaffMemberRepositories _repo = new();
        public StaffMember? CheckLogin(string email, string password)
        {
            return _repo.CheckLogin(email, password);
        }
    }
}
