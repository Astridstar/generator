namespace data;

using CsvHelper;
using System.Globalization;

class RandHumanPropDataset
{
    public IEnumerable<string>? _nricList;
    public IEnumerable<string>? _emailList;
    public IEnumerable<string>? _dobList;
    public IEnumerable<string>? _mobileList;
    public IEnumerable<string>? _passportList;

    public RandHumanPropDataset()
    {
    }

    public void load(string filename)
    {
        StreamReader reader = new StreamReader(filename);
        {
            CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            if (csv == null)
                return;

            csv.Context.RegisterClassMap<RandHumanPropDatamap>();
            List<RandRecords> records = csv.GetRecords<RandRecords>().ToList();

            _nricList = from record in records
                        select record.nric;
            _emailList = from record in records
                         select record.email;
            _dobList = from record in records
                       select record.dob;
            _mobileList = from record in records
                          select record.mobile;
            _passportList = from record in records
                            select record.passport;
        }
    }
}

