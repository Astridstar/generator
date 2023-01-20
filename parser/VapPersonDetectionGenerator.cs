namespace parser;

using CsvHelper;
using data;
using records;
class VapPersonDetectionGenerator
{
    VapObjectConfigDataset _vapConfigDs = new();
    PersonMovementDataset _personMovementDs = new();
    DeviceDefinitionDataset _deviceDefinitionDs = new();

    List<tbl_person_attribute_event_record> _vapPersonRecords = new();

    public VapPersonDetectionGenerator()
    {
    }

    public void load(ref VapConfig vapConfig)
    {
        try
        {
            _vapConfigDs.load(vapConfig.VapObjectConfigCsv);
            _personMovementDs.load(vapConfig.PersonMovementCsv);
            _deviceDefinitionDs.load(vapConfig.DeviceDefinitionCsv);
        }
        catch (Exception ex)
        {
            Console.Write(ex);
            throw;
        }
    }

    public void generateFriendliesInNeighborhood(IEnumerable<string>? friendlyList)
    {

    }
}