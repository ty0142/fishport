using FishPort.Data;
using FishPort.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FishPort
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()// 役割管理を追加
                //.AddErrorDescriber<JapaneseIdentityErrorDescriber>() // 日本語のエラーメッセージを使用
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();
            app.MapRazorPages()
               .WithStaticAssets();


            //データ挿入用のスコープ
            //using (var scope = app.Services.CreateScope())
            //{
            //    var provider = scope.ServiceProvider;
            //    //
            //    var context = provider.GetRequiredService<ApplicationDbContext>();
            //    //Seeder.Initialize(context);
            //    //Prefectureの初期情報を投入
            //    Prefecture.Initialize(context);
            //    //Areaの初期情報を投入
            //    Area.Initialize(context);
            //}

            //データ挿入用のスコープ
            using (var scope = app.Services.CreateScope())
            {
                var provider = scope.ServiceProvider;

                var context = provider.GetRequiredService<ApplicationDbContext>();
                var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();

                //Prefectureの初期情報を投入
                Prefecture.Initialize(context);
                //Areaの初期情報を投入
                Area.Initialize(context);

                Seeder.Initialize(roleManager).GetAwaiter().GetResult();
            }
            app.Run();
        }
    }
}
