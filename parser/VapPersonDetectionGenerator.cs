namespace parser;

using CsvHelper;
using data;
using records;
class VapPersonDetectionGenerator
{
    // id
    // eventid
    // event_dt
    // device_id
    internal protected class StepDetails
    {
        public long id { get; set; }
        public string eventId { get; set; }
        public DateTimeOffset eventDt { get; set; }
        public string deviceId { get; set; }

        public StepDetails(long id, string eventId, DateTimeOffset eventDt, string deviceId)
        {
            this.id = id;
            this.eventId = eventId;
            this.eventDt = eventDt;
            this.deviceId = deviceId;
        }
    }

    VapObjectConfigDataset _vapConfigDs = new();
    PersonMovementDataset _personMovementDs = new();
    DeviceDefinitionDataset _deviceDefinitionDs = new();

    List<TblPersonAttributeEventRecord> _vapPersonRecords = new();

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
        DateTimeOffset startdt = DateTimeOffset.Now.Subtract(new TimeSpan(10, 0, 0, 0));
        Dictionary<string, Guid> personVapObjectId = new();
        foreach (string nric in friendlyList)
        {
            VapObjectConfig vapObjectConfig = null;
            _vapConfigDs.getVapObjectConfig(out vapObjectConfig, nric);
            if (vapObjectConfig == null)
            {
                Console.WriteLine("Unable to find vap object for nric {0}. Skipping", nric);
                continue;
            }

            personVapObjectId[nric] = Guid.NewGuid();
            generateRecord(vapObjectConfig, startdt);
        }
    }

    private void generateRecord(VapObjectConfig vapObjectConfig, DateTimeOffset startdt)
    {
        List<StepDetails> steps = new();
        for (int i = 0; i < _personMovementDs.PersonMovementList.Count; i++)
        {
            string cameraName = _personMovementDs.PersonMovementList[i].camera_name;
            string? deviceRefId = _deviceDefinitionDs.getDeviceRefId(cameraName);
            if (String.IsNullOrEmpty(deviceRefId))
            {
                Console.WriteLine("Cannot Device ID for camera with name {0}", cameraName);
                continue;
            }
            // id
            // eventid
            // event_dt
            // device_id
            steps.Add(new StepDetails(UnqiueIdFactory.Instance.getNextId(),
            Guid.NewGuid().ToString(),
            startdt.AddSeconds(ConvertToDouble(_personMovementDs.PersonMovementList[i].forward_time_s)),
            deviceRefId));
        }

        startdt = startdt.AddHours(2);
        for (int i = _personMovementDs.PersonMovementList.Count - 1; i >= 0; i--)
        {
            string cameraName = _personMovementDs.PersonMovementList[i].camera_name;
            string? deviceRefId = _deviceDefinitionDs.getDeviceRefId(cameraName);
            if (String.IsNullOrEmpty(deviceRefId))
            {
                Console.WriteLine("Cannot Device ID for camera with name {0}", cameraName);
                continue;
            }
            // id
            // eventid
            // event_dt
            // device_id
            steps.Add(new StepDetails(UnqiueIdFactory.Instance.getNextId(),
            Guid.NewGuid().ToString(),
            startdt.AddSeconds(ConvertToDouble(_personMovementDs.PersonMovementList[i].backward_time_s)),
            deviceRefId));
        }
    }

    public static double ConvertToDouble(string Value)
    {
        if (Value == null)
        {
            return 0;
        }
        else
        {
            double OutVal;
            double.TryParse(Value, out OutVal);

            if (double.IsNaN(OutVal) || double.IsInfinity(OutVal))
            {
                return 0;
            }
            return OutVal;
        }
    }
}