// See https://aka.ms/new-console-template for more information


using data;
using configurations;
using parser;
using Microsoft.Extensions.Configuration;

internal class Program
{
    private static void Main(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var builder = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json", true, true)
            //    .AddJsonFile($"appsettings.{environment}.json", true, true)
            .AddEnvironmentVariables();
        var configurationRoot = builder.Build();

        var appConfig = configurationRoot.GetSection(nameof(configurations.AppConfig)).Get<AppConfig>();

        if (appConfig == null)
        {
            Console.WriteLine("Hello cannot find the AppConfig");
            return;
        }

        Console.WriteLine($"Hello, World! {appConfig.Environment.ToString()}");

        // var addressesBuilder = new ConfigurationBuilder().AddJsonFile($"addresses.json", true, true);


        PersonDataset _personDataset = new();
        _personDataset.loadChineseNamesDataset(appConfig.ChineseNamesCsv);
        _personDataset.loadIndianNamesDataset(appConfig.IndianNamesCsv);
        _personDataset.loadMalayNamesDataset(appConfig.MalayNamesCsv);
        _personDataset.combine();

        _personDataset.loadFamilyConfig(appConfig.FamilySettingsCsv);

        // Load the address
        AddressesParser parser = new();
        IEnumerable<string> address = parser.parse(appConfig.AddressesJsonFile);
    }
}