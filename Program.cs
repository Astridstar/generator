// See https://aka.ms/new-console-template for more information


using data;
using parser;
using Microsoft.Extensions.Configuration;


internal class Program
{

    public static readonly string ADDRESSES_CSV_FULLPATH_FILE = @"./config/generated/addresses-generated.csv";
    public static readonly string PEOPLE_HUB_CSV_FULLPATH_FILE = @"./config/generated/icsPeopleHub.csv";
    public static readonly string VEHICLE_HUB_CSV_FULLPATH_FILE = @"./config/generated/ltaVehicleHub.csv";
    public static readonly string VAP_PERSON_ATTRIBUTE_EVENT_CSV_FULLPATH_FILE = @"./config/generated/tbl_person_attribute_event.csv";
    public static readonly string VAP_VEHICLE_ATTRIBUTE_EVENT_CSV_FULLPATH_FILE = @"./config/generated/tbl_vehicle_attribute_event.csv";
    public static readonly string VAP_FR_EVENT_CSV_FULLPATH_FILE = @"./config/generated/fr_event.csv";
    public static readonly string VAP_FR_ALERT_CSV_FULLPATH_FILE = @"./config/generated/fr_alert.csv";
    public static readonly string ACRA_CSV_FULLPATH_FILE = @"./config/generated/acra.csv";
    public static readonly string EMPLOYER_CSV_FULLPATH_FILE = @"./config/generated/mom_employer.csv";

    private static void Main(string[] args)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var builder = new ConfigurationBuilder()
            .AddJsonFile($"appsettings.json", true, true)
            .AddEnvironmentVariables();
        var configurationRoot = builder.Build();

        var appConfig = configurationRoot.GetSection(nameof(AppConfig)).Get<AppConfig>();
        var vapConfig = configurationRoot.GetSection(nameof(VapConfig)).Get<VapConfig>();

        if (appConfig == null || vapConfig == null)
        {
            Console.WriteLine("Unable to proceed. Unable to get AppConfig or VapConfig!!!");
            return;
        }

        Console.WriteLine($"Hello, World! {appConfig.Environment.ToString()}");

        PersonNamesDataset _personDataset = new();
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

        #region Loading Vehicle Make & Model list
        VehicleMakeModelDataset vehicleDs = new();
        vehicleDs.load(appConfig.VehicleMakeModelCsv);
        #endregion        

        #region Loading Acra information
        ArcaDataset arcaDs = new();
        arcaDs.load(appConfig.AcraDataCsv);
        #endregion    

        // Load the address
        #region Loading and generating Addresses
        AddressesParser parser = new();
        try
        {
            List<AddressesParser.AddressRecord> addresses = new();
            foreach (string jsonfile in appConfig.AddressesJsonFiles)
            {
                //Console.WriteLine("Processing address configuration file {0}", jsonfile);
                addresses.AddRange(parser.parse(jsonfile));
            }
            parser.generateCsv(ADDRESSES_CSV_FULLPATH_FILE, addresses);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine(e);
        }
        #endregion

        DateTimeOffset dto = vapConfig.getScenarioOccuranceDateTime();

        #region Load scenario and gen data
        ScenarioGenerator generator = new(ref appConfig,
                                            ref vapConfig,
                                            ref randomHumanPropDs,
                                            ref parser,
                                            ref vehicleDs,
                                            ref countryDs,
                                            ref _personDataset);
        generator.generate(appConfig.ScenarioCsv, appConfig.ScenarioVehicleCsv);
        #endregion
        Console.WriteLine("WE ARE DONE HERE !!!! Goodbye");

    }
}