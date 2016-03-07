using ElmahDemoApp.Domain;
using ElmahDemoApp.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmahDemoApp.Test.Mocks
{
    public class MockDataContext : IDataContext
    {
        public Mock<DbSet<User>> MockUsers = new Mock<DbSet<User>>();
        public Mock<DbSet<Admin>> MockAdmins = new Mock<DbSet<Admin>>();

        public IDbSet<User> Users { get { return MockUsers.Object; } set { } }
        public IDbSet<Admin> Admins { get { return MockAdmins.Object; } set { } }

        public int SaveChanges() { return 0; }
    }
}
