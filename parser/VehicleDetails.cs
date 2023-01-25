namespace parser;

class VehicleDetails
{
    public string license_plate { get; set; }
    public string color { get; set; }
    public string make { get; set; }
    public string model { get; set; }
    public string vehicle_class { get; set; }
    public VehicleDetails()
    {
        license_plate = "";
        color = "";
        make = "";
        model = "";
        vehicle_class = "";
    }

    public VehicleDetails(string license_plate, string make, string model, string color, string veh_class)
    {
        this.license_plate = license_plate;
        this.make = make;
        this.model = model;
        this.color = color;
        this.vehicle_class = veh_class;

    }
}