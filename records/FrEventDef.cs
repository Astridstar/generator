namespace records;

using System.Text;

class FrEventDefRecord
{
    public static readonly string EVENT_TYPE_PERSON = "FACE_ATTRIBUTE";
    public static readonly string VA_TYPE_PERSON = "FR";
    public string id { get; set; }
    public string event_id { get; set; }
    public string event_type { get; set; }
    public string event_dt { get; set; }
    public string va_engine_id { get; set; }
    public string va_type { get; set; }
    public string device_id { get; set; }
    public string full_image_url { get; set; }
    public string cropped_image_url { get; set; }
    public string bbox_x1 { get; set; }
    public string bbox_y1 { get; set; }
    public string bbox_x2 { get; set; }
    public string bbox_y2 { get; set; }
    public string vap_object_id { get; set; }

    private static IdGenerator _id_factory = new();
    public FrEventDefRecord()
    {
        id = "";
        event_id = "";
        event_type = "";
        event_dt = "";
        va_engine_id = "";
        va_type = "";
        device_id = "";
        full_image_url = "";
        cropped_image_url = "";
        bbox_x1 = "";
        bbox_y1 = "";
        bbox_x2 = "";
        bbox_y2 = "";
        vap_object_id = "";
    }
    public static string getRecordHeader()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}",
            nameof(id),
            nameof(event_id),
            nameof(event_type),
            nameof(event_dt),
            nameof(va_engine_id),
            nameof(va_type),
            nameof(device_id),
            nameof(full_image_url),
            nameof(cropped_image_url),
            nameof(bbox_x1),
            nameof(bbox_y1),
            nameof(bbox_x2),
            nameof(bbox_y2),
            nameof(vap_object_id)
        );
        return builder.ToString();
    }
    public string toCsvFormat()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}",
            id,
            event_id,
            event_type,
            event_dt,
            va_engine_id,
            va_type,
            device_id,
            full_image_url,
            cropped_image_url,
            bbox_x1,
            bbox_y1,
            bbox_x2,
            bbox_y2,
            vap_object_id);
        return builder.ToString();
    }
    public static long getNextId()
    {
        return _id_factory.getNextId();
    }
}