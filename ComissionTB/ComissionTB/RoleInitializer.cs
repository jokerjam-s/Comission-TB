using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ComissionTB.Models;
using ComissionTB.Data;

namespace ComissionTB
{
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<AppUsers> userManager, RoleManager<AppRoles> roleManager)
        {
            var role = await roleManager.FindByNameAsync("admin");
            if (role == null)
            {
                AppRoles ar = new AppRoles { Name = "admin", Descript = "Администратор" };
                await roleManager.CreateAsync(ar);
            }

            role = await roleManager.FindByNameAsync("preds");
            if (role == null)
            {
                AppRoles ar = new AppRoles { Name = "preds", Descript = "Председатель" };
                await roleManager.CreateAsync(ar);
            }

            role = await roleManager.FindByNameAsync("secr");
            if (role == null)
            {
                AppRoles ar = new AppRoles { Name = "secr", Descript = "Секретарь" };
                await roleManager.CreateAsync(ar);
            }

            role = await roleManager.FindByNameAsync("comission");
            if (role == null)
            {
                AppRoles ar = new AppRoles { Name = "comission", Descript = "Член комиссии" };
                await roleManager.CreateAsync(ar);
            }

            role = await roleManager.FindByNameAsync("npodr");
            if (role == null)
            {
                AppRoles ar = new AppRoles { Name = "npodr", Descript = "Начальник цеха" };
                await roleManager.CreateAsync(ar);
            }

            role = await roleManager.FindByNameAsync("ordinal");
            if (role == null)
            {
                AppRoles ar = new AppRoles { Name = "ordinal", Descript = "Пользователь" };
                await roleManager.CreateAsync(ar);
            }

            string adminEmail = "admin@mail.ru";
            string password = "Qwe_123";
            var findUser = await userManager.FindByEmailAsync(adminEmail);

            if (findUser == null)
            {
                AppUsers admin = new AppUsers { 
                    Email = adminEmail, 
                    UserName = adminEmail,  
                    userFio = "Админов",
                    userFirstName = "Админ",
                    userSecName = "Админыч",
                    tabNo = 1
                };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}

