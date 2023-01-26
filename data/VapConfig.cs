namespace data;

internal class VapConfig
{
    public string DeviceDefinitionCsv { get; init; }
    public string VapObjectConfigCsv { get; init; }
    public string CameraListCsv { get; init; }
    public string PersonMovementCsv { get; init; }
    public string VehicleMovementCsv { get; init; }
    public string ScenarioOccuranceDateTime { get; init; }
    public string NumberOfDaysOfVapRecords { get; init; }

    public VapConfig()
    {
        DeviceDefinitionCsv = "";
        VapObjectConfigCsv = "";
        CameraListCsv = "";
        PersonMovementCsv = "";
        VehicleMovementCsv = "";
        ScenarioOccuranceDateTime = "";
        NumberOfDaysOfVapRecords = "";
    }

    public DateTimeOffset getScenarioOccuranceDateTime()
    {
        DateTimeOffset dto;
        if (!DateTimeOffset.TryParse(ScenarioOccuranceDateTime, out dto))
            dto = DateTimeOffset.Now;

        return dto;
    }

}