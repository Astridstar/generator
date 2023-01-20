namespace data;

using CsvHelper.Configuration;

class VapObjectConfig
{
    protected string _known_id = "";
    protected string _is_known = "";
    protected string _gender = "";
    protected string _ethnicity = "";
    protected string _lower_age_range = "";
    protected string _upper_age_range = "";
    protected string _age_class = "";
    protected string _height = "";
    protected string _headwear_type = "";
    protected string _hair_style = "";
    protected string _hair_colour = "";
    protected string _hair_length = "";
    protected string _eyewear_type = "";
    protected string _eyewear_colour = "";
    protected string _mask_type = "";
    protected string _mask_colour = "";
    protected string _facial_hair_type = "";
    protected string _facial_hair_colour = "";
    protected string _facial_hair_length = "";
    protected string _skin_colour = "";
    protected string _topwear_type = "";
    protected string _topwear_pattern = "";
    protected string _topwear_colour = "";
    protected string _sleeve_colour = "";
    protected string _sleeve_length = "";
    protected string _outerwear_type = "";
    protected string _outerwear_pattern = "";
    protected string _outerwear_colour = "";
    protected string _outerwear_length = "";
    protected string _necktie_type = "";
    protected string _necktie_pattern = "";
    protected string _necktie_colour = "";
    protected string _bottomwear_type = "";
    protected string _bottomwear_pattern = "";
    protected string _bottomwear_colour = "";
    protected string _bottomwear_length = "";
    protected string _footwear_type = "";
    protected string _footwear_pattern = "";
    protected string _footwear_colour = "";
    protected string _bag_type = "";
    protected string _bag_colour = "";
    protected string _uniform = "";

    public string known_id
    {
        get => _known_id;
        set => _known_id = value;
    }
    public string is_known
    {
        get => _is_known;
        set => _is_known = value;
    }
    public string gender
    {
        get => _gender;
        set => _gender = value;
    }
    public string ethnicity
    {
        get => _ethnicity;
        set => _ethnicity = value;
    }
    public string lower_age_range
    {
        get => _lower_age_range;
        set => _lower_age_range = value;
    }
    public string upper_age_range
    {
        get => _upper_age_range;
        set => _upper_age_range = value;
    }
    public string age_class
    {
        get => _age_class;
        set => _age_class = value;
    }
    public string height
    {
        get => _height;
        set => _height = value;
    }
    public string headwear_type
    {
        get => _headwear_type;
        set => _headwear_type = value;
    }
    public string hair_style
    {
        get => _hair_style;
        set => _hair_style = value;
    }
    public string hair_colour
    {
        get => _hair_colour;
        set => _hair_colour = value;
    }
    public string hair_length
    {
        get => _hair_length;
        set => _hair_length = value;
    }
    public string eyewear_type
    {
        get => _eyewear_type;
        set => _eyewear_type = value;
    }
    public string eyewear_colour
    {
        get => _eyewear_colour;
        set => _eyewear_colour = value;
    }
    public string mask_type
    {
        get => _mask_type;
        set => _mask_type = value;
    }
    public string mask_colour
    {
        get => _mask_colour;
        set => _mask_colour = value;
    }
    public string facial_hair_type
    {
        get => _facial_hair_type;
        set => _facial_hair_type = value;
    }
    public string facial_hair_colour
    {
        get => _facial_hair_colour;
        set => _facial_hair_colour = value;
    }
    public string facial_hair_length
    {
        get => _facial_hair_length;
        set => _facial_hair_length = value;
    }
    public string skin_colour
    {
        get => _skin_colour;
        set => _skin_colour = value;
    }
    public string topwear_type
    {
        get => _topwear_type;
        set => _topwear_type = value;
    }
    public string topwear_pattern
    {
        get => _topwear_pattern;
        set => _topwear_pattern = value;
    }
    public string topwear_colour
    {
        get => _topwear_colour;
        set => _topwear_colour = value;
    }
    public string sleeve_colour
    {
        get => _sleeve_colour;
        set => _sleeve_colour = value;
    }
    public string sleeve_length
    {
        get => _sleeve_length;
        set => _sleeve_length = value;
    }
    public string outerwear_type
    {
        get => _outerwear_type;
        set => _outerwear_type = value;
    }
    public string outerwear_pattern
    {
        get => _outerwear_pattern;
        set => _outerwear_pattern = value;
    }
    public string outerwear_colour
    {
        get => _outerwear_colour;
        set => _outerwear_colour = value;
    }
    public string outerwear_length
    {
        get => _outerwear_length;
        set => _outerwear_length = value;
    }
    public string necktie_type
    {
        get => _necktie_type;
        set => _necktie_type = value;
    }
    public string necktie_pattern
    {
        get => _necktie_pattern;
        set => _necktie_pattern = value;
    }
    public string necktie_colour
    {
        get => _necktie_colour;
        set => _necktie_colour = value;
    }
    public string bottomwear_type
    {
        get => _bottomwear_type;
        set => _bottomwear_type = value;
    }
    public string bottomwear_pattern
    {
        get => _bottomwear_pattern;
        set => _bottomwear_pattern = value;
    }
    public string bottomwear_colour
    {
        get => _bottomwear_colour;
        set => _bottomwear_colour = value;
    }
    public string bottomwear_length
    {
        get => _bottomwear_length;
        set => _bottomwear_length = value;
    }
    public string footwear_type
    {
        get => _footwear_type;
        set => _footwear_type = value;
    }
    public string footwear_pattern
    {
        get => _footwear_pattern;
        set => _footwear_pattern = value;
    }
    public string footwear_colour
    {
        get => _footwear_colour;
        set => _footwear_colour = value;
    }
    public string bag_type
    {
        get => _bag_type;
        set => _bag_type = value;
    }
    public string bag_colour
    {
        get => _bag_colour;
        set => _bag_colour = value;
    }
    public string uniform
    {
        get => _uniform;
        set => _uniform = value;
    }
}


