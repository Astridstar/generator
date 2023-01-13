namespace data;

using CsvHelper;
using System.Globalization;

class ArcaDataset
{
    public ArcaDataset()
    {

    }

    public void load(string filename)
    {
        StreamReader reader = new StreamReader(filename);
        {
            CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            if (csv == null)
                return;

            csv.Context.RegisterClassMap<ArcaDatamap>();
            List<ArcaData> _vehicleSrcDs = (csv.GetRecords<ArcaData>().ToList());
        }
    }

}