using Infra.Context;
using Microsoft.EntityFrameworkCore;
using UI.Configuration;

namespace UI
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        public IConfiguration Configuration { get; }



        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DataContext"));
            });



            services.AddControllersWithViews();
            services.AddAutoMapperConfiguration();
            services.ResolveDependencies();
            services.AddRazorPages();
            services.AddMvc();
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, DataContext dataContext)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/error.html");



            app.UseStatusCodePages();
            app.UseStaticFiles();



            app.UseRouting();



            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Projeto}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
