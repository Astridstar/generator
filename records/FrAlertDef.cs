namespace records;

using System.Text;
class FrAlertDefRecord
{
    public string id { get; set; }
    public string fr_event_id { get; set; }
    public string fr_alert_dt { get; set; }
    public string va_engine_id { get; set; }
    public string person_id { get; set; }
    public string score { get; set; }
    public string info { get; set; }
    public string key { get; set; }

    private static IdGenerator _id_factory = new();
    private static float _highCfdMinValue = 0.9f;
    private static float _highCfdMaxValue = 1.0f;
    private static Random _rand = new();

    public FrAlertDefRecord()
    {
        id = "";
        fr_event_id = "";
        fr_alert_dt = "";
        va_engine_id = "";
        person_id = "";
        score = "";
        info = "";
        key = "";
    }

    public static string getRecordHeader()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7}",
            nameof(id),
            nameof(fr_event_id),
            nameof(fr_alert_dt),
            nameof(va_engine_id),
            nameof(person_id),
            nameof(score),
            nameof(info),
            nameof(key)
        );
        return builder.ToString();
    }

    public string toCsvFormat()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7}",
            id,
            fr_event_id,
            fr_alert_dt,
            va_engine_id,
            person_id,
            score,
            info,
            key
        );
        return builder.ToString();
    }
    public static long getNextId()
    {
        return _id_factory.getNextId();
    }
    public static string getNextCfd()
    {
        return (_rand.NextSingle() * (_highCfdMaxValue - _highCfdMinValue) + _highCfdMinValue).ToString();
    }
}