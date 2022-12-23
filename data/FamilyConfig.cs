using CsvHelper.Configuration;

namespace data;

internal class FamilyConfig 
{
    private string _fatherSurname ="";
    private string _motherSurname = "";

    public int HasFather {get;set;}
    public int HasMother {get;set;}
    public string FatherSurname
    {
        get => _fatherSurname;
        set => _fatherSurname = value;
    }
    public string MotherSurname
    {
        get => _motherSurname;
        set => _motherSurname = value;
    }
    public int  NoOfBrothers { get; set;}

    public int NoOfSisters { get; set;}
   
}

internal class FamilyConfigMap : ClassMap<FamilyConfig>
{
    public FamilyConfigMap()
    {
        Map(p => p.HasFather).Index(0); 
        Map(p => p.FatherSurname).Index(1);
        Map(p => p.HasMother).Index(2);
        Map(p => p.MotherSurname).Index(3);
        Map(p => p.NoOfBrothers).Index(4);
        Map(p => p.NoOfSisters).Index(5);    }
}