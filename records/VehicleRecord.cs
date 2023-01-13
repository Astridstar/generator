namespace records;

using parser;

class VehicleRecord
{
    private static IUGenerator _generator = new();
    private string plate_number { get; set; }
    private string make { get; set; }
    private string model { get; set; }
    private string iu_number { get; set; }
    private string owner_nric { get; set; }
    private string registration_dt { get; set; }
    private string is_registration { get; set; }
    private string de_registration_dt { get; set; }
    private string is_foreign_car { get; set; }
    private string vehicle_type { get; set; }
    private string color { get; set; }

    public VehicleRecord(string plateNo, string ownerId)
    {
        this.plate_number = plateNo;
        this.owner_nric = ownerId;
        this.iu_number = _generator.getRandomIuNumber();
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
            (is_registration),
            (de_registration_dt),
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
            nameof(is_registration),
            nameof(de_registration_dt),
            nameof(is_foreign_car),
            nameof(vehicle_type),
            nameof(color));
    }
}