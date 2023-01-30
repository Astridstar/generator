namespace parser;

using System.Globalization;
using System.Text;
using CsvHelper;
using data;
using records;

class BusinessGenerator
{
    List<AcraInformation> _acraSrcDs = new();
    // Mapping of UEIN to the employer records
    Dictionary<string, EmployerRecord> _employerDs = new();

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
    public void generateCsv(string dstFileName, string employerFileName)
    {
        using (var writer = new StreamWriter(@dstFileName))
        {
            writer.WriteLine(AcraInformation.getRecordHeader());
            foreach (AcraInformation record in _acraSrcDs)
                writer.WriteLine(record.toCsvFormat());
        }

        using (var writer = new StreamWriter(@employerFileName))
        {
            writer.WriteLine(EmployerRecord.getRecordHeader());
            foreach (EmployerRecord record in _employerDs.Values)
                writer.WriteLine(record.toCsvFormat());
        }
    }

    // Create a business entitiy and return its UEN number to the caller
    public string generateBusinessEntity(string businessName, int numOfOfficers, string address, string postal)
    {
        AcraInformation entity = new();
        entity.uen = _randGenerator.randomNumerals(10) + _randGenerator.randomString(1);
        entity.entity_name = businessName;
        entity.entity_type_description = "Local Company";
        entity.business_constitution_description = "Partnership";
        entity.company_type_description = "na";
        entity.paf_constitution_description = "na";
        entity.entity_status_description = "Live";
        entity.no_of_officers = numOfOfficers.ToString();
        entity.street_name = address;
        entity.postal_code = postal;
        entity.uen_issue_date = _randGenerator.randomDateTime().ToString("yyyy-MM-ddTHH:mm:ss");
        entity.registration_incorporation_date = entity.uen_issue_date;
        _acraSrcDs.Add(entity);
        return entity.uen;
    }
    public void generateBusinessEntityOwnerships(string uen, string owner_id, string owner_fullname)
    {
        if (_employerDs.ContainsKey(uen))
            return;

        try
        {
            string code = _acraSrcDs.Where(x => !String.IsNullOrEmpty(x.uen) && x.uen.CompareTo(uen) == 0).Select(x => x.primary_ssic_code).Single();
            EmployerRecord ownerRecord = new();
            ownerRecord.owner_fullname = owner_fullname;
            ownerRecord.owner_id = owner_id;
            ownerRecord.uen = uen;
            ownerRecord.primary_ssic_description = code;
            _employerDs[uen] = ownerRecord;
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Unable to find business in ACRA dataset with UEN {0}.", uen);
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Found duplicate records of business in ACRA dataset with UEN {0}.", uen);
        }
    }
    public void generateBusinessEntityPartnerships(string uen, string partner_id, string partner_fullname)
    {
        if (!_employerDs.ContainsKey(uen))
        {
            Console.WriteLine("Unable to find employer records for UEN {0}", uen);
            return;
        }

        if (String.IsNullOrEmpty(_employerDs[uen].partner_id_1))
        {
            _employerDs[uen].partner_id_1 = partner_id;
            _employerDs[uen].partner_fullname_1 = partner_fullname;
        }
        else if (String.IsNullOrEmpty(_employerDs[uen].partner_id_2))
        {
            _employerDs[uen].partner_id_2 = partner_id;
            _employerDs[uen].partner_fullname_2 = partner_fullname;
        }
        else if (String.IsNullOrEmpty(_employerDs[uen].partner_id_3))
        {
            _employerDs[uen].partner_id_3 = partner_id;
            _employerDs[uen].partner_fullname_3 = partner_fullname;
        }
        else
        {
            Console.WriteLine("Unable to add more partners for UEN {0}. Limit reached!", uen);
        }
    }

}