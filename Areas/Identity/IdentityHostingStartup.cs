using System;
using En_Garde.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(En_Garde.Areas.Identity.IdentityHostingStartup))]
namespace En_Garde.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<en_gardeIdentityDbContext>(options =>
                    // options.UseSqlServer(
                    //     context.Configuration.GetConnectionString("en_gardeIdentityDbContextConnection")));
                    options.UseSqlite("Data Source=local.db"));


                services.AddDefaultIdentity<Player>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<en_gardeIdentityDbContext>();
            });
        }
    }
}