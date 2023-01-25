namespace parser;

partial class VapDetectionGenerator
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
}
