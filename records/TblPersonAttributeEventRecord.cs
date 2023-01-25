using System.Text;

namespace records;

class TblPersonAttributeEventRecord
{
    public static readonly string EVENT_TYPE_PERSON = "PERSON_ATTRIBUTE";
    public static readonly string VA_PROVIDER_ID = "1";
    public static readonly string VA_ENGINE_ID = "1";
    public static readonly string VA_TYPE = "PAOD";
    public static readonly string BBOX_X1 = "886";
    public static readonly string BBOX_Y1 = "276";
    public static readonly string BBOX_X2 = "1093";
    public static readonly string BBOX_Y2 = "739";
    public static Random _rand = new Random();
    private static float _highCfdMinValue = 0.9f;
    private static float _highCfdMaxValue = 1.0f;

    private static float _lowCfdMinValue = 0.1f;
    private static float _lowCfdMaxValue = 0.3f;

    public string id { get; set; }
    public string event_id { get; set; }
    public string event_type { get; set; }
    public string event_dt { get; set; }
    public string va_provider_id { get; set; }
    public string va_engine_id { get; set; }
    public string va_type { get; set; }
    public string device_id { get; set; }
    public string gender { get; set; }
    public string gender_cfd { get; set; }
    public string ethnicity { get; set; }
    public string ethnicity_cfd { get; set; }
    public string lower_age_range { get; set; }
    public string lower_age_range_cfd { get; set; }
    public string upper_age_range { get; set; }
    public string upper_age_range_cfd { get; set; }
    public string age_class { get; set; }
    public string age_class_cfd { get; set; }
    public string height { get; set; }
    public string height_cfd { get; set; }
    public string headwear_type { get; set; }
    public string headwear_type_cfd { get; set; }
    public string hair_style { get; set; }
    public string hair_style_cfd { get; set; }
    public string hair_colour { get; set; }
    public string hair_colour_cfd { get; set; }
    public string hair_length { get; set; }
    public string hair_length_cfd { get; set; }
    public string eyewear_type { get; set; }
    public string eyewear_type_cfd { get; set; }
    public string eyewear_colour { get; set; }
    public string eyewear_colour_cfd { get; set; }
    public string mask_type { get; set; }
    public string mask_type_cfd { get; set; }
    public string mask_colour { get; set; }
    public string mask_colour_cfd { get; set; }
    public string facial_hair_type { get; set; }
    public string facial_hair_type_cfd { get; set; }
    public string facial_hair_colour { get; set; }
    public string facial_hair_colour_cfd { get; set; }
    public string facial_hair_length { get; set; }
    public string facial_hair_length_cfd { get; set; }
    public string skin_colour { get; set; }
    public string skin_colour_cfd { get; set; }
    public string topwear_type { get; set; }
    public string topwear_type_cfd { get; set; }
    public string topwear_pattern { get; set; }
    public string topwear_pattern_cfd { get; set; }
    public string topwear_colour { get; set; }
    public string topwear_colour_cfd { get; set; }
    public string sleeve_colour { get; set; }
    public string sleeve_colour_cfd { get; set; }
    public string sleeve_length { get; set; }
    public string sleeve_length_cfd { get; set; }
    public string outerwear_type { get; set; }
    public string outerwear_type_cfd { get; set; }
    public string outerwear_pattern { get; set; }
    public string outerwear_pattern_cfd { get; set; }
    public string outerwear_colour { get; set; }
    public string outerwear_colour_cfd { get; set; }
    public string outerwear_length { get; set; }
    public string outerwear_length_cfd { get; set; }
    public string necktie_type { get; set; }
    public string necktie_type_cfd { get; set; }
    public string necktie_pattern { get; set; }
    public string necktie_pattern_cfd { get; set; }
    public string necktie_colour { get; set; }
    public string necktie_colour_cfd { get; set; }
    public string bottomwear_type { get; set; }
    public string bottomwear_type_cfd { get; set; }
    public string bottomwear_pattern { get; set; }
    public string bottomwear_pattern_cfd { get; set; }
    public string bottomwear_colour { get; set; }
    public string bottomwear_colour_cfd { get; set; }
    public string bottomwear_length { get; set; }
    public string bottomwear_length_cfd { get; set; }
    public string footwear_type { get; set; }
    public string footwear_type_cfd { get; set; }
    public string footwear_pattern { get; set; }
    public string footwear_pattern_cfd { get; set; }
    public string footwear_colour { get; set; }
    public string footwear_colour_cfd { get; set; }
    public string bag_type { get; set; }
    public string bag_type_cfd { get; set; }
    public string bag_colour { get; set; }
    public string bag_colour_cfd { get; set; }
    public string uniform { get; set; }
    public string uniform_cfd { get; set; }
    public string full_image_url { get; set; }
    public string cropped_image_url { get; set; }
    public string bbox_x1 { get; set; }
    public string bbox_y1 { get; set; }
    public string bbox_x2 { get; set; }
    public string bbox_y2 { get; set; }
    public string vap_object_id { get; set; }

