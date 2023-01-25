namespace parser;

using System.Collections;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CsvHelper;
using data;
using records;

class ScenarioGenerator
{
    Dictionary<string, PersonRecord> _peopleHub = new();
    Dictionary<string, VehicleRecord> _vehicleHub = new();
    List<ScenarioPersonRecord> _scenarioPersonRecords = new();
    List<ScenarioVehicleRecord> _scenarioVehicleRecords = new();

    IEnumerable<string>? _scenarioIdWithFamilies;

    AddressesParser _addressParser;

    RandHumanPropDataset _randHumanPropDs;
    VehicleMakeModelDataset _vehicleSrcDs;

    VapConfig _vapConfig;
    VapPersonDetectionGenerator _vapPersonDetectionGenerator;

    PersonDataGenerator _personGenerator;

    public ScenarioGenerator(ref AppConfig appConfig, ref VapConfig vapConfig,
                            ref RandHumanPropDataset randHumanPropDs,
                            ref AddressesParser parser,
                            ref VehicleMakeModelDataset vehicleSrcDs,
                            ref CountryDataset countryDs,
                            ref PersonNamesDataset personDataset)
    {
        _randHumanPropDs = randHumanPropDs;
        _addressParser = parser;
        _vehicleSrcDs = vehicleSrcDs;
        _vapConfig = vapConfig;
        _vapPersonDetectionGenerator = new();
        _personGenerator = new(_addressParser, _randHumanPropDs, countryDs, personDataset);
    }
    private void load(string peopleFileName, string vehicleFileName)
    {
        using (StreamReader reader = new StreamReader(peopleFileName))
        {
            CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            if (csv == null)
                return;

            csv.Context.RegisterClassMap<ScenarioPersonRecordDatamap>();
            _scenarioPersonRecords.AddRange(csv.GetRecords<ScenarioPersonRecord>().ToList());
        }

        using (StreamReader reader = new StreamReader(vehicleFileName))
        {
            CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            if (csv == null)
                return;

            csv.Context.RegisterClassMap<ScenarioVehicleRecordDatamap>();
            _scenarioVehicleRecords.AddRange(csv.GetRecords<ScenarioVehicleRecord>().ToList());
        }


        _vapPersonDetectionGenerator.load(ref _vapConfig);
    }

    public bool generate(string peopleFileName, string vehicleFileName)
    {
        try
        {
            load(peopleFileName, vehicleFileName);
        }
        catch (Exception e)
        {
            Console.Write(e);
            return false;
        }

        // Nothing to generate
        if (_scenarioPersonRecords.Count <= 0) return false;

        #region Generate data
        //1. Generate people_hub
        //2. Generate family
        generatePeopleInScenario();

        //3. Generate vehicle
        generateVehiclesInScenario();
        //generatePeopleVehicleRelationship();

        //4. Generate employer

        //5. Generate friendly
        generateVapFriendlies();
        generateVapUnknownFriendlies();
        generateVapFriendliesVehicle();

        //6. Generate blacklisted person
        //7. Generate blacklisted vehicle

        //8. Generate unknown friendlies
        #endregion

        generateDefaltPeopleRecords();

        // Now generate the CSV data
        generatePeopleHubCsv(); // ICA PeopleHub
        generateVehicleHubCsv(); // LTA VehicleHub
        generateVapCsv();
        return true;
    }

    private void generatePeopleInScenario()
    {
        // Create PersonRecord for each person specified in the scenario 
        foreach (ScenarioPersonRecord record in _scenarioPersonRecords)
        {
            string addr = "";
            string post = "";
            _addressParser.getNextAddress(out addr, out post);
            _peopleHub.Add(record.id,
            new PersonRecord(record, addr, post, _randHumanPropDs.getNextEmail(), "", _randHumanPropDs.getNextMobileNumber()));
        }

        if (_peopleHub.Count <= 0) return;

        // Find all the persons that have family members specified
        _scenarioIdWithFamilies = from person in _peopleHub.Values
                                  where (!String.IsNullOrEmpty(person.father_id) ||
                                         !String.IsNullOrEmpty(person.mother_id) ||
                                         !String.IsNullOrEmpty(person.spouse_id) ||
                                         !String.IsNullOrEmpty(person.sibling1_id) ||
                                         !String.IsNullOrEmpty(person.sibling2_id) ||
                                         !String.IsNullOrEmpty(person.sibling3_id) ||
                                         !String.IsNullOrEmpty(person.child1_id) ||
                                         !String.IsNullOrEmpty(person.child2_id) ||
                                         !String.IsNullOrEmpty(person.child3_id))
                                  select person.id;

        // Now find the ID of the family members base on names specified in the scenario configurations
        if (_scenarioIdWithFamilies != null && _scenarioIdWithFamilies.Count() > 0 && _peopleHub != null)
        {
            // for each person find the id of family members
            foreach (string id in _scenarioIdWithFamilies)
            {
                PersonRecord record = _peopleHub[id];
                record.father_id = retrieveIdWithFullname(record.father_id, "father");
                record.mother_id = retrieveIdWithFullname(record.mother_id, "mother");
                record.spouse_id = retrieveIdWithFullname(record.spouse_id, "spouse");
                record.sibling1_id = retrieveIdWithFullname(record.sibling1_id, "sibling-1");
                record.sibling2_id = retrieveIdWithFullname(record.sibling2_id, "sibling-2");
                record.sibling3_id = retrieveIdWithFullname(record.sibling3_id, "sibling-3");
                record.child1_id = retrieveIdWithFullname(record.child1_id, "child-1");
                record.child2_id = retrieveIdWithFullname(record.child2_id, "child-2");
                record.child3_id = retrieveIdWithFullname(record.child3_id, "child-3");
            }
        }
    }

