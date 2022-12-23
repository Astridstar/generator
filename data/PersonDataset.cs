namespace data;

using CsvHelper;
using System.Globalization;

internal class PersonDataset 
{
    IEnumerable<PersonName>? _chineseNamesDataset = null;
    IEnumerable<PersonName>? _indianNamesCsv = null;
    IEnumerable<PersonName>? _malayNamesCsv = null;

    List<PersonName> _personNames = new List<PersonName>();
    List<FamilyConfig> _familyConfig = new List<FamilyConfig>();

    public void loadChineseNamesDataset(string filename)
    {
        _chineseNamesDataset = load(filename);
    }
    public void loadIndianNamesDataset(string filename)
    {
        _indianNamesCsv = load(filename);
    }
    public void loadMalayNamesDataset(string filename)
    {
        _malayNamesCsv = load(filename);
    }
    public void loadFamilyConfig(string filename)
    {
        StreamReader reader = new StreamReader(filename);
        {
            CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            if(csv == null)
                return;

            csv.Context.RegisterClassMap<FamilyConfigMap>();
            _familyConfig = csv.GetRecords<FamilyConfig>().ToList();
        }       
    }

    public void combine()
    {
        if( _chineseNamesDataset != null )
        {
            _personNames = _personNames.Concat(_chineseNamesDataset).ToList();
        }
        else if ( _indianNamesCsv != null )
        {
            _personNames = _personNames.Concat(_indianNamesCsv).ToList();
        }
        else if ( _malayNamesCsv != null )
        {
            _personNames = _personNames.Concat(_malayNamesCsv).ToList();
        }

        var records = _personNames.Where(i => i.Gender == "M");


    }

    private IEnumerable<PersonName>? load(string filename)
    {
        StreamReader reader = new StreamReader(filename);
        {
            CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            if(csv == null)
                return null;

            csv.Context.RegisterClassMap<PersonMap>();
            return csv.GetRecords<PersonName>();
        }
    }
}