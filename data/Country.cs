using CsvHelper.Configuration;

namespace data
{
    internal class Country
    {
        private string _country = "";

        public string country
        {
            get => _country;
            set => _country = value;
        }
    }

    internal class CountryMap : ClassMap<Country>
    {
        public CountryMap()
        {
            Map(p => p.country).Index(0);
        }
    }
}
