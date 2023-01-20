namespace data;

using CsvHelper.Configuration;

internal class PersonMovement
{
    public string camera_name { get; set; }
    public string forward_time_s { get; set; }
    public string backward_time_s { get; set; }

}

internal class PersonMovementDatamap : ClassMap<PersonMovement>
{
    public PersonMovementDatamap()
    {
        Map(p => p.camera_name).Index(0);
        Map(p => p.forward_time_s).Index(1);
        Map(p => p.backward_time_s).Index(2);

    }
}