namespace data;

using CsvHelper.Configuration;

class ScenarioVehicleRecord
{
    public string license_plate { get; set; }
    public string make { get; set; }
    public string model { get; set; }
    public string color { get; set; }
    public string vehicle_class { get; set; }
    public string use_random_owners { get; set; }
    public string is_friendly { get; set; }

    public ScenarioVehicleRecord()
    {
        license_plate = "";
        make = "";
        model = "";
        color = "";
        vehicle_class = "";
        use_random_owners = "";
        is_friendly = "";
    }
}

class ScenarioVehicleRecordDatamap : ClassMap<ScenarioVehicleRecord>
{
    public ScenarioVehicleRecordDatamap()
    {
        Map(p => p.license_plate).Index(0);
        Map(p => p.make).Index(1);
        Map(p => p.model).Index(2);
        Map(p => p.color).Index(3);
        Map(p => p.vehicle_class).Index(4);
        Map(p => p.use_random_owners).Index(5);
        Map(p => p.is_friendly).Index(6);
    }
}