namespace data;

internal class VapConfig
{
    public string DeviceDefinitionCsv { get; init; }
    public string VapObjectConfigCsv { get; init; }
    public string CameraListCsv { get; init; }
    public string PersonMovementCsv { get; init; }

    public VapConfig()
    {
        DeviceDefinitionCsv = "";
        VapObjectConfigCsv = "";
        CameraListCsv = "";
        PersonMovementCsv = "";
    }

}