    public TblPersonAttributeEventRecord()
    {
        id = "";
        event_id = "";
        event_type = "";
        event_dt = "";
        va_provider_id = "";
        va_engine_id = "";
        va_type = "";
        device_id = "";
        gender = "";
        gender_cfd = "";
        ethnicity = "";
        ethnicity_cfd = "";
        lower_age_range = "";
        lower_age_range_cfd = "";
        upper_age_range = "";
        upper_age_range_cfd = "";
        age_class = "";
        age_class_cfd = "";
        height = "";
        height_cfd = "";
        headwear_type = "";
        headwear_type_cfd = "";
        hair_style = "";
        hair_style_cfd = "";
        hair_colour = "";
        hair_colour_cfd = "";
        hair_length = "";
        hair_length_cfd = "";
        eyewear_type = "";
        eyewear_type_cfd = "";
        eyewear_colour = "";
        eyewear_colour_cfd = "";
        mask_type = "";
        mask_type_cfd = "";
        mask_colour = "";
        mask_colour_cfd = "";
        facial_hair_type = "";
        facial_hair_type_cfd = "";
        facial_hair_colour = "";
        facial_hair_colour_cfd = "";
        facial_hair_length = "";
        facial_hair_length_cfd = "";
        skin_colour = "";
        skin_colour_cfd = "";
        topwear_type = "";
        topwear_type_cfd = "";
        topwear_pattern = "";
        topwear_pattern_cfd = "";
        topwear_colour = "";
        topwear_colour_cfd = "";
        sleeve_colour = "";
        sleeve_colour_cfd = "";
        sleeve_length = "";
        sleeve_length_cfd = "";
        outerwear_type = "";
        outerwear_type_cfd = "";
        outerwear_pattern = "";
        outerwear_pattern_cfd = "";
        outerwear_colour = "";
        outerwear_colour_cfd = "";
        outerwear_length = "";
        outerwear_length_cfd = "";
        necktie_type = "";
        necktie_type_cfd = "";
        necktie_pattern = "";
        necktie_pattern_cfd = "";
        necktie_colour = "";
        necktie_colour_cfd = "";
        bottomwear_type = "";
        bottomwear_type_cfd = "";
        bottomwear_pattern = "";
        bottomwear_pattern_cfd = "";
        bottomwear_colour = "";
        bottomwear_colour_cfd = "";
        bottomwear_length = "";
        bottomwear_length_cfd = "";
        footwear_type = "";
        footwear_type_cfd = "";
        footwear_pattern = "";
        footwear_pattern_cfd = "";
        footwear_colour = "";
        footwear_colour_cfd = "";
        bag_type = "";
        bag_type_cfd = "";
        bag_colour = "";
        bag_colour_cfd = "";
        uniform = "";
        uniform_cfd = "";
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
            nameof(va_provider_id),
            nameof(va_engine_id),
            nameof(va_type),
            nameof(device_id),
            nameof(gender),
            nameof(gender_cfd)
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            nameof(ethnicity),
            nameof(ethnicity_cfd),
            nameof(lower_age_range),
            nameof(lower_age_range_cfd),
            nameof(upper_age_range),
            nameof(upper_age_range_cfd),
            nameof(age_class),
            nameof(age_class_cfd),
            nameof(height),
            nameof(height_cfd)
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            nameof(headwear_type),
            nameof(headwear_type_cfd),
            nameof(hair_style),
            nameof(hair_style_cfd),
            nameof(hair_colour),
            nameof(hair_colour_cfd),
            nameof(hair_length),
            nameof(hair_length_cfd),
            nameof(eyewear_type),
            nameof(eyewear_type_cfd)
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            nameof(eyewear_colour),
            nameof(eyewear_colour_cfd),
            nameof(mask_type),
            nameof(mask_type_cfd),
            nameof(mask_colour),
            nameof(mask_colour_cfd),
            nameof(facial_hair_type),
            nameof(facial_hair_type_cfd),
            nameof(facial_hair_colour),
            nameof(facial_hair_colour_cfd)
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            nameof(facial_hair_length),
            nameof(facial_hair_length_cfd),
            nameof(skin_colour),
            nameof(skin_colour_cfd),
            nameof(topwear_type),
            nameof(topwear_type_cfd),
            nameof(topwear_pattern),
            nameof(topwear_pattern_cfd),
            nameof(topwear_colour),
            nameof(topwear_colour_cfd)
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            nameof(sleeve_colour),
            nameof(sleeve_colour_cfd),
            nameof(sleeve_length),
            nameof(sleeve_length_cfd),
            nameof(outerwear_type),
            nameof(outerwear_type_cfd),
            nameof(outerwear_pattern),
            nameof(outerwear_pattern_cfd),
            nameof(outerwear_colour),
            nameof(outerwear_colour_cfd)
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            nameof(outerwear_length),
            nameof(outerwear_length_cfd),
            nameof(necktie_type),
            nameof(necktie_type_cfd),
            nameof(necktie_pattern),
            nameof(necktie_pattern_cfd),
            nameof(necktie_colour),
            nameof(necktie_colour_cfd),
            nameof(bottomwear_type),
            nameof(bottomwear_type_cfd)
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            nameof(bottomwear_pattern),
            nameof(bottomwear_pattern_cfd),
            nameof(bottomwear_colour),
            nameof(bottomwear_colour_cfd),
            nameof(bottomwear_length),
            nameof(bottomwear_length_cfd),
            nameof(footwear_type),
            nameof(footwear_type_cfd),
            nameof(footwear_pattern),
            nameof(footwear_pattern_cfd)
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            nameof(footwear_colour),
            nameof(footwear_colour_cfd),
            nameof(bag_type),
            nameof(bag_type_cfd),
            nameof(bag_colour),
            nameof(bag_colour_cfd),
            nameof(uniform),
            nameof(uniform_cfd),
            nameof(full_image_url),
            nameof(cropped_image_url)
        );
        builder.AppendFormat("{0},{1},{2},{3},{4}",
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

        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            id,
            event_id,
            event_type,
            event_dt,
            va_provider_id,
            va_engine_id,
            va_type,
            device_id,
            gender,
            gender_cfd
        );

        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            ethnicity,
            ethnicity_cfd,
            lower_age_range,
            lower_age_range_cfd,
            upper_age_range,
            upper_age_range_cfd,
            age_class,
            age_class_cfd,
            height,
            height_cfd
        );

        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            headwear_type,
            headwear_type_cfd,
            hair_style,
            hair_style_cfd,
            hair_colour,
            hair_colour_cfd,
            hair_length,
            hair_length_cfd,
            eyewear_type,
            eyewear_type_cfd
        );

        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            eyewear_colour,
            eyewear_colour_cfd,
            mask_type,
            mask_type_cfd,
            mask_colour,
            mask_colour_cfd,
            facial_hair_type,
            facial_hair_type_cfd,
            facial_hair_colour,
            facial_hair_colour_cfd
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            facial_hair_length,
            facial_hair_length_cfd,
            skin_colour,
            skin_colour_cfd,
            topwear_type,
            topwear_type_cfd,
            topwear_pattern,
            topwear_pattern_cfd,
            topwear_colour,
            topwear_colour_cfd
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            sleeve_colour,
            sleeve_colour_cfd,
            sleeve_length,
            sleeve_length_cfd,
            outerwear_type,
            outerwear_type_cfd,
            outerwear_pattern,
            outerwear_pattern_cfd,
            outerwear_colour,
            outerwear_colour_cfd
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            outerwear_length,
            outerwear_length_cfd,
            necktie_type,
            necktie_type_cfd,
            necktie_pattern,
            necktie_pattern_cfd,
            necktie_colour,
            necktie_colour_cfd,
            bottomwear_type,
            bottomwear_type_cfd
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            bottomwear_pattern,
            bottomwear_pattern_cfd,
            bottomwear_colour,
            bottomwear_colour_cfd,
            bottomwear_length,
            bottomwear_length_cfd,
            footwear_type,
            footwear_type_cfd,
            footwear_pattern,
            footwear_pattern_cfd
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            footwear_colour,
            footwear_colour_cfd,
            bag_type,
            bag_type_cfd,
            bag_colour,
            bag_colour_cfd,
            uniform,
            uniform_cfd,
            full_image_url,
            cropped_image_url
        );
        builder.AppendFormat("{0},{1},{2},{3},{4}",
            bbox_x1,
            bbox_y1,
            bbox_x2,
            bbox_y2,
            vap_object_id
        );
        return builder.ToString();
    }

    public static string convertGender(string src)
    {
        if (String.IsNullOrEmpty(src))
            return "UNKNOWN";

        if (src.ToUpper().CompareTo("M") == 0)
            return "MALE";
        else if (src.ToUpper().CompareTo("F") == 0)
            return "FEMALE";
        else
            return "UNKNOWN";
    }
    public static string getNextHighCfd()
    {
        return getNextCfd(_highCfdMinValue, _highCfdMaxValue);
    }
    public static string getNextLowCfd()
    {
        return getNextCfd(_lowCfdMinValue, _lowCfdMaxValue);
    }
    private static string getNextCfd(float min, float max)
    {
        return (_rand.NextSingle() * (max - min) + min).ToString();
    }
    public static string generateFullImageUrlPrefix(DateTimeOffset eventDt, string eventId, string vaProviderId)
    {
        StringBuilder builder = new();
        builder.AppendFormat("/{0}/{1}/{2}/{3}/full/{4}", eventDt.Year, eventDt.Month, eventDt.Day, vaProviderId, eventId);
        return builder.ToString();
    }
    public static string generateCroppedImageUrlPrefix(DateTimeOffset eventDt, string eventId, string vaProviderId)
    {
        StringBuilder builder = new();
        builder.AppendFormat("/{0}/{1}/{2}/{3}/cropped/{4}", eventDt.Year, eventDt.Month, eventDt.Day, vaProviderId, eventId);
        return builder.ToString();
    }
}