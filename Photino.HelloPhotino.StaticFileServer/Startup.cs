﻿
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelloPhotino.GRpc
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalgRpc", builder =>
                {
                    //for security, default to only accepting gRPC calls and only from the local machine
                    builder.WithOrigins("null", "http://localhost", "https://localhost", "http://127.0.0.1", "https://127.0.0.1")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .WithExposedHeaders("Grpc-Status", "Grpc-Message", "Grpc-Encoding", "Grpc-Accept-Encoding");
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();


            app.UseCors();

            //app.UseEndpoints(endpoints =>
            //{

            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
            //    });
            //});
        }
    }
}