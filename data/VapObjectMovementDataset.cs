namespace data;

using CsvHelper;
using System.Globalization;

internal class VapObjectMovementDataset
{
    List<VapObjectMovement> _vapObjMovementList = new();

    public List<VapObjectMovement> VapObjectMovementList
    {
        get { return _vapObjMovementList; }
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

            csv.Context.RegisterClassMap<VapObjectMovementDatamap>();
            _vapObjMovementList.AddRange(csv.GetRecords<VapObjectMovement>().ToList());
        }
    }

}

