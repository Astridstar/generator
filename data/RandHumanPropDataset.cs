namespace data;

using CsvHelper;
using System.Globalization;

class RandHumanPropDataset
{
    private IEnumerable<string>? _nricList;
    private IEnumerable<string>? _emailList;
    private IEnumerable<string>? _dobList;
    private IEnumerable<string>? _mobileList;
    private IEnumerable<string>? _passportList;

    private int _nricIndex = 0;
    private int _emailIndex = 0;
    private int _dobIndex = 0;
    private int _mobileIndex = 0;
    private int _passportIndex = 0;

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
    public string getNextNric()
    {
        if (_nricList == null)
            return "";

        if (_nricIndex >= _nricList.Count())
            _nricIndex = 0;
        return _nricList.ElementAt(_nricIndex++);
    }
    public string getNextEmail()
    {
        if (_emailList == null)
            return "";

        if (_emailIndex >= _emailList.Count())
            _emailIndex = 0;
        return _emailList.ElementAt(_emailIndex++);
    }
    public string getNextDob()
    {
        if (_dobList == null)
            return "";

        if (_dobIndex >= _dobList.Count())
            _dobIndex = 0;
        return _dobList.ElementAt(_dobIndex++);
    }
    public string getNextMobileNumber()
    {
        if (_mobileList == null)
            return "";

        if (_mobileIndex >= _mobileList.Count())
            _mobileIndex = 0;
        return _mobileList.ElementAt(_mobileIndex++);
    }
    public string getNextPassportId()
    {
        if (_passportList == null)
            return "";

        if (_passportIndex >= _passportList.Count())
            _passportIndex = 0;
        return _passportList.ElementAt(_passportIndex++);
    }
}