    // Find the ID of the person who has the specified "fullname". 
    // "relationship" is used for logging purposes only
    private string retrieveIdWithFullname(string fullname, string relationship)
    {
        String retirevedId = "";
        try
        {
            if (!String.IsNullOrEmpty(fullname))
                retirevedId = _peopleHub.Values.Where(person => String.Equals(person.fullname, fullname))
                                                    .Single().id;
        }
        catch (System.Exception)
        {
            Console.WriteLine("Unable to find record with {0}'s fullname {1}", relationship, fullname);
            retirevedId = "";
        }
        return retirevedId;
    }
    private void generateVehiclesInScenario()
    {
        if (_scenarioVehicleRecords.Count <= 0)
        {
            Console.WriteLine("There are no vehicles specified in the scenario, i.e. actors-vehicles.csv is empty.");
            return;
        }

        // Create the vehicle records 
        foreach (ScenarioVehicleRecord scnVeh in _scenarioVehicleRecords)
        {
            VehicleRecord vehicle = new VehicleRecord(scnVeh.license_plate);
            vehicle.update(scnVeh.make, scnVeh.model, scnVeh.color, scnVeh.vehicle_class);

            // Check if this vehicle is configured to use randomly assigned owners
            if (String.IsNullOrEmpty(scnVeh.use_random_owners)
                || scnVeh.use_random_owners.CompareTo("n") == 0)
            {
                String ownerId = retrieveIdWithVehicle(vehicle.plate_number);
                // Check if any person is owning this vehicle
                if (String.IsNullOrEmpty(ownerId))
                {
                    // No actors-person in the scene has been configured to own this vehicle
                    // Set vehicle to de-registered 
                    vehicle.updateRegistrationState("");
                }
                else
                {
                    // Found a configured actor owning this vehicle
                    vehicle.updateRegistrationState(ownerId);
                }
            }
            else
            {
                // Generate a person into the people's hub
                String ownerId = "";
                generateRandomPersonIntoPeopleHub(out ownerId);
                // Assign the person to own this vehicle
                vehicle.updateRegistrationState(ownerId);
            }
            _vehicleHub.Add(vehicle.plate_number, vehicle);
        }
    }
    private void generatePeopleVehicleRelationship()
    {
        // grab license plate set
        // var scenarioVehicles = from person in _peopleHub.Values
        //                        where !String.IsNullOrEmpty(person.car_plate)
        //                        select (person.car_plate, person.id);

        // if (scenarioVehicles != null && scenarioVehicles.Count() > 0)
        // {

        //     foreach (var veh in scenarioVehicles)
        //     {
        //         VehicleRecord record = new VehicleRecord(veh.car_plate, veh.id);
        //         VehicleMakeModel? generatedDetails = null;
        //         _vehicleSrcDs.getRandomRecord(out generatedDetails);
        //         if (generatedDetails != null)
        //         {
        //             record.update(ref generatedDetails);
        //         }
        //         _vehicleHub.Add(veh.car_plate, record);
        //     }
        // }
    }
    private string retrieveIdWithVehicle(string plateNo)
    {
        String retirevedId = "";
        try
        {
            if (!String.IsNullOrEmpty(plateNo))
                retirevedId = _peopleHub.Values.Where(person => String.Equals(person.car_plate, plateNo))
                                                    .Single().id;
        }
        catch (System.Exception)
        {
            Console.WriteLine("Unable to find record with vehicle's owner ID", plateNo);
            retirevedId = "";
        }
        return retirevedId;
    }
    void generateRandomPersonIntoPeopleHub(out string ownerId)
    {
        ownerId = "";

        PersonRecord? person = null;
        _personGenerator.generateRandomPerson(out person);
        if (person == null)
        {
            Console.WriteLine("Problem creating random person");
        }
        else
        {
            ownerId = person.id;
            _peopleHub.Add(person.id, person);
        }
    }
    private void generateDefaltPeopleRecords()
    {

    }
    private void generateVapFriendlies()
    {
        // Load tbl_device_id 
        // Load movement configs
        // Load movements 
        // Load defaults

        //_vapPersonDetectionGenerator

        IEnumerable<string> friendlyList = from record in _scenarioPersonRecords
                                           where (record.friendly.CompareTo("y") == 0)
                                           select record.id;

        _vapPersonDetectionGenerator.generateFriendliesInNeighborhood(friendlyList);
    }

    private void generateVapUnknownFriendlies()
    {
        _vapPersonDetectionGenerator.generateUnknownFriendlies();
    }

    public void generateVapFriendliesVehicle()
    {

    }
    private void generatePeopleHubCsv()
    {
        using (var writer = new StreamWriter(@Program.PEOPLE_HUB_CSV_FULLPATH_FILE))
        {
            writer.WriteLine(PersonRecord.getRecordHeader());
            foreach (PersonRecord record in _peopleHub.Values)
                writer.WriteLine(record.toCsvFormat());
        }
    }
    private void generateVehicleHubCsv()
    {
        using (var writer = new StreamWriter(@Program.VEHICLE_HUB_CSV_FULLPATH_FILE))
        {
            writer.WriteLine(VehicleRecord.getRecordHeader());
            foreach (VehicleRecord record in _vehicleHub.Values)
                writer.WriteLine(record.toCsvFormat());
        }
    }
    private void generateVapCsv()
    {
        _vapPersonDetectionGenerator.generateCsv(@Program.VAP_PERSON_ATTRIBUTE_EVENT_CSV_FULLPATH_FILE,
                                                 @Program.VAP_FR_EVENT_CSV_FULLPATH_FILE,
                                                 @Program.VAP_FR_ALERT_CSV_FULLPATH_FILE);
    }
}