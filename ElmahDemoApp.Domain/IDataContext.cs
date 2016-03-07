using ElmahDemoApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmahDemoApp.Domain
{
    public interface IDataContext
    {
        IDbSet<User> Users { get; set; }

        IDbSet<Admin> Admins { get; set; }

        int SaveChanges();
    }
}
