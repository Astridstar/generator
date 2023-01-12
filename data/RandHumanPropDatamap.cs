namespace data
{
    using CsvHelper.Configuration;
    internal class RandRecords
    {
        private string _nric = "";
        private string _email = "";
        private string _dob = "";
        private string _mobile = "";
        private string _passport = "";
        public string nric
        {
            get => _nric;
            set => _nric = value;
        }
        public string email
        {
            get => _email;
            set => _email = value;
        }
        public string dob
        {
            get => _dob;
            set => _dob = value;
        }
        public string mobile
        {
            get => _mobile;
            set => _mobile = value;
        }
        public string passport
        {
            get => _passport;
            set => _passport = value;
        }
    }

    class RandHumanPropDatamap : ClassMap<RandRecords>
    {
        public RandHumanPropDatamap()
        {
            Map(p => p.nric).Index(0);
            Map(p => p.email).Index(1);
            Map(p => p.dob).Index(2);
            Map(p => p.mobile).Index(3);
            Map(p => p.passport).Index(4);
        }
    }
}