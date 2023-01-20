namespace data;

using CsvHelper;
using System.Globalization;

internal class PersonMovementDataset
{
    List<PersonMovement> _personMovementList = new();

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

            csv.Context.RegisterClassMap<PersonMovementDatamap>();
            _personMovementList.AddRange(csv.GetRecords<PersonMovement>().ToList());
        }
    }
}

