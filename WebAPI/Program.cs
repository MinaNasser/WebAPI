
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Services;
using WebAPI.Data;
using WebAPI.Models;
using WebAPI.Repository;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ITIContext>(options =>
            {
                options.UseLazyLoadingProxies()
                       .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddTransient<EmailService>();



            builder.Services.AddIdentity<AppUser, IdentityRole>()
                            .AddEntityFrameworkStores<ITIContext>()
                            .AddDefaultTokenProviders();
            //builder.Services.AddControllers()
            //    .AddJsonOptions(options =>
            //    {
            //        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
            //        options.JsonSerializerOptions.WriteIndented = true;
            //    });
            builder.Services.AddHangfire(
                h => h.UseSqlServerStorage(
                    builder.Configuration.GetConnectionString("DefaultConnection"),
                    new Hangfire.SqlServer.SqlServerStorageOptions
                    {
                        QueuePollInterval = TimeSpan.FromSeconds(15),
                        CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                        SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    }
                    )
                );
            builder.Services.AddHangfireServer();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseHangfireDashboard("/hangfire", new DashboardOptions
            //{
            //    Authorization = new[] { new MyAuthorizationFilter() }
            //});

            app.UseHangfireDashboard("/hangfire");
            BackgroundJob.Enqueue<EmailService>(service => service.SendEmail("minanasser82018@gmail.com"));
            app.MapGet("/", (EmailService emailService) =>
            {
                BackgroundJob.Enqueue<EmailService>(service => service.SendEmail("example@example.com"));
                return "Email job enqueued!";
            });


            BackgroundJob.Schedule(
                () => Console.WriteLine("HangFire Schedule BackgroundJob  "),
                TimeSpan.FromSeconds(40)
                );


            RecurringJob.AddOrUpdate(
                recurringJobId: "WriteConsoleJob", // ID ÝÑíÏ áßá æÙíÝÉ
                methodCall: () => Console.WriteLine($"HangFire Schedule BackgroundJob at {DateTime.Now}"),
                cronExpression: Cron.Minutely,
                options: new RecurringJobOptions
                {
                    TimeZone = TimeZoneInfo.Local
                });

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}


///Get-InstalledPackage -Web  WebAPI
