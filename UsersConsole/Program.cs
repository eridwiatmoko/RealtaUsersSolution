using Microsoft.Extensions.Configuration;
using System;
using VBUsersDbLib;
using VBUsersDbLib.VbUsersDbLib;

namespace UsersConsole // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        private static IConfigurationRoot? Configuration;
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            
            BuildConfig();
            IUsersDbLib _usersDbLib = new UsersDbLib(Configuration?.GetConnectionString("HotelRealtaDS"));

            //find all user
            //var listUsers = _usersDbLib.RepositoryManager.Users.FindAllUser();

            //foreach (var item in listUsers)
            //{
            //    Console.WriteLine($"{item}");
            //}

            //find user by id
            var userById = _usersDbLib.RepositoryManager.Users.FindUserById(19);
            Console.WriteLine($"Found user : {userById}");

            //update region by id
            //var updateRegion = _usersDbLib.RepositoryManager.Users.UpdateUserById(19, "Yudi", "T", "Example Inc", "dwi@example.com", "321-456-4321", true);
            //var userUpdateResult = _usersDbLib.RepositoryManager.Users.FindUserById(19);
            //Console.WriteLine($"{userUpdateResult}");


            //create user
            //var newUser = _usersDbLib.RepositoryManager.Users.CreateUser(new VBUsersDbLib.Model.Users
            //{

            //    UserFullName = "Yadi",
            //    UserType = "I",
            //    UserCompanyName = "Example Co",
            //    UserEmail = "yadi@example.com",
            //    UserPhoneNumber = "123-412-8736",
            //    UserModifiedDate = DateTime.Now
            //});
            //Console.WriteLine($"New User : {newUser}");

            //delete user
            //var rowDelete = _usersDbLib.RepositoryManager.Users.DeleteUser(19);
            //Console.WriteLine($"Delete user row : {rowDelete}");
        }

        static void BuildConfig()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();

            Console.WriteLine(Configuration.GetConnectionString("HotelRealtaDS"));
        }
    }
}