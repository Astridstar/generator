namespace data;

using CsvHelper.Configuration;

class ScenarioPersonRecord
{
    string _sn = "";
    string _description = "";
    string _fullname = "";
    string _id = "";
    string _vehicle_plate = "";
    string _gender = "";
    string _race = "";
    string _friendly = "";
    string _blacklisted = "";
    string _deceased = "";
    string _address = "";
    string _postal = "";
    string _dob = "";
    string _nationality = "";
    string _citizenship = "";
    string _employer = "";
    string _business_partner = "";
    string _marital = "";
    string _father = "";
    string _mother = "";
    string _spouse = "";
    string _siblings = "";
    string _sib1 = "";
    string _sib2 = "";
    string _sib3 = "";
    string _children = "";
    string _child1 = "";
    string _child2 = "";
    string _child3 = "";

    public string sn
    {
        get => _sn;
        set => _sn = value;
    }
    public string description
    {
        get => _description;
        set => _description = value;
    }
    public string fullname
    {
        get => _fullname;
        set => _fullname = value;
    }
    public string id
    {
        get => _id;
        set => _id = value;
    }
    public string vehicle_plate
    {
        get => _vehicle_plate;
        set => _vehicle_plate = value;
    }
    public string gender
    {
        get => _gender;
        set => _gender = value;
    }
    public string race
    {
        get => _race;
        set => _race = value;
    }
    public string friendly
    {
        get => _friendly;
        set => _friendly = value;
    }
    public string blacklisted
    {
        get => _blacklisted;
        set => _blacklisted = value;
    }
    public string deceased
    {
        get => _deceased;
        set => _deceased = value;
    }
    public string address
    {
        get => _address;
        set => _address = value;
    }
    public string postal
    {
        get => _postal;
        set => _postal = value;
    }
    public string dob
    {
        get => _dob;
        set => _dob = value;
    }
    public string nationality
    {
        get => _nationality;
        set => _nationality = value;
    }
    public string citizenship
    {
        get => _citizenship;
        set => _citizenship = value;
    }
    public string employer
    {
        get => _employer;
        set => _employer = value;
    }
    public string business_partner
    {
        get => _business_partner;
        set => _business_partner = value;
    }
    public string marital
    {
        get => _marital;
        set => _marital = value;
    }
    public string father
    {
        get => _father;
        set => _father = value;
    }
    public string mother
    {
        get => _mother;
        set => _mother = value;
    }
    public string spouse
    {
        get => _spouse;
        set => _spouse = value;
    }
    public string siblings
    {
        get => _siblings;
        set => _siblings = value;
    }
    public string sib1
    {
        get => _sib1;
        set => _sib1 = value;
    }
    public string sib2
    {
        get => _sib2;
        set => _sib2 = value;
    }
    public string sib3
    {
        get => _sib3;
        set => _sib3 = value;
    }
    public string children
    {
        get => _children;
        set => _children = value;
    }
    public string child1
    {
        get => _child1;
        set => _child1 = value;
    }
    public string child2
    {
        get => _child2;
        set => _child2 = value;
    }
    public string child3
    {
        get => _child3;
        set => _child3 = value;
    }
}

class ScenarioPersonRecordDatamap : ClassMap<ScenarioPersonRecord>
{
    public ScenarioPersonRecordDatamap()
    {
        Map(p => p.sn).Index(0);
        Map(p => p.description).Index(1);
        Map(p => p.fullname).Index(2);
        Map(p => p.id).Index(3);
        Map(p => p.vehicle_plate).Index(4);
        Map(p => p.gender).Index(5);
        Map(p => p.race).Index(6);
        Map(p => p.friendly).Index(7);
        Map(p => p.blacklisted).Index(8);
        Map(p => p.deceased).Index(9);
        Map(p => p.address).Index(10);
        Map(p => p.postal).Index(11);
        Map(p => p.dob).Index(12);
        Map(p => p.nationality).Index(13);
        Map(p => p.citizenship).Index(14);
        Map(p => p.employer).Index(15);
        Map(p => p.business_partner).Index(16);
        Map(p => p.marital).Index(17);
        Map(p => p.father).Index(18);
        Map(p => p.mother).Index(19);
        Map(p => p.spouse).Index(20);
        Map(p => p.siblings).Index(21);
        Map(p => p.sib1).Index(22);
        Map(p => p.sib2).Index(23);
        Map(p => p.sib3).Index(24);
        Map(p => p.children).Index(25);
        Map(p => p.child1).Index(26);
        Map(p => p.child2).Index(27);
        Map(p => p.child3).Index(28);
    }
}