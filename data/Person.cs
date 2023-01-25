using CsvHelper.Configuration;

namespace data
{
    internal class PersonName
    {

        private string _surname = "";
        private string _name = "";
        private string _fullname = "";
        private string _gender = "";
        private bool _isAvailable = true;

        public string Surname
        {
            get => _surname;
            set => _surname = value;
        }
        public string Name
        {
            get => _name;
            set => _name = value;
        }
        public string Fullname
        {
            get => _fullname;
            set => _fullname = value;
        }
        public string Gender
        {
            get => _gender;
            set => _gender = value;
        }

        public bool IsAvailable
        {
            get => _isAvailable;
            set => _isAvailable = value;
        }
    }

    internal class PersonMap : ClassMap<PersonName>
    {
        public PersonMap()
        {
            Map(p => p.Surname).Index(0);
            Map(p => p.Name).Index(1);
            Map(p => p.Fullname).Index(2);
            Map(p => p.Gender).Index(3);
        }
    }
}