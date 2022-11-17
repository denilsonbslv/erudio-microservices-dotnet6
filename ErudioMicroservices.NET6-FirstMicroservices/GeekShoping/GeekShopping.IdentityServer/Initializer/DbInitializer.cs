using GeekShopping.IdentityServer.Configuration;
using GeekShopping.IdentityServer.Model.Context;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace GeekShopping.IdentityServer.Initializer
{
    public class DbInitializer : IDbInitializer
    {
        private readonly MySQLContext _context;
        private readonly UserManager<ApplicationUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DbInitializer(MySQLContext context, UserManager<ApplicationUser> user, RoleManager<IdentityRole> role)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _user = user ?? throw new ArgumentNullException(nameof(user));
            _role = role ?? throw new ArgumentNullException(nameof(role));
        }

        public void Initialize()
        {
            if (_role.FindByNameAsync(IdentityConfiguration.Admin).Result != null) return;
            {
                _role.CreateAsync(new IdentityRole(
                    IdentityConfiguration.Admin)).GetAwaiter().GetResult();

                _role.CreateAsync(new IdentityRole(
                    IdentityConfiguration.Client)).GetAwaiter().GetResult();

                ApplicationUser admin = new ApplicationUser()
                {
                    UserName = "denilson-admin",
                    Email = "denilson-admin@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "+55 (84) 12345-1234",
                    FirstName = "Denilson",
                    LastName = "Admin"
                };

                _user.CreateAsync(admin, "d9z1199N@").GetAwaiter().GetResult();
                _user.AddToRoleAsync(admin, IdentityConfiguration.Admin).GetAwaiter().GetResult();

                var adminClaims = _user.AddClaimsAsync(admin, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, $"{admin.FirstName} {admin.LastName}"),
                    new Claim(JwtClaimTypes.GivenName, admin.FirstName),
                    new Claim(JwtClaimTypes.FamilyName, admin.LastName),
                    new Claim(JwtClaimTypes.Role, IdentityConfiguration.Admin),
                }).Result;
            
                ApplicationUser client = new ApplicationUser()
                {
                    UserName = "denilson-client",
                    Email = "denilson-client@gmail.com",
                    EmailConfirmed = true,
                    PhoneNumber = "+55 (84) 12345-1234",
                    FirstName = "Denilson",
                    LastName = "Client"
                };

                _user.CreateAsync(client, "d9z1199N@").GetAwaiter().GetResult();
                _user.AddToRoleAsync(client, IdentityConfiguration.Client).GetAwaiter().GetResult();

                var clientClaims = _user.AddClaimsAsync(client, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, $"{client.FirstName} {client.LastName}"),
                    new Claim(JwtClaimTypes.GivenName, client.FirstName),
                    new Claim(JwtClaimTypes.FamilyName, client.LastName),
                    new Claim(JwtClaimTypes.Role, IdentityConfiguration.Client),
                }).Result;
            }
        }
    }
}
