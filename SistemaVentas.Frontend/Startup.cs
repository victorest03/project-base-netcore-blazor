
namespace SistemaVentas.Frontend
{
    using Helper;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Components.Authorization;
    using Microsoft.AspNetCore.Components.Server;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Model.Auth;
    using NetCore.AutoRegisterDi;
    using Persistence;
    using Persistence.Helpers;
    using Services;
    using Services.Auth;
    using System.Reflection;
    using UnitOfWork;
    using UnitOfWork.Interfaces;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var assemblyName = typeof(ApplicationDbContext).Namespace;

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(assemblyName)));


            services
                .AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddUserManager<ApplicationUserManager>()
                .AddSignInManager<ApplicationSignInManager>()
                .AddRoleManager<ApplicationRoleManager>()
                .AddDefaultTokenProviders();
            
            
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
                options.SignIn.RequireConfirmedEmail = false;

            });


            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/SignIn";
                options.AccessDeniedPath = "/Error";
                options.SlidingExpiration = true;
                options.Cookie.HttpOnly = true;
            });


            services.AddRazorPages();
            services.AddControllers();
            services.AddServerSideBlazor();
            services.AddTransient<ApplicationUserManager>();
            services.AddTransient<ApplicationSignInManager>();
            services.AddTransient<ApplicationRoleManager>();
            services.AddTransient<IUserCurrent, UserCurrent>();
            services.AddTransient<IUnitOfWork, UnitOfWorkContainer>();

            //Implementacion de las interfaces
            var assemblyServices = Assembly.GetAssembly(typeof(RegisterAssembly));
            services.RegisterAssemblyPublicNonGenericClasses(assemblyServices)
                .Where(c => c.Name.EndsWith("Service"))
                .AsPublicImplementedInterfaces();

            services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/Shared/_Layout");
                
            });
        }
    }
}
