namespace data;

using CsvHelper.Configuration;

class VehicleMakeModel
{
    private string _make = "";
    private string _model = "";

    public string make
    {
        get => _make;
        set => _make = value;
    }
    public string model
    {
        get => _model;
        set => _model = value;
    }
}

class VehicleMakeModelDatamap : ClassMap<VehicleMakeModel>
{
    public VehicleMakeModelDatamap()
    {
        Map(p => p.make).Index(3);
        Map(p => p.model).Index(4);
    }
}