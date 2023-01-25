namespace records;

using System.Text;


class TblVehicleAttributeEventRecord
{
    public static readonly string VEH_EVENT_TYPE = "VEHICLE_ATTRIBUTE";
    public static readonly string VA_PROVIDER_NAME = "Sensetime";
    public static readonly string VA_ENGINE_CODE = "senseunity";
    public static readonly string VA_TYPE_CODE = "VEHICLE";
    public static readonly string BBOX_X1 = "886";
    public static readonly string BBOX_Y1 = "276";
    public static readonly string BBOX_X2 = "1093";
    public static readonly string BBOX_Y2 = "739";
    public static Random _rand = new Random();
    private static float _highCfdMinValue = 0.9f;
    private static float _highCfdMaxValue = 1.0f;

    public string id { get; set; }
    public string event_id { get; set; }
    public string event_type { get; set; }
    public string event_dt { get; set; }
    public string va_provider_name { get; set; }
    public string va_engine_code { get; set; }
    public string va_type_code { get; set; }
    public string device_id { get; set; }
    public string vehicle_make { get; set; }
    public string vehicle_make_cfd { get; set; }
    public string vehicle_model { get; set; }
    public string vehicle_model_cfd { get; set; }
    public string vehicle_colour { get; set; }
    public string vehicle_colour_cfd { get; set; }
    public string vehicle_class { get; set; }
    public string vehicle_class_cfd { get; set; }
    public string vehicle_angle { get; set; }
    public string vehicle_angle_cfd { get; set; }
    public string plate_number { get; set; }
    public string plate_number_cfd { get; set; }
    public string plate_colour { get; set; }
    public string plate_colour_cfd { get; set; }
    public string plate_colour_scheme { get; set; }
    public string plate_vehicle_class { get; set; }
    public string full_image_url { get; set; }
    public string cropped_image_url { get; set; }
    public string bbox_x1 { get; set; }
    public string bbox_y1 { get; set; }
    public string bbox_x2 { get; set; }
    public string bbox_y2 { get; set; }
    public string vap_object_id { get; set; }

    public TblVehicleAttributeEventRecord()
    {
        id = "";
        event_id = "";
        event_type = "";
        event_dt = "";
        va_provider_name = "";
        va_engine_code = "";
        va_type_code = "";
        device_id = "";
        vehicle_make = "";
        vehicle_make_cfd = "";
        vehicle_model = "";
        vehicle_model_cfd = "";
        vehicle_colour = "";
        vehicle_colour_cfd = "";
        vehicle_class = "";
        vehicle_class_cfd = "";
        vehicle_angle = "";
        vehicle_angle_cfd = "";
        plate_number = "";
        plate_number_cfd = "";
        plate_colour = "";
        plate_colour_cfd = "";
        plate_colour_scheme = "";
        plate_vehicle_class = "";
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
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            nameof(id),
            nameof(event_id),
            nameof(event_type),
            nameof(event_dt),
            nameof(va_provider_name),
            nameof(va_engine_code),
            nameof(va_type_code),
            nameof(device_id),
            nameof(vehicle_make),
            nameof(vehicle_make_cfd)
            );

        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            nameof(vehicle_model),
            nameof(vehicle_model_cfd),
            nameof(vehicle_colour),
            nameof(vehicle_colour_cfd),
            nameof(vehicle_class),
            nameof(vehicle_class_cfd),
            nameof(vehicle_angle),
            nameof(vehicle_angle_cfd),
            nameof(plate_number),
            nameof(plate_number_cfd)
            );

        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            nameof(plate_colour),
            nameof(plate_colour_cfd),
            nameof(plate_colour_scheme),
            nameof(plate_vehicle_class),
            nameof(full_image_url),
            nameof(cropped_image_url),
            nameof(bbox_x1),
            nameof(bbox_y1),
            nameof(bbox_x2),
            nameof(bbox_y2)
            );
        builder.AppendFormat("{0}",
            nameof(vap_object_id)
            );

        return builder.ToString();
    }
    public string toCsvFormat()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            id,
            event_id,
            event_type,
            event_dt,
            va_provider_name,
            va_engine_code,
            va_type_code,
            device_id,
            vehicle_make,
            vehicle_make_cfd
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            vehicle_model,
            vehicle_model_cfd,
            vehicle_colour,
            vehicle_colour_cfd,
            vehicle_class,
            vehicle_class_cfd,
            vehicle_angle,
            vehicle_angle_cfd,
            plate_number,
            plate_number_cfd
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            plate_colour,
            plate_colour_cfd,
            plate_colour_scheme,
            plate_vehicle_class,
            full_image_url,
            cropped_image_url,
            bbox_x1,
            bbox_y1,
            bbox_x2,
            bbox_y2
        );
        builder.AppendFormat("{0}",
            vap_object_id
            );

        return builder.ToString();
    }
    public static string getNextHighCfd()
    {
        return (_rand.NextSingle() * (_highCfdMaxValue - _highCfdMinValue) + _highCfdMinValue).ToString();
    }
    public static string generateFullImageUrlPrefix(DateTimeOffset eventDt, string eventId, string vaEngineCode)
    {
        StringBuilder builder = new();
        builder.AppendFormat("/{0}/{1}/{2}/{3}/full/{4}", eventDt.Year, eventDt.Month, eventDt.Day, vaEngineCode, eventId);
        return builder.ToString();
    }
    public static string generateCroppedImageUrlPrefix(DateTimeOffset eventDt, string eventId, string vaEngineCode)
    {
        StringBuilder builder = new();
        builder.AppendFormat("/{0}/{1}/{2}/{3}/cropped/{4}", eventDt.Year, eventDt.Month, eventDt.Day, vaEngineCode, eventId);
        return builder.ToString();
    }

}