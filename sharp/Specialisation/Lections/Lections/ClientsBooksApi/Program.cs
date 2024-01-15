using Autofac;
using Autofac.Extensions.DependencyInjection;
using ClientsBooksApi.DataStore;
using ClientsBooksApi.Mapper;
using ClientsBooksApi.Services;

internal class Program
{
    public static WebApplication CreateWebApp(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddAutoMapper(typeof(ClientBookProfile));
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(cb =>
        {
            cb.RegisterType<ClientBookService>().As<IClientBookService>();
            cb.Register(c => new AppDbContext(builder.Configuration.GetConnectionString("db"))).InstancePerDependency();
        });

        return builder.Build();
    }
    private static void Main(string[] args)
    {
        var app = CreateWebApp(args);

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