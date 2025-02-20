using System;
using ATPTournamentsTour.WebClient.Services;
using ATPTournamentsTour.WebClient.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Azure.Storage;
using Rebus.ServiceProvider;
using Rebus.Config;
using Rebus.Routing.TypeBased;
using ATPTournamentsTour.Messages;

namespace ATPTournamentsTour.WebClient
{
    public class Startup
    {
        private readonly IHostEnvironment environment;
        private readonly IConfiguration config;

        public Startup(IConfiguration configuration, IHostEnvironment environment)
        {
            config = configuration;
            this.environment = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddControllersWithViews();

            if (environment.IsDevelopment())
                builder.AddRazorRuntimeCompilation();

            services.AddHttpClient<ITournamentsListService, TournamentsListService>(c => 
                c.BaseAddress = new Uri(config["ApiConfigs:TournamentList:Uri"]));
            services.AddHttpClient<ICartService, CartService>(c =>
                c.BaseAddress = new Uri(config["ApiConfigs:Cart:Uri"]));

            services.AddSingleton<Settings>();

            var storageAccount = CloudStorageAccount.Parse(config["AzureQueues:ConnectionString"]);

            services.AddRebus(c => c
                .Transport(t => t.UseAzureStorageQueuesAsOneWayClient(storageAccount))
                .Routing(r => r.TypeBased().Map<PaymentRequestMessage>(
                    config["AzureQueues:QueueName"]))
            );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=TournamentsList}/{action=Index}/{id?}");
            });
        }
    }
}
