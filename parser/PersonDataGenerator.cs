namespace parser;

using System.Text;
using data;
using records;

class PersonDataGenerator : RandomGenerator
{
    AddressesParser _addressParser;
    RandHumanPropDataset _randHumanPropDs;
    CountryDataset _countryDs;
    PersonNamesDataset _personDataset;

    enum CITIZENSHIP
    {
        Singaporean, PR, Expatriat
    }
    enum MARITAL
    {
        Single, Married
    }

    public PersonDataGenerator(AddressesParser addressParser,
                                RandHumanPropDataset randHumanPropDs,
                                CountryDataset countryDs,
                                PersonNamesDataset personDataset)
    {
        _addressParser = addressParser;
        _randHumanPropDs = randHumanPropDs;
        _countryDs = countryDs;
        _personDataset = personDataset;
    }
    public void generateRandomPerson(out PersonRecord? person)
    {
        person = new();

        string name = "";
        string gender = "";
        _personDataset.getRandomAvailableNameAndGender(out name, out gender);
        person.fullname = name;
        person.gender = gender;
        person.email1 = _randHumanPropDs.getNextEmail();
        person.email2 = "";
        person.salutation = "";
        person.birthday = _randHumanPropDs.getNextDob();
        person.mobile = _randHumanPropDs.getNextMobileNumber();
        person.phone2 = "";
        person.fax = "";
        person.id = _randHumanPropDs.getNextNric();

        string addr = "";
        string postal = "";
        _addressParser.getNextAddress(out addr, out postal);

        person.address1 = addr;
        person.address2 = "";
        person.postcode = postal;
        person.citizenship = getRandomCitizenship();


        person.nationality = getNationality(person.citizenship);
        person.company = "";
        person.company_id = "";
        person.car_plate = "";
        person.deceased = "n";
        person.marital = nameof(MARITAL.Single);
        person.father_id = "";
        person.mother_id = "";
        person.spouse_id = "";
        person.sibling1_id = "";
        person.sibling2_id = "";
        person.sibling3_id = "";
        person.child1_id = "";
        person.child2_id = "";
        person.child3_id = "";
    }

    private string getNationality(string citizenship)
    {
        if (String.IsNullOrEmpty(citizenship))
            return "Singapore";

        return citizenship.CompareTo(nameof(CITIZENSHIP.Expatriat)) == 0 ? getRandomCounty() : "Singapore";
    }

    private string getRandomCitizenship()
    {
        int dice = randomNumber(0, 2);
        switch (dice)
        {
            case 1:
                return nameof(CITIZENSHIP.PR);
            case 2:
                return nameof(CITIZENSHIP.Expatriat);
            default:
                return nameof(CITIZENSHIP.Singaporean);
        }
    }

    private string getRandomCounty()
    {
        int max = _countryDs.getMaxCountryRecord();

        if (max <= 0) return "";

        int dice = randomNumber(0, max - 1);
        return _countryDs.ElementAt(dice);
    }
}