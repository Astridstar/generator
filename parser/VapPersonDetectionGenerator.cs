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

    List<TblPersonAttributeEventRecord> _vapPersonAttributeRecords = new();
    List<FrEventDefRecord> _vapFrEventDefRecords = new();
    List<FrAlertDefRecord> _vapFrAlertDefRecords = new();


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

    public void generateCsv(string tblPersonAttributeEventCsvFilename, string frEventDefCsvFilename, string frAlertCsvFilename)
    {
        using (var writer = new StreamWriter(@tblPersonAttributeEventCsvFilename))
        {
            writer.WriteLine(VehicleRecord.getRecordHeader());
            foreach (VehicleRecord record in _vehicleHub.Values)
                writer.WriteLine(record.toCsvFormat());
        }
    }
    public void generateFriendliesInNeighborhood(IEnumerable<string>? friendlyList)
    {
        DateTimeOffset startdt = DateTimeOffset.Now.Subtract(new TimeSpan(10, 0, 0, 0));
        Dictionary<string, Guid> personVapObjectId = new();

        foreach (string nric in friendlyList)
        {
            List<StepDetails>? steps = null;
            VapObjectConfig? vapObjectConfig = null;

            _vapConfigDs.getVapObjectConfig(out vapObjectConfig, nric);
            if (vapObjectConfig == null)
            {
                Console.WriteLine("Unable to find vap object for nric {0}. Skipping", nric);
                continue;
            }
            // Generate a Guid as a reference/VAP ID for each person that was detected in VAP
            personVapObjectId[nric] = Guid.NewGuid();

            // Generate tbl_person_attribute_event records
            // Now grab those dynamic variables per detection/step in the 
            // tbl_person_attribute_event record to be generated
            // id
            // eventid
            // event_dt
            // device_id           
            generatePersonMovementRecord(vapObjectConfig, out steps, startdt);

            if (steps == null)
            {
                Console.WriteLine("No person movement defined for generation.  Unable to generate records for tbl_person_attribute_event for ID {0}", vapObjectConfig.known_id);
                return;
            }

            // Now create the tbl_person_attribute_event rows and populate
            // the record with the vapobject config parameters
            generateVapPersonRecords(steps, vapObjectConfig, personVapObjectId[nric]);
        }
    }
    private void generatePersonMovementRecord(VapObjectConfig vapObjectConfig, out List<StepDetails>? steps, DateTimeOffset startdt)
    {
        if (_personMovementDs.PersonMovementList.Count <= 0)
        {
            steps = null;
            return;
        }

        steps = new();
        for (int i = 0; i < _personMovementDs.PersonMovementList.Count; i++)
        {
            string cameraName = _personMovementDs.PersonMovementList[i].camera_name;
            string? deviceRefId = _deviceDefinitionDs.getDeviceRefId(cameraName);
            if (String.IsNullOrEmpty(deviceRefId))
            {
                Console.WriteLine("Cannot Device ID for camera with name {0}", cameraName);
                continue;
            }
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
            steps.Add(new StepDetails(UnqiueIdFactory.Instance.getNextId(),
            Guid.NewGuid().ToString(),
            startdt.AddSeconds(ConvertToDouble(_personMovementDs.PersonMovementList[i].backward_time_s)),
            deviceRefId));
        }
    }
    private void generateVapPersonRecords(List<StepDetails> steps, VapObjectConfig vapObjectConfig, Guid personVapObjectId)
    {
        foreach (StepDetails step in steps)
        {
            TblPersonAttributeEventRecord record = new();
            updatePersonAttributeEventRecord(ref record, step);
            updatePersonAttributeEventRecord(ref record, vapObjectConfig, step.eventDt);
            _vapPersonAttributeRecords.Add(record);

            // Generate fr_event
            updateFrEventDef(record, personVapObjectId);

            // Generate fr_alert
            updateFrAlertDef(record, personVapObjectId);
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
    private void updatePersonAttributeEventRecord(ref TblPersonAttributeEventRecord record, StepDetails step)
    {
        record.id = step.id.ToString();
        record.event_id = step.eventId;
        record.device_id = step.deviceId;
        record.event_dt = step.eventDt.ToString("YYYY-MM-DD hh:mm:ss");
    }
    private void updatePersonAttributeEventRecord(ref TblPersonAttributeEventRecord record, VapObjectConfig vapObjectConfig, DateTimeOffset eventdt)
    {
        // record.id = specify by StepDetails
        // record.event_id = specify by StepDetails
        record.event_type = TblPersonAttributeEventRecord.EVENT_TYPE_PERSON;
        // record.event_dt = specify by StepDetails
        record.va_provider_id = TblPersonAttributeEventRecord.VA_PROVIDER_ID;
        record.va_engine_id = TblPersonAttributeEventRecord.VA_ENGINE_ID;
        record.va_type = TblPersonAttributeEventRecord.VA_TYPE;
        // record.device_id = specify by StepDetails
        record.gender = TblPersonAttributeEventRecord.convertGender(vapObjectConfig.gender);
        record.gender_cfd = TblPersonAttributeEventRecord.getNextHighCfd();
        record.ethnicity = vapObjectConfig.ethnicity;
        record.ethnicity_cfd = (String.IsNullOrEmpty(record.ethnicity) || record.ethnicity.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.lower_age_range = vapObjectConfig.lower_age_range;
        record.lower_age_range_cfd = (String.IsNullOrEmpty(record.lower_age_range) || record.lower_age_range.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.upper_age_range = vapObjectConfig.upper_age_range;
        record.upper_age_range_cfd = (String.IsNullOrEmpty(record.upper_age_range) || record.upper_age_range.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.age_class = vapObjectConfig.age_class;
        record.age_class_cfd = (String.IsNullOrEmpty(record.age_class) || record.age_class.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.height = vapObjectConfig.height;
        record.height_cfd = (String.IsNullOrEmpty(record.height) || record.height.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.headwear_type = vapObjectConfig.headwear_type;
        record.headwear_type_cfd = (String.IsNullOrEmpty(record.headwear_type) || record.headwear_type.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.hair_style = vapObjectConfig.hair_style;
        record.hair_style_cfd = (String.IsNullOrEmpty(record.hair_style) || record.hair_style.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.hair_colour = vapObjectConfig.hair_colour;
        record.hair_colour_cfd = (String.IsNullOrEmpty(record.hair_colour) || record.hair_colour.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.hair_length = vapObjectConfig.hair_length;
        record.hair_length_cfd = (String.IsNullOrEmpty(record.hair_length) || record.hair_length.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.eyewear_type = vapObjectConfig.eyewear_type;
        record.eyewear_type_cfd = (String.IsNullOrEmpty(record.eyewear_type) || record.eyewear_type.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.eyewear_colour = vapObjectConfig.eyewear_colour;
        record.eyewear_colour_cfd = (String.IsNullOrEmpty(record.eyewear_colour) || record.eyewear_colour.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.mask_type = vapObjectConfig.mask_type;
        record.mask_type_cfd = (String.IsNullOrEmpty(record.mask_type) || record.mask_type.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.mask_colour = vapObjectConfig.mask_colour;
        record.mask_colour_cfd = (String.IsNullOrEmpty(record.mask_colour) || record.mask_colour.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.facial_hair_type = vapObjectConfig.facial_hair_type;
        record.facial_hair_type_cfd = (String.IsNullOrEmpty(record.facial_hair_type) || record.facial_hair_type.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.facial_hair_colour = vapObjectConfig.facial_hair_colour;
        record.facial_hair_colour_cfd = (String.IsNullOrEmpty(record.facial_hair_colour) || record.facial_hair_colour.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.facial_hair_length = vapObjectConfig.facial_hair_length;
        record.facial_hair_length_cfd = (String.IsNullOrEmpty(record.facial_hair_length) || record.facial_hair_length.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.skin_colour = vapObjectConfig.skin_colour;
        record.skin_colour_cfd = (String.IsNullOrEmpty(record.skin_colour) || record.skin_colour.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.topwear_type = vapObjectConfig.topwear_type;
        record.topwear_type_cfd = (String.IsNullOrEmpty(record.topwear_type) || record.topwear_type.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.topwear_pattern = vapObjectConfig.topwear_pattern;
        record.topwear_pattern_cfd = (String.IsNullOrEmpty(record.topwear_pattern) || record.topwear_pattern.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.topwear_colour = vapObjectConfig.topwear_colour;
        record.topwear_colour_cfd = (String.IsNullOrEmpty(record.topwear_colour) || record.topwear_colour.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.sleeve_colour = vapObjectConfig.sleeve_colour;
        record.sleeve_colour_cfd = (String.IsNullOrEmpty(record.sleeve_colour) || record.sleeve_colour.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.sleeve_length = vapObjectConfig.sleeve_length;
        record.sleeve_length_cfd = (String.IsNullOrEmpty(record.sleeve_length) || record.sleeve_length.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.outerwear_type = vapObjectConfig.outerwear_type;
        record.outerwear_type_cfd = (String.IsNullOrEmpty(record.outerwear_type) || record.outerwear_type.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.outerwear_pattern = vapObjectConfig.outerwear_pattern;
        record.outerwear_pattern_cfd = (String.IsNullOrEmpty(record.outerwear_pattern) || record.outerwear_pattern.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.outerwear_colour = vapObjectConfig.outerwear_colour;
        record.outerwear_colour_cfd = (String.IsNullOrEmpty(record.outerwear_colour) || record.outerwear_colour.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.outerwear_length = vapObjectConfig.outerwear_length;
        record.outerwear_length_cfd = (String.IsNullOrEmpty(record.outerwear_length) || record.outerwear_length.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.necktie_type = vapObjectConfig.necktie_type;
        record.necktie_type_cfd = (String.IsNullOrEmpty(record.necktie_type) || record.necktie_type.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.necktie_pattern = vapObjectConfig.necktie_pattern;
        record.necktie_pattern_cfd = (String.IsNullOrEmpty(record.necktie_pattern) || record.necktie_pattern.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.necktie_colour = vapObjectConfig.necktie_colour;
        record.necktie_colour_cfd = (String.IsNullOrEmpty(record.necktie_colour) || record.necktie_colour.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.bottomwear_type = vapObjectConfig.bottomwear_type;
        record.bottomwear_type_cfd = (String.IsNullOrEmpty(record.bottomwear_type) || record.bottomwear_type.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.bottomwear_pattern = vapObjectConfig.bottomwear_pattern;
        record.bottomwear_pattern_cfd = (String.IsNullOrEmpty(record.bottomwear_pattern) || record.bottomwear_pattern.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.bottomwear_colour = vapObjectConfig.bottomwear_colour;
        record.bottomwear_colour_cfd = (String.IsNullOrEmpty(record.bottomwear_colour) || record.bottomwear_colour.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.bottomwear_length = vapObjectConfig.bottomwear_length;
        record.bottomwear_length_cfd = (String.IsNullOrEmpty(record.bottomwear_length) || record.bottomwear_length.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.footwear_type = vapObjectConfig.footwear_type;
        record.footwear_type_cfd = (String.IsNullOrEmpty(record.footwear_type) || record.footwear_type.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.footwear_pattern = vapObjectConfig.footwear_pattern;
        record.footwear_pattern_cfd = (String.IsNullOrEmpty(record.footwear_pattern) || record.footwear_pattern.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.footwear_colour = vapObjectConfig.footwear_colour;
        record.footwear_colour_cfd = (String.IsNullOrEmpty(record.footwear_colour) || record.footwear_colour.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.bag_type = vapObjectConfig.bag_type;
        record.bag_type_cfd = (String.IsNullOrEmpty(record.bag_type) || record.bag_type.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.bag_colour = vapObjectConfig.bag_colour;
        record.bag_colour_cfd = (String.IsNullOrEmpty(record.bag_colour) || record.bag_colour.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.uniform = vapObjectConfig.uniform;
        record.uniform_cfd = (String.IsNullOrEmpty(record.uniform) || record.uniform.CompareTo("0") == 0) ? "0" : TblPersonAttributeEventRecord.getNextHighCfd();
        record.full_image_url = TblPersonAttributeEventRecord.generateFullImageUrlPrefix(eventdt, record.event_id, record.va_provider_id);
        record.cropped_image_url = TblPersonAttributeEventRecord.generateCroppedImageUrlPrefix(eventdt, record.event_id, record.va_provider_id);
        record.bbox_x1 = TblPersonAttributeEventRecord.BBOX_X1;
        record.bbox_y1 = TblPersonAttributeEventRecord.BBOX_Y1;
        record.bbox_x2 = TblPersonAttributeEventRecord.BBOX_X2;
        record.bbox_y2 = TblPersonAttributeEventRecord.BBOX_Y2;
    }

    private void updateFrEventDef(TblPersonAttributeEventRecord record, Guid personVapObjectId)
    {
        FrEventDefRecord eventDef = new();
        eventDef.id = FrEventDefRecord.getNextId().ToString();
        eventDef.event_id = record.event_id;
        eventDef.event_type = FrEventDefRecord.EVENT_TYPE_PERSON;
        eventDef.event_dt = record.event_dt;
        eventDef.va_engine_id = record.va_engine_id;
        eventDef.va_type = FrEventDefRecord.VA_TYPE_PERSON;
        eventDef.device_id = record.device_id;
        eventDef.full_image_url = record.full_image_url;
        eventDef.cropped_image_url = record.cropped_image_url;
        eventDef.bbox_x1 = record.bbox_x1;
        eventDef.bbox_y1 = record.bbox_y1;
        eventDef.bbox_x2 = record.bbox_x2;
        eventDef.bbox_y2 = record.bbox_y2;
        eventDef.vap_object_id = personVapObjectId.ToString();
        _vapFrEventDefRecords.Add(eventDef);
    }

    private void updateFrAlertDef(TblPersonAttributeEventRecord record, Guid personVapObjectId)
    {
        FrAlertDefRecord alertDefRecord = new();
        alertDefRecord.id = "";
        alertDefRecord.fr_event_id = "";
        alertDefRecord.fr_alert_dt = "";
        alertDefRecord.va_engine_id = "";
        alertDefRecord.person_id = "";
        alertDefRecord.score = "";
        alertDefRecord.info = "";
        alertDefRecord.key = "";
        alertDefRecord.vap_object_id = personVapObjectId.ToString();
        _vapFrAlertDefRecords.Add(alertDefRecord);
    }
}
