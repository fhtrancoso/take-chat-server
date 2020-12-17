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
            // I changed this scope to Transient because the Handler that calls it is a singleton.
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            // Here we add the middleare to use WebSocket
            app.UseWebSockets();
            app.MapSockets("/ws", serviceProvider.GetService<WebSocketMessageHandler>());
            app.UseStaticFiles();
        }
    }
}
