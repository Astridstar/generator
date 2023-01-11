namespace configurations
{
    internal class AppConfig
    {
        private string _environment = "";
        private string _chineseNamesCsv = "";
        private string _indianNamesCsv = "";
        private string _malayNamesCsv = "";
        private string _familySettingsCsv = "";
        private string _addressesJsonFile = "";

        public string Environment
        {
            get => _environment;
            set => _environment = value;
        }
        public string ChineseNamesCsv
        {
            get => _chineseNamesCsv;
            set => _chineseNamesCsv = value;
        }
        public string IndianNamesCsv
        {
            get => _indianNamesCsv;
            set => _indianNamesCsv = value;
        }
        public string MalayNamesCsv
        {
            get => _malayNamesCsv;
            set => _malayNamesCsv = value;
        }
        public string FamilySettingsCsv
        {
            get => _familySettingsCsv;
            set => _familySettingsCsv = value;
        }

        public string AddressesJsonFile
        {
            get => _addressesJsonFile;
            set => _addressesJsonFile = value;
        }

        public AppConfig()
        {

        }
    }
}

