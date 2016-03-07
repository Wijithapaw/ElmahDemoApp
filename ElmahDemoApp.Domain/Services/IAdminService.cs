using ElmahDemoApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmahDemoApp.Domain.Services
{
    public interface IAdminService
    {
        IEnumerable<Admin> GetAll();

        Admin Get(string id);

        Admin Create(Admin admin);

        void Update(Admin admin);
    }
}
