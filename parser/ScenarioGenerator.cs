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
    List<ScenarioRecord> _scenarioRecords = new();

    IEnumerable<string>? _scenarioVehiclesPlate;
    IEnumerable<string>? _scenarioIdWithFamilies;
    IEnumerable<string>? _scenarioEmployers;

    AddressesParser _addressParser;

    RandHumanPropDataset _randHumanPropDs;

    public ScenarioGenerator(ref RandHumanPropDataset randHumanPropDs, ref AddressesParser parser)
    {
        _randHumanPropDs = randHumanPropDs;
        _addressParser = parser;
    }
    private void load(string filename)
    {
        StreamReader reader = new StreamReader(filename);
        {
            CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            if (csv == null)
                return;

            csv.Context.RegisterClassMap<ScenarioRecordMap>();
            _scenarioRecords.AddRange(csv.GetRecords<ScenarioRecord>().ToList());
        }
    }

    public bool generate(string scenariofile)
    {
        try
        {
            load(scenariofile);
        }
        catch (Exception e)
        {
            Console.Write(e);
            return false;
        }

        // Nothing to generate
        if (_scenarioRecords.Count <= 0) return false;

        #region Generate data
        //1. Generate people_hub
        //2. Generate family
        generatePeopleInScenario();

        //3. Generate vehicle
        generateVehiclesInScenario();

        //4. Generate employer

        //5. Generate friendly
        //6. Generate blacklisted person
        //7. Generate blacklisted vehicle
        #endregion

        generateDefaltPeopleRecords();

        // Now generate the CSV data
        generatePeopleHubCsv(); // ICA PeopleHub
        generateVehicleHubCsv(); // LTA VehicleHub
        return true;
    }

    private void generatePeopleInScenario()
    {
        foreach (ScenarioRecord record in _scenarioRecords)
        {
            string addr = "";
            string post = "";
            _addressParser.getNextAddress(out addr, out post);
            _peopleHub.Add(record.id,
            new PersonRecord(record, addr, post, _randHumanPropDs.getNextEmail(), "", _randHumanPropDs.getNextMobileNumber()));
        }

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

        formFamilyRelationsInScenario();
    }

    private void formFamilyRelationsInScenario()
    {
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
        // grab license plate set
        var scenarioVehicles = from person in _peopleHub.Values
                               where !String.IsNullOrEmpty(person.car_plate)
                               select (person.car_plate, person.id);

        if (scenarioVehicles != null && scenarioVehicles.Count() > 0)
        {
            // for each person find the id of family members
            foreach (var veh in scenarioVehicles)
            {
                _vehicleHub.Add(veh.car_plate, new VehicleRecord(veh.car_plate, veh.id));
            }
        }
        // generate the LTA vehicle hub
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
    private void generateDefaltPeopleRecords()
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
}