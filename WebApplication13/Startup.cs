using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace WebApplication13
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
            services.AddControllers();

            //ע��Swagger������������һ���Ͷ��Swagger �ĵ�
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "����API",
                    Version = "v1",
                    Description = "����һ��swagger��������",
                   
                    //TermsOfService = "None",
                    Contact = new OpenApiContact
                    {
                        Name = "lc",
                        Email = string.Empty,
                        Url = new Uri("http://www.cnblogs.com/yilezhu/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "���֤����",
                        Url = new Uri("http://www.cnblogs.com/yilezhu/")
                    }
                });
                
                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Title = "����API",
                    Version = "v2",
                    Description = "����һ��swagger��������",
                   
                    //TermsOfService = "None",
                    Contact = new OpenApiContact
                    {
                        Name = "lc",
                        Email = string.Empty,
                        Url = new Uri("http://www.cnblogs.com/yilezhu/")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "���֤����",
                        Url = new Uri("http://www.cnblogs.com/yilezhu/")
                    }
                });

                // Ϊ Swagger JSON and UI����xml�ĵ�ע��·��
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//��ȡӦ�ó�������Ŀ¼�����ԣ����ܹ���Ŀ¼Ӱ�죬������ô˷�����ȡ·����
                var xmlPath = Path.Combine(basePath, "SwaggerDemo.xml");
                c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            //�����м����������Swagger��ΪJSON�ս��
            app.UseSwagger();
            //�����м�������swagger-ui��ָ��Swagger JSON�ս��
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "My API V2");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
