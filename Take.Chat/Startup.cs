using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Take.Chat.Business;
using Take.Chat.Business.Contract;
using Take.Chat.Repository;
using Take.Chat.Repository.Contract;
using Take.Chat.TakeWebSocket;

namespace Take.Chat
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddTransient<IMessageManager, MessageManager>();
            services.AddScoped<IUserManager, UserManager>();
            // included this clas just to simulate a database
            services.AddSingleton<IMessageRepository, MessageRepository>();
            services.AddSingleton<IUserRepository, UserRepository>();

            services.AddWebSocketManager();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseWebSockets();
            app.MapSockets("/ws", serviceProvider.GetService<WebSocketMessageHandler>());
            app.UseStaticFiles();
        }
    }
}
