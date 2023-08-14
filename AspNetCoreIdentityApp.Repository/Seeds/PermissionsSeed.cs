using AspNetCoreIdentityApp.Web.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AspNetCoreIdentityApp.Web.Seeds
{
    public class PermissionsSeed //Bu oluşturulan Permissions role model bazlı yetkilendirmedir.
    {
        public static async Task Seed(RoleManager<AppRole> roleManager)
        {
            var hasBasicRole = await roleManager.RoleExistsAsync("BasicRole");
            var hasAdvanceRole = await roleManager.RoleExistsAsync("AdvanceRole");
            var hasAdminRole = await roleManager.RoleExistsAsync("AdminRole");

            if(!hasBasicRole)
            {
                await roleManager.CreateAsync(new AppRole() { Name = "BasicRole" });

                var basicRole = (await roleManager.FindByNameAsync("BasicRole"))!;

                await AddReadPermissions(basicRole, roleManager);
            }

            if (!hasAdvanceRole)
            {
                await roleManager.CreateAsync(new AppRole() { Name = "AdvanceRole" });

                var basicRole = (await roleManager.FindByNameAsync("AdvanceRole"))!;

                await AddReadPermissions(basicRole, roleManager);
                await AddUpdateAndCreatePermissions(basicRole, roleManager);
            }
            if (!hasAdminRole)
            {
                await roleManager.CreateAsync(new AppRole() { Name = "AdminRole" });

                var basicRole = (await roleManager.FindByNameAsync("AdminRole"))!;

                await AddReadPermissions(basicRole, roleManager);
                await AddUpdateAndCreatePermissions(basicRole, roleManager);
                await AddDeletePermissions(basicRole, roleManager);
            }


        }
        public static async Task AddReadPermissions(AppRole role,RoleManager<AppRole> roleManager)
        {
            await roleManager.AddClaimAsync(role, new Claim("Permissions", Repository.PermissionsRoot.Permissions.Stock.Read));
            await roleManager.AddClaimAsync(role, new Claim("Permissions", Repository.PermissionsRoot.Permissions.Order.Read));
            await roleManager.AddClaimAsync(role, new Claim("Permissions", Repository.PermissionsRoot.Permissions.Catalog.Read));
        }
        public static async Task AddUpdateAndCreatePermissions(AppRole role, RoleManager<AppRole> roleManager)
        {
            await roleManager.AddClaimAsync(role, new Claim("Permissions", Repository.PermissionsRoot.Permissions.Stock.Update));
            await roleManager.AddClaimAsync(role, new Claim("Permissions", Repository.PermissionsRoot.Permissions.Order.Update));
            await roleManager.AddClaimAsync(role, new Claim("Permissions", Repository.PermissionsRoot.Permissions.Catalog.Update));

            await roleManager.AddClaimAsync(role, new Claim("Permissions", Repository.PermissionsRoot.Permissions.Stock.Create));
            await roleManager.AddClaimAsync(role, new Claim("Permissions", Repository.PermissionsRoot.Permissions.Order.Create));
            await roleManager.AddClaimAsync(role, new Claim("Permissions", Repository.PermissionsRoot.Permissions.Catalog.Create));

        }
        public static async Task AddDeletePermissions(AppRole role, RoleManager<AppRole> roleManager)
        {
            await roleManager.AddClaimAsync(role, new Claim("Permissions", Repository.PermissionsRoot.Permissions.Stock.Delete));
            await roleManager.AddClaimAsync(role, new Claim("Permissions", Repository.PermissionsRoot.Permissions.Order.Delete));
            await roleManager.AddClaimAsync(role, new Claim("Permissions", Repository.PermissionsRoot.Permissions.Catalog.Delete));
        }
    }
}
