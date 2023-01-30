namespace parser;

using System.Globalization;
using System.Text;
using CsvHelper;
using data;
using records;

class BusinessGenerator
{
    List<AcraInformation> _acraSrcDs = new();
    IdGenerator _idGenerator = new();
    RandomGenerator _randGenerator = new(new DateTime(1997, 1, 1), new DateTime(2010, 12, 31));

    public BusinessGenerator(string srcDataFilename)
    {
        load(srcDataFilename);
    }

    public void load(string srcDataFilename)
    {
        StreamReader reader = new StreamReader(srcDataFilename);
        {
            var config = new CsvHelper.Configuration.CsvConfiguration(CultureInfo.InvariantCulture)
            {
                MissingFieldFound = null
            };

            CsvReader csv = new CsvReader(reader, config);
            if (csv == null)
                return;

            csv.Context.RegisterClassMap<AcraInformationDatamap>();
            _acraSrcDs.AddRange(csv.GetRecords<AcraInformation>().ToList());
        }
    }
    public void generateCsv(string dstFileName)
    {
        using (var writer = new StreamWriter(@dstFileName))
        {
            writer.WriteLine(AcraInformation.getRecordHeader());
            foreach (AcraInformation record in _acraSrcDs)
                writer.WriteLine(record.toCsvFormat());
        }
    }

    // Create a business entitiy and return its UEN number to the caller
    public string generateBusinessEntity(string businessName, int numOfOfficers, string address, string postal)
    {
        AcraInformation entity = new();
        entity.uen = _randGenerator.randomNumerals(12);
        entity.entity_name = businessName;
        entity.no_of_officers = numOfOfficers.ToString();
        entity.street_name = address;
        entity.postal_code = postal;
        entity.uen_issue_date = _randGenerator.randomDateTime().ToString("yyyy-MM-dd HH:mm:ss");
        _acraSrcDs.Add(entity);
        return entity.uen;
    }

}