using ElmahDemoApp.Domain.Entities;
using ElmahDemoApp.Services;
using ElmahDemoApp.Test.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ElmahDemoApp.Test.Services
{
    public class AdminServiceTests
    {
        public static AdminService CreateService(ICollection<Admin> data = null, MockDataContext context = null)
        {
            context = context ?? new MockDataContext();
            var service = new AdminService(context);

            context.MockAdmins.SetupData(data, ids => context.Admins.SingleOrDefault(a => a.Id == ids[0].ToString()));

            return service;
        }

        public class GetMethod
        {
            [Fact]
            public void WhenGivenValidId_ReturnUser()
            {
                var data = new List<Admin>() {
                      new Admin() { Id = "1", Email = "admin1@yopmail.com"},
                      new Admin() { Id = "2", Email = "admin2@yopmail.com"},
                      new Admin() { Id = "3", Email = "admin3@yopmail.com"},
                      new Admin() { Id = "4", Email = "admin4@yopmail.com"},
                      new Admin() { Id = "5", Email = "admin5@yopmail.com"}
                  };

                var service = CreateService(data);

                var admin = service.Get("1");
                Assert.NotNull(admin);
                Assert.Equal("admin1@yopmail.com", admin.Email);

                admin = service.Get("3");
                Assert.NotNull(admin);
                Assert.Equal("admin3@yopmail.com", admin.Email);

                admin = service.Get("4");
                Assert.NotNull(admin);
                Assert.Equal("admin4@yopmail.com", admin.Email);
            }

            [Fact]
            public void WhenGivenInValidId_ReturnNull()
            {
                var data = new List<Admin>() {
                      new Admin() { Id = "1", Email = "admin1@yopmail.com"},
                      new Admin() { Id = "2", Email = "admin2@yopmail.com"},
                      new Admin() { Id = "3", Email = "admin3@yopmail.com"},
                      new Admin() { Id = "4", Email = "admin4@yopmail.com"},
                      new Admin() { Id = "5", Email = "admin5@yopmail.com"}
                  };

                var service = CreateService(data);

                var admin = service.Get("10");
                Assert.Null(admin);
            }
        }

        public class GetAllMethod
        {
            [Fact]
            public void WhenNoUsersExists_ReturnNon()
            {
                var data = new List<Admin>();

                var service = CreateService(data);

                var admins = service.GetAll();
                Assert.Equal(0, admins.Count());
            }

            [Fact]
            public void WhenUsersExist_ReturnAllUsers()
            {
                var data = new List<Admin>() {
                      new Admin() { Id = "1", Email = "admin1@yopmail.com"},
                      new Admin() { Id = "2", Email = "admin2@yopmail.com"},
                      new Admin() { Id = "3", Email = "admin3@yopmail.com"},
                      new Admin() { Id = "4", Email = "admin4@yopmail.com"},
                      new Admin() { Id = "5", Email = "admin5@yopmail.com"}
                  };

                var service = CreateService(data);


                var admins = service.GetAll();

                Assert.Equal(5, admins.Count());
                Assert.Equal("admin4@yopmail.com", admins.First(a => a.Id == "4").Email);
            }
        }

        public class CreateMethod
        {
            [Fact]
            public void WhenNoUsersExist_UserCreateSuccessfully()
            {
                var data = new List<Admin>();

                var service = CreateService(data);

                var admin = new Admin() { Id = "1", FirstName = "Admin", LastName = "System", Email = "admin@yopmail.com" };

                var result = service.Create(admin);

                Assert.NotNull(result);
                Assert.Equal("admin@yopmail.com", result.Email);
                Assert.Equal("1", result.Id);
            }

            [Fact]
            public void WhenAdminsExists_AdminCreateSuccessfully()
            {
                var data = new List<Admin>() {
                      new Admin() { Id = "1", Email = "admin1@yopmail.com"},
                      new Admin() { Id = "2", Email = "admin2@yopmail.com"},
                      new Admin() { Id = "3", Email = "admin3@yopmail.com"},
                      new Admin() { Id = "4", Email = "admin4@yopmail.com"},
                      new Admin() { Id = "5", Email = "admin5@yopmail.com"}
                  };

                var service = CreateService(data);

                var admin = new Admin() { Id = "6", FirstName = "Admin6", LastName = "System6", Email = "admin6@yopmail.com" };

                var result = service.Create(admin);

                Assert.NotNull(result);
                Assert.Equal("admin6@yopmail.com", result.Email);
                Assert.Equal("6", result.Id);
            }
        }

        public class UpdateMethod
        {
            [Fact]
            public void WhenUserExist_UpdateSuccessfully()
            {
                var data = new List<Admin>() {
                      new Admin() { Id = "1", Email = "admin1@yopmail.com"},
                      new Admin() { Id = "2", Email = "admin2@yopmail.com"},
                      new Admin() { Id = "3", Email = "admin3@yopmail.com"},
                      new Admin() { Id = "4", Email = "admin4@yopmail.com"},
                      new Admin() { Id = "5", Email = "admin5@yopmail.com"}
                  };

                var service = CreateService(data);

                var admin = new Admin() { Id = "3", FirstName = "Admin3", LastName = "System3", Email = "admin3.new@yopmail.com" };

                service.Update(admin);

                var updatedAdmin = service.Get("3");

                Assert.NotNull(updatedAdmin);
                Assert.Equal("admin3.new@yopmail.com", updatedAdmin.Email);
                Assert.Equal("3", updatedAdmin.Id);
            }

            public void WhenUserNotExist_ThrowsException()
            {
                //TODO
            }
        }
    }
}
