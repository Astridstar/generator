namespace data;

using CsvHelper;
using System.Globalization;

class VehicleMakeModelDataset
{
    Random _random = new Random();
    List<VehicleMakeModel> _vehicleSrcDs = new();
    public VehicleMakeModelDataset()
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

            csv.Context.RegisterClassMap<VehicleMakeModelDatamap>();
            _vehicleSrcDs.AddRange(csv.GetRecords<VehicleMakeModel>().ToList());
        }
    }

    public void getRandomRecord(out VehicleMakeModel? vehicle)
    {
        vehicle = null;
        if (_vehicleSrcDs.Count <= 0)
            return;

        int index = _random.Next(0, _vehicleSrcDs.Count);
        if (index < _vehicleSrcDs.Count)
            vehicle = _vehicleSrcDs.ElementAt(index);
    }
}