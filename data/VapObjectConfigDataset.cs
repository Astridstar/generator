namespace data;

using CsvHelper;
using System.Globalization;

class VapObjectConfigDataset
{
    Random _random = new Random();
    List<VapObjectConfig> _vapObjectConfigDs = new();

    public VapObjectConfigDataset()
    {

    }

    public void load(string filename)
    {
        StreamReader reader = new StreamReader(filename);
        {
            var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null
            };

            CsvReader csv = new CsvReader(reader, config);
            if (csv == null)
                return;

            csv.Context.RegisterClassMap<VapObjectConfigDatamap>();
            _vapObjectConfigDs.AddRange(csv.GetRecords<VapObjectConfig>().ToList());
        }
    }

    public void getRandomRecord(out VapObjectConfig? vapObject)
    {
        vapObject = null;
        if (_vapObjectConfigDs.Count <= 0)
            return;

        int index = _random.Next(0, _vapObjectConfigDs.Count);
        if (index < _vapObjectConfigDs.Count)
            vapObject = _vapObjectConfigDs.ElementAt(index);
    }

    public void getVapObjectConfig(out VapObjectConfig? vapObject, string id)
    {
        vapObject = null;
        if (_vapObjectConfigDs.Count <= 0)
            return;

        vapObject = _vapObjectConfigDs.Where(x => x.known_id == id).SingleOrDefault();
    }

    public void getVapObjectConfigWithUnknownPersons(out IEnumerable<VapObjectConfig>? vapObjectList)
    {
        vapObjectList = null;
        if (_vapObjectConfigDs.Count <= 0)
            return;

        vapObjectList = _vapObjectConfigDs.Where(x => x.is_known == "0");
    }

}