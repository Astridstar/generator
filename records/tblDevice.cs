namespace records;

using data;
class tblDevice : DeviceDefinitionData
{
    public string toCsvFormat()
    {
        return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{9},{10},{11},{12},{13}",
        id,
        ref_id,
        device_name,
        device_type,
        description,
        ip_address,
        stream_url,
        stream_type,
        location_lat,
        location_long,
        location_elevation,
        zone_id,
        created_at,
        updated_at);
    }

    public static string getRecordHeader()
    {
        return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{9},{10},{11},{12},{13}",
        nameof(id),
        nameof(ref_id),
        nameof(device_name),
        nameof(device_type),
        nameof(description),
        nameof(ip_address),
        nameof(stream_url),
        nameof(stream_type),
        nameof(location_lat),
        nameof(location_long),
        nameof(location_elevation),
        nameof(zone_id),
        nameof(created_at),
        nameof(updated_at));
    }
}

class tblDeviceMap : DeviceDefinitionDatamap
{

}