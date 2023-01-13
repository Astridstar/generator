namespace data;

using CsvHelper.Configuration;

class ArcaData
{
    private string _primary_ssic_description = "";

    public string primary_ssic_description
    {
        get => _primary_ssic_description;
        set => _primary_ssic_description = value;
    }
}

class ArcaDatamap : ClassMap<ArcaData>
{
    public ArcaDatamap()
    {
        Map(p => p.primary_ssic_description).Index(23);
    }
}