using Autofac;
using Autofac.Extensions.DependencyInjection;
using UserApi.DataStore;
using UserApi.Mapper;
using UserApi.Services;

internal class Program
{
    public static WebApplication BuildWebApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(typeof(UserProfile));

        var config = new ConfigurationBuilder();
        config.AddJsonFile("appsettings.json");
        var cfg = config.Build();
        //builder.Configuration.GetConnectionString("db");
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(cb =>
        {
            cb.RegisterType<UserService>().As<IUserService>();
            cb.Register(c => new AppDbContext(cfg.GetConnectionString("db"))).InstancePerDependency();
        });


        return builder.Build();
    }
    private static void Main(string[] args)
    {
        var app = BuildWebApp(args);

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        app.Run();
    }
}