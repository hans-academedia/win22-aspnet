using _02_AspNet_WebApi.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace _02_AspNet_WebApi.Helpers.Contexts
{
    public class IdentityContext : IdentityDbContext<IdentityUserEntity>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }
    }
}
