using System;
using EnGarde.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(EnGarde.Areas.EnGardeHostingStartup))]
namespace EnGarde.Areas
{
    public class EnGardeHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<EnGardeDbContext>(options =>
                    // options.UseSqlServer(
                    //     context.Configuration.GetConnectionString("EnGardeIdentityDbContextConnection")));
                    options.UseSqlite("Data Source=local.db"));


                services.AddDefaultIdentity<Player>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<EnGardeDbContext>();
            });
        }
    }
}