namespace data;

using CsvHelper.Configuration;

internal class VapObjectMovement
{
    public string camera_name { get; set; }
    public string forward_time_s { get; set; }
    public string backward_time_s { get; set; }

    public VapObjectMovement()
    {
        camera_name = "";
        forward_time_s = "";
        backward_time_s = "";
    }

}

internal class VapObjectMovementDatamap : ClassMap<VapObjectMovement>
{
    public VapObjectMovementDatamap()
    {
        Map(p => p.camera_name).Index(0);
        Map(p => p.forward_time_s).Index(1);
        Map(p => p.backward_time_s).Index(2);

    }
}