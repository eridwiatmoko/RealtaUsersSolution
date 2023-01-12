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

            //table users
            //find all user
            //var listUsers = _usersDbLib.RepositoryManager.Users.FindAllUser();

            //foreach (var item in listUsers)
            //{
            //    Console.WriteLine($"{item}");
            //}

            //find user by id
            //var userById = _usersDbLib.RepositoryManager.Users.FindUserById(15);
            //Console.WriteLine($"Found user : {userById}");

            //update user by id
            //var updateUser = _usersDbLib.RepositoryManager.Users.UpdateUserById(19, "Yudi", "T", "Example Inc", "dwi@example.com", "321-456-4321", true);
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

            //Console.WriteLine("-----------------UPDATE BY SP------------------");
            //var updateUserSp = _usersDbLib.RepositoryManager.Users.UpdateUserBySp(18, "Yudi", "T", "Example Inc", "dwi@example.com", "321-456-4321", true);
            //var UpdateResultSp = _usersDbLib.RepositoryManager.Users.FindUserById(18);
            //Console.WriteLine($"{updateUserSp}: {UpdateResultSp}");

            //Console.WriteLine("+++++++++++++++++++++++++++++++++++++FIND ALL ASYNC++++++++++++++++++++++++++++++++++++++++++");
            //var listUsersAsyn = _usersDbLib.RepositoryManager.Users.FindAllUserAsync();
            //foreach (var item in listUsersAsyn)
            //{
            //    Console.WriteLine($"{item}");
            //}

            //table usro
            //findall usro
            var listUserRoles = _usersDbLib.RepositoryManager.UserRoles.FindAllUserRole();

            foreach (var item in listUserRoles)
            {
                Console.WriteLine($"{item}");
            }

            //find usro by id
            //var userRolesById = _usersDbLib.RepositoryManager.UserRoles.FindUserRoleById(6);
            //Console.WriteLine($"Found userRole : {userRolesById}");

            //update usro by id
            //var updateUsro = _usersDbLib.RepositoryManager.UserRoles.UpdateUserRoleById(3, 5, true);
            //var usroUpdateResult = _usersDbLib.RepositoryManager.UserRoles.FindUserRoleById(3);
            //Console.WriteLine($"{usroUpdateResult}");

            //create usro
            //var newUsro = _usersDbLib.RepositoryManager.UserRoles.CreateUserRole(new VBUsersDbLib.Model.User_roles
            //{
            //    UsroUserId = 18,
            //    UsroRoleId = 3
            //});
            //Console.WriteLine($"New Usro : {newUsro}");

            //delete usro
            //var rowDelete = _usersDbLib.RepositoryManager.UserRoles.DeleteUserRole(18);
            //Console.WriteLine($"Delete user row : {rowDelete}");

            Console.WriteLine("-----------------UPDATE BY SP------------------");
            var updateUsroSp = _usersDbLib.RepositoryManager.UserRoles.UpdateUserRoleBySp(15, 3, true);
            var UpdateResultSp = _usersDbLib.RepositoryManager.UserRoles.FindUserRoleById(15);
            Console.WriteLine($"{updateUsroSp}: {UpdateResultSp}");
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