internal class VapObjectConfigDatamap : ClassMap<VapObjectConfig>
{
    public VapObjectConfigDatamap()
    {
        Map(p => p.known_id).Index(0);
        Map(p => p.is_known).Index(1);
        Map(p => p.gender).Index(2);
        Map(p => p.ethnicity).Index(3);
        Map(p => p.lower_age_range).Index(4);
        Map(p => p.upper_age_range).Index(5);
        Map(p => p.age_class).Index(6);
        Map(p => p.height).Index(7);
        Map(p => p.headwear_type).Index(8);
        Map(p => p.hair_style).Index(9);

        Map(p => p.hair_colour).Index(10);
        Map(p => p.hair_length).Index(11);
        Map(p => p.eyewear_type).Index(12);
        Map(p => p.eyewear_colour).Index(13);
        Map(p => p.mask_type).Index(14);
        Map(p => p.mask_colour).Index(15);
        Map(p => p.facial_hair_type).Index(16);
        Map(p => p.facial_hair_colour).Index(17);
        Map(p => p.facial_hair_length).Index(18);
        Map(p => p.skin_colour).Index(19);

        Map(p => p.topwear_type).Index(20);
        Map(p => p.topwear_pattern).Index(21);
        Map(p => p.topwear_colour).Index(22);
        Map(p => p.sleeve_colour).Index(23);
        Map(p => p.sleeve_length).Index(24);
        Map(p => p.outerwear_type).Index(25);
        Map(p => p.outerwear_pattern).Index(26);
        Map(p => p.outerwear_colour).Index(27);
        Map(p => p.outerwear_length).Index(28);
        Map(p => p.necktie_type).Index(29);

        Map(p => p.necktie_pattern).Index(30);
        Map(p => p.necktie_colour).Index(31);
        Map(p => p.bottomwear_type).Index(32);
        Map(p => p.bottomwear_pattern).Index(33);
        Map(p => p.bottomwear_colour).Index(34);
        Map(p => p.bottomwear_length).Index(35);
        Map(p => p.footwear_type).Index(36);
        Map(p => p.footwear_pattern).Index(37);
        Map(p => p.footwear_colour).Index(38);
        Map(p => p.bag_type).Index(39);

        Map(p => p.bag_colour).Index(40);
        Map(p => p.uniform).Index(41);

    }
}