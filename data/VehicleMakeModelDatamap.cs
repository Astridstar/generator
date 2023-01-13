namespace data;

using CsvHelper.Configuration;

class VehicleMakeModel
{
    private string _make = "";
    private string _model = "";
    private string _year = "";
    private string _transmission = "";
    private string _body = "";
    private string _fuel = "";
    private string _capacity = "";
    public string make
    {
        get => _make;
        set => _make = value;
    }
    public string Model
    {
        get => _model;
        set => _model = value;
    }
    public string year
    {
        get => _year;
        set => _year = value;
    }
    public string transmission
    {
        get => _transmission;
        set => _transmission = value;
    }
    public string body
    {
        get => _body;
        set => _body = value;
    }
    public string fuel
    {
        get => _fuel;
        set => _fuel = value;
    }
    public string capacity
    {
        get => _capacity;
        set => _capacity = value;
    }
}

class VehicleMakeModelDatamap : ClassMap<VehicleMakeModel>
{
    public VehicleMakeModelDatamap()
    {
        Map(p => p.make).Index(0);
        Map(p => p.Model).Index(1);
        Map(p => p.year).Index(2);
        Map(p => p.transmission).Index(3);
        Map(p => p.body).Index(4);
        Map(p => p.fuel).Index(5);
    }
}