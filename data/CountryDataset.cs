namespace data;

using CsvHelper;
using System.Globalization;

internal class CountryDataset
{
    IEnumerable<string>? _countries = null;

    public void load(string filename)
    {
        StreamReader reader = new StreamReader(filename);
        {
            CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            if (csv == null)
                return;

            csv.Context.RegisterClassMap<CountryMap>();
            List<Country> records = csv.GetRecords<Country>().ToList();
            _countries = from record in records
                         select record.country;
        }

    }
    public string ElementAt(int index)
    {
        if (_countries == null || _countries.Count() <= index) return "";

        return _countries.ElementAt(index);
    }
    public int getMaxCountryRecord()
    {
        return _countries == null ? -1 : _countries.Count();
    }
}