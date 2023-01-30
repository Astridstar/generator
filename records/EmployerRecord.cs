namespace records;

using System.Text;
class EmployerRecord
{
    public string owner_id { get; set; }
    public string owner_fullname { get; set; }
    public string uen { get; set; }
    public string primary_ssic_description { get; set; }
    public string partner_id_1 { get; set; }
    public string partner_fullname_1 { get; set; }
    public string partner_id_2 { get; set; }
    public string partner_fullname_2 { get; set; }
    public string partner_id_3 { get; set; }
    public string partner_fullname_3 { get; set; }

    public EmployerRecord()
    {
        owner_id = "";
        owner_fullname = "";
        uen = "";
        primary_ssic_description = "";
        partner_id_1 = "";
        partner_fullname_1 = "";
        partner_id_2 = "";
        partner_fullname_2 = "";
        partner_id_3 = "";
        partner_fullname_3 = "";
    }

    public static string getRecordHeader()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}",
            nameof(owner_id),
            nameof(owner_fullname),
            nameof(uen),
            nameof(primary_ssic_description),
            nameof(partner_id_1),
            nameof(partner_fullname_1),
            nameof(partner_id_2),
            nameof(partner_fullname_2),
            nameof(partner_id_3),
            nameof(partner_fullname_3)
        );
        return builder.ToString();
    }

    public string toCsvFormat()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0},{1},{2},\"{3}\",{4},{5},{6},{7},{8},{9}",
            owner_id,
            owner_fullname,
            uen,
            primary_ssic_description,
            partner_id_1,
            partner_fullname_1,
            partner_id_2,
            partner_fullname_2,
            partner_id_3,
            partner_fullname_3
        );
        return builder.ToString();
    }
}