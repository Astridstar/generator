namespace records;

using parser;
using data;

class VehicleRecord
{
    private static VehicleDataGenerator _generator = new();
    public string plate_number { get; set; }
    public string make { get; set; }
    public string model { get; set; }
    public string iu_number { get; set; }
    public string owner_nric { get; set; }
    public string registration_dt { get; set; }
    public string is_registered { get; set; }
    public string deregistration_dt { get; set; }
    public string is_foreign_car { get; set; }
    public string vehicle_type { get; set; }
    public string color { get; set; }


    public VehicleRecord(string plateNo)
    {
        this.plate_number = plateNo;
        this.owner_nric = "";
        this.iu_number = _generator.getRandomIuNumber();
        this.make = "";
        this.model = "";
        this.registration_dt = "";
        this.is_registered = "";
        this.deregistration_dt = "";
        this.is_foreign_car = "";
        this.vehicle_type = "";
        this.color = "";
    }
    public VehicleRecord(string plateNo, string ownerId)
    {
        this.plate_number = plateNo;
        this.owner_nric = ownerId;
        this.iu_number = _generator.getRandomIuNumber();
        this.make = "";
        this.model = "";
        this.registration_dt = "";
        this.is_registered = "";
        this.deregistration_dt = "";
        this.is_foreign_car = "";
        this.vehicle_type = "";
        this.color = "";
    }
    public void update(string make, string model, string color, string vehicleType)
    {
        this.make = make;
        this.model = model;
        this.registration_dt = _generator.randomDateTime().ToString("yyyy-MM-dd");
        this.is_registered = "1";
        this.deregistration_dt = "";
        this.is_foreign_car = "0";
        this.vehicle_type = vehicleType;
        this.color = color;
    }
    public void update(ref VehicleMakeModel genDs)
    {
        this.make = genDs.make;
        this.model = genDs.Model;
        this.registration_dt = _generator.randomDateTime().ToString("yyyy-MM-dd");
        this.is_registered = "1";
        this.deregistration_dt = "";
        this.is_foreign_car = "0";
        this.vehicle_type = "passenger";
        this.color = _generator.getRandomColors();
    }
    public void updateRegistrationState(string ownerId)
    {
        if (String.IsNullOrEmpty(ownerId))
        {
            this.owner_nric = "";
            this.is_registered = "0";
            this.deregistration_dt = _generator.randomDateTime().ToString("yyyy-MM-dd");
        }
        else
        {
            this.owner_nric = ownerId;
            this.is_registered = "1";
            this.registration_dt = _generator.randomDateTime().ToString("yyyy-MM-dd");
        }
    }
    public string toCsvFormat()
    {
        return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}",
            (plate_number),
            (make),
            (model),
            (iu_number),
            (owner_nric),
            (registration_dt),
            (is_registered),
            (deregistration_dt),
            (is_foreign_car),
            (vehicle_type),
            (color));
    }
    public static string getRecordHeader()
    {
        return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}",
            nameof(plate_number),
            nameof(make),
            nameof(model),
            nameof(iu_number),
            nameof(owner_nric),
            nameof(registration_dt),
            nameof(is_registered),
            nameof(deregistration_dt),
            nameof(is_foreign_car),
            nameof(vehicle_type),
            nameof(color));
    }
}