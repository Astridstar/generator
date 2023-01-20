namespace data;

using CsvHelper.Configuration;
class DeviceDefinitionData
{
    protected string _id = "";
    protected string _ref_id = "";
    protected string _device_name = "";
    protected string _device_type = "";
    protected string _description = "";
    protected string _ip_address = "";
    protected string _stream_url = "";
    protected string _stream_type = "";
    protected string _location_lat = "";
    protected string _location_long = "";
    protected string _location_elevation = "";
    protected string _zone_id = "";
    protected string _created_at = "";
    protected string _updated_at = "";

    public string id
    {
        get => _id;
        set => _id = value;
    }

    public string ref_id
    {
        get => _ref_id;
        set => _ref_id = value;
    }

    public string device_name
    {
        get => _device_name;
        set => _device_name = value;
    }

    public string device_type
    {
        get => _device_type;
        set => _device_type = value;
    }

    public string description
    {
        get => _description;
        set => _description = value;
    }

    public string ip_address
    {
        get => _ip_address;
        set => _ip_address = value;
    }

    public string stream_url
    {
        get => _stream_url;
        set => _stream_url = value;
    }

    public string stream_type
    {
        get => _stream_type;
        set => _stream_type = value;
    }

    public string location_lat
    {
        get => _location_lat;
        set => _location_lat = value;
    }

    public string location_long
    {
        get => _location_long;
        set => _location_long = value;
    }

    public string location_elevation
    {
        get => _location_elevation;
        set => _location_elevation = value;
    }

    public string zone_id
    {
        get => _zone_id;
        set => _zone_id = value;
    }

    public string created_at
    {
        get => _created_at;
        set => _created_at = value;
    }

    public string updated_at
    {
        get => _updated_at;
        set => _updated_at = value;
    }
}
internal class DeviceDefinitionDatamap : ClassMap<DeviceDefinitionData>
{
    public DeviceDefinitionDatamap()
    {
        Map(p => p.id).Index(0);
        Map(p => p.ref_id).Index(1);
        Map(p => p.device_name).Index(2);
        Map(p => p.device_type).Index(3);
        Map(p => p.description).Index(4);
        Map(p => p.ip_address).Index(5);
        Map(p => p.stream_url).Index(6);
        Map(p => p.stream_type).Index(7);
        Map(p => p.location_lat).Index(8);
        Map(p => p.location_long).Index(9);
        Map(p => p.location_elevation).Index(10);
        Map(p => p.zone_id).Index(11);
        Map(p => p.created_at).Index(12);
        Map(p => p.updated_at).Index(13);
    }
}