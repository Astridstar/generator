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
    List<ScenarioRecord> _scenarioRecords = new();

    RandHumanPropDataset _randHumanPropDs;

    public ScenarioGenerator(ref RandHumanPropDataset randHumanPropDs)
    {
        _randHumanPropDs = randHumanPropDs;
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
        generatePeopleInScenario();

        //2. Generate family
        formFamilyRelationsInScenario();

        //3. Generate vehicle
        generateVehiclesInScenario();

        //4. Generate employer
        //5. Generate friendly
        //6. Generate blacklisted person
        //7. Generate blacklisted vehicle
        #endregion

        generateDefaltPeopleRecords();

        generatePeopleHubCsv();
        return true;
    }

    private void generatePeopleInScenario()
    {
        foreach (ScenarioRecord record in _scenarioRecords)
        {
            _peopleHub.Add(record.id, new PersonRecord(record));
        }
    }

    private void formFamilyRelationsInScenario()
    {
        // for each person find the id of family members
    }
    private void generateVehiclesInScenario()
    {
        // grab license plate set
        // generate the LTA vehicle hub
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
}