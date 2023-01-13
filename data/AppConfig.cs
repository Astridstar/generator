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
        private string _randHumanPropDataset = "";
        private string _countriesCsv = "";
        private List<string> _addressesJsonFiles = new();
        private string _scenarioCsv = "";
        private string _vehicleMakeModelCsv = "";
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

        public List<string> AddressesJsonFiles
        {
            get => _addressesJsonFiles;
            set => _addressesJsonFiles = value;
        }

        public string RandHumanPropCsv
        {
            get => _randHumanPropDataset;
            set => _randHumanPropDataset = value;
        }

        public string CountriesCsv
        {
            get => _countriesCsv;
            set => _countriesCsv = value;
        }

        public string AddressesJsonFile
        {
            get => _addressesJsonFile;
            set => _addressesJsonFile = value;
        }

        public string ScenarioCsv
        {
            get => _scenarioCsv;
            set => _scenarioCsv = value;
        }
        public string VehicleMakeModelCsv
        {
            get => _vehicleMakeModelCsv;
            set => _vehicleMakeModelCsv = value;
        }
        public AppConfig()
        {

        }
    }
}

