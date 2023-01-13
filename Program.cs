// See https://aka.ms/new-console-template for more information


using data;
using configurations;
using parser;
using Microsoft.Extensions.Configuration;


internal class Program
{

    public static readonly string ADDRESSES_CSV_FULLPATH_FILE = @"./config/addresses-generated.csv";
    public static readonly string PEOPLE_HUB_CSV_FULLPATH_FILE = @"./config/icsPeopleHub.csv";
    public static readonly string VEHICLE_HUB_CSV_FULLPATH_FILE = @"./config/ltaVehicleHub.csv";

    private static void Main(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var builder = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json", true, true)
            .AddEnvironmentVariables();
        var configurationRoot = builder.Build();

        var appConfig = configurationRoot.GetSection(nameof(configurations.AppConfig)).Get<AppConfig>();

        if (appConfig == null)
        {
            Console.WriteLine("Hello cannot find the AppConfig");
            return;
        }

        Console.WriteLine($"Hello, World! {appConfig.Environment.ToString()}");

        PersonDataset _personDataset = new();
        _personDataset.loadChineseNamesDataset(appConfig.ChineseNamesCsv);
        _personDataset.loadIndianNamesDataset(appConfig.IndianNamesCsv);
        _personDataset.loadMalayNamesDataset(appConfig.MalayNamesCsv);
        _personDataset.combine();

        //_personDataset.loadFamilyConfig(appConfig.FamilySettingsCsv);

        #region Loading Random Human properties such as dob, mobile, email, nric, passport
        RandHumanPropDataset randomHumanPropDs = new();
        randomHumanPropDs.load(appConfig.RandHumanPropCsv);
        #endregion

        #region Loading countries
        CountryDataset countryDs = new();
        countryDs.load(appConfig.CountriesCsv);
        #endregion

        #region Loading countries
        VehicleMakeModelDataset vehicleDs = new();
        vehicleDs.load(appConfig.VehicleMakeModelCsv);
        #endregion        

        // Load the address
        #region Loading and generating Addresses
        AddressesParser parser = new();
        try
        {
            List<AddressesParser.AddressRecord> addresses = new();
            foreach (string jsonfile in appConfig.AddressesJsonFiles)
            {
                Console.WriteLine("Processing address configuration file {0}", jsonfile);
                addresses.AddRange(parser.parse(jsonfile));
            }
            parser.generateCsv(ADDRESSES_CSV_FULLPATH_FILE, addresses);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e);
        }
        #endregion

        #region Load scenario and gen data
        ScenarioGenerator generator = new(ref randomHumanPropDs, ref parser, ref vehicleDs);
        generator.generate(appConfig.ScenarioCsv);
        #endregion
    }
}