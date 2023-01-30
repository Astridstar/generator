namespace records;

using System.Text;
using CsvHelper.Configuration;

class AcraInformationData
{
    #region accessors & modifiers
    public string issuance_agency_id { get; set; }
    public string uen { get; set; }
    public string entity_name { get; set; }
    public string entity_type_description { get; set; }
    public string business_constitution_description { get; set; }
    public string company_type_description { get; set; }
    public string paf_constitution_description { get; set; }
    public string entity_status_description { get; set; }
    public string registration_incorporation_date { get; set; }
    public string uen_issue_date { get; set; }
    public string address_type { get; set; }
    public string block { get; set; }
    public string street_name { get; set; }
    public string level_no { get; set; }
    public string unit_no { get; set; }
    public string building_name { get; set; }
    public string postal_code { get; set; }
    public string other_address_line1 { get; set; }
    public string other_address_line2 { get; set; }
    public string account_due_date { get; set; }
    public string annual_return_date { get; set; }
    public string no_of_charges { get; set; }
    public string primary_ssic_code { get; set; }
    public string primary_ssic_description { get; set; }
    public string primary_user_described_activity { get; set; }
    public string secondary_ssic_code { get; set; }
    public string secondary_ssic_description { get; set; }
    public string secondary_user_described_activity { get; set; }
    public string no_of_officers { get; set; }
    public string former_entity_name1 { get; set; }
    public string former_entity_name2 { get; set; }
    public string former_entity_name3 { get; set; }
    public string former_entity_name4 { get; set; }
    public string former_entity_name5 { get; set; }
    public string former_entity_name6 { get; set; }
    public string former_entity_name7 { get; set; }
    public string former_entity_name8 { get; set; }
    public string former_entity_name9 { get; set; }
    public string former_entity_name10 { get; set; }
    public string former_entity_name11 { get; set; }
    public string former_entity_name12 { get; set; }
    public string former_entity_name13 { get; set; }
    public string former_entity_name14 { get; set; }
    public string former_entity_name15 { get; set; }
    public string paid_up_capital1_currency { get; set; }
    public string paid_up_capital1_ordinary { get; set; }
    public string paid_up_capital1_preference { get; set; }
    public string paid_up_capital1_others { get; set; }
    public string paid_up_capital2_currency { get; set; }
    public string paid_up_capital2_ordinary { get; set; }
    public string paid_up_capital2_preference { get; set; }
    public string paid_up_capital2_others { get; set; }
    public string paid_up_capital3_currency { get; set; }
    public string paid_up_capital3_ordinary { get; set; }
    public string paid_up_capital3_preference { get; set; }
    public string paid_up_capital3_others { get; set; }
    public string paid_up_capital4_currency { get; set; }
    public string paid_up_capital4_ordinary { get; set; }
    public string paid_up_capital4_preference { get; set; }
    public string paid_up_capital4_others { get; set; }
    public string paid_up_capital5_currency { get; set; }
    public string paid_up_capital5_ordinary { get; set; }
    public string paid_up_capital5_preference { get; set; }
    public string paid_up_capital5_others { get; set; }
    public string paid_up_capital6_currency { get; set; }
    public string paid_up_capital6_ordinary { get; set; }
    public string paid_up_capital6_preference { get; set; }
    public string paid_up_capital6_others { get; set; }
    public string paid_up_capital7_currency { get; set; }
    public string paid_up_capital7_ordinary { get; set; }
    public string paid_up_capital7_preference { get; set; }
    public string paid_up_capital7_others { get; set; }
    public string paid_up_capital8_currency { get; set; }
    public string paid_up_capital8_ordinary { get; set; }
    public string paid_up_capital8_preference { get; set; }
    public string paid_up_capital8_others { get; set; }
    public string paid_up_capital9_currency { get; set; }
    public string paid_up_capital9_ordinary { get; set; }
    public string paid_up_capital9_preference { get; set; }
    public string paid_up_capital9_others { get; set; }
    public string paid_up_capital10_currency { get; set; }
    public string paid_up_capital10_ordinary { get; set; }
    public string paid_up_capital10_preference { get; set; }
    public string paid_up_capital10_others { get; set; }
    public string uen_of_audit_firm1 { get; set; }
    public string name_of_audit_firm1 { get; set; }
    public string uen_of_audit_firm2 { get; set; }
    public string name_of_audit_firm2 { get; set; }
    public string uen_of_audit_firm3 { get; set; }
    public string name_of_audit_firm3 { get; set; }
    public string uen_of_audit_firm4 { get; set; }
    public string name_of_audit_firm4 { get; set; }
    public string uen_of_audit_firm5 { get; set; }
    public string name_of_audit_firm5 { get; set; }
    #endregion

    public AcraInformationData()
    {
        #region Initialization of parameters in constructor
        issuance_agency_id = "";
        uen = "";
        entity_name = "";
        entity_type_description = "";
        business_constitution_description = "";
        company_type_description = "";
        paf_constitution_description = "";
        entity_status_description = "";
        registration_incorporation_date = "";
        uen_issue_date = "";
        address_type = "";
        block = "";
        street_name = "";
        level_no = "";
        unit_no = "";
        building_name = "";
        postal_code = "";
        other_address_line1 = "";
        other_address_line2 = "";
        account_due_date = "";
        annual_return_date = "";
        no_of_charges = "";
        primary_ssic_code = "";
        primary_ssic_description = "";
        primary_user_described_activity = "";
        secondary_ssic_code = "";
        secondary_ssic_description = "";
        secondary_user_described_activity = "";
        no_of_officers = "";
        former_entity_name1 = "";
        former_entity_name2 = "";
        former_entity_name3 = "";
        former_entity_name4 = "";
        former_entity_name5 = "";
        former_entity_name6 = "";
        former_entity_name7 = "";
        former_entity_name8 = "";
        former_entity_name9 = "";
        former_entity_name10 = "";
        former_entity_name11 = "";
        former_entity_name12 = "";
        former_entity_name13 = "";
        former_entity_name14 = "";
        former_entity_name15 = "";
        paid_up_capital1_currency = "";
        paid_up_capital1_ordinary = "";
        paid_up_capital1_preference = "";
        paid_up_capital1_others = "";
        paid_up_capital2_currency = "";
        paid_up_capital2_ordinary = "";
        paid_up_capital2_preference = "";
        paid_up_capital2_others = "";
        paid_up_capital3_currency = "";
        paid_up_capital3_ordinary = "";
        paid_up_capital3_preference = "";
        paid_up_capital3_others = "";
        paid_up_capital4_currency = "";
        paid_up_capital4_ordinary = "";
        paid_up_capital4_preference = "";
        paid_up_capital4_others = "";
        paid_up_capital5_currency = "";
        paid_up_capital5_ordinary = "";
        paid_up_capital5_preference = "";
        paid_up_capital5_others = "";
        paid_up_capital6_currency = "";
        paid_up_capital6_ordinary = "";
        paid_up_capital6_preference = "";
        paid_up_capital6_others = "";
        paid_up_capital7_currency = "";
        paid_up_capital7_ordinary = "";
        paid_up_capital7_preference = "";
        paid_up_capital7_others = "";
        paid_up_capital8_currency = "";
        paid_up_capital8_ordinary = "";
        paid_up_capital8_preference = "";
        paid_up_capital8_others = "";
        paid_up_capital9_currency = "";
        paid_up_capital9_ordinary = "";
        paid_up_capital9_preference = "";
        paid_up_capital9_others = "";
        paid_up_capital10_currency = "";
        paid_up_capital10_ordinary = "";
        paid_up_capital10_preference = "";
        paid_up_capital10_others = "";
        uen_of_audit_firm1 = "";
        name_of_audit_firm1 = "";
        uen_of_audit_firm2 = "";
        name_of_audit_firm2 = "";
        uen_of_audit_firm3 = "";
        name_of_audit_firm3 = "";
        uen_of_audit_firm4 = "";
        name_of_audit_firm4 = "";
        uen_of_audit_firm5 = "";
        name_of_audit_firm5 = "";

        #endregion
    }
    public static string getRecordHeader()
    {
        return "";
    }

    public string toCsvFormat()
    {
        return "";
    }
}

class AcraInformationDatamap : ClassMap<AcraInformationData>
{
    public AcraInformationDatamap()
    {
        Map(p => p.issuance_agency_id).Index(0);
        Map(p => p.uen).Index(1);
        Map(p => p.entity_name).Index(2);
        Map(p => p.entity_type_description).Index(3);
        Map(p => p.business_constitution_description).Index(4);
        Map(p => p.company_type_description).Index(5);
        Map(p => p.paf_constitution_description).Index(6);
        Map(p => p.entity_status_description).Index(7);
        Map(p => p.registration_incorporation_date).Index(8);
        Map(p => p.uen_issue_date).Index(9);
        Map(p => p.address_type).Index(10);
        Map(p => p.block).Index(11);
        Map(p => p.street_name).Index(12);
        Map(p => p.level_no).Index(13);
        Map(p => p.unit_no).Index(14);
        Map(p => p.building_name).Index(15);
        Map(p => p.postal_code).Index(16);
        Map(p => p.other_address_line1).Index(17);
        Map(p => p.other_address_line2).Index(18);
        Map(p => p.account_due_date).Index(19);
        Map(p => p.annual_return_date).Index(20);
        Map(p => p.no_of_charges).Index(21);
        Map(p => p.primary_ssic_code).Index(22);
        Map(p => p.primary_ssic_description).Index(23);
        Map(p => p.primary_user_described_activity).Index(24);
        Map(p => p.secondary_ssic_code).Index(25);
        Map(p => p.secondary_ssic_description).Index(26);
        Map(p => p.secondary_user_described_activity).Index(27);
        Map(p => p.no_of_officers).Index(28);
        Map(p => p.former_entity_name1).Index(29);
        Map(p => p.former_entity_name2).Index(30);
        Map(p => p.former_entity_name3).Index(31);
        Map(p => p.former_entity_name4).Index(32);
        Map(p => p.former_entity_name5).Index(33);
        Map(p => p.former_entity_name6).Index(34);
        Map(p => p.former_entity_name7).Index(35);
        Map(p => p.former_entity_name8).Index(36);
        Map(p => p.former_entity_name9).Index(37);
        Map(p => p.former_entity_name10).Index(38);
        Map(p => p.former_entity_name11).Index(39);
        Map(p => p.former_entity_name12).Index(40);
        Map(p => p.former_entity_name13).Index(41);
        Map(p => p.former_entity_name14).Index(42);
        Map(p => p.former_entity_name15).Index(43);
        Map(p => p.paid_up_capital1_currency).Index(44);
        Map(p => p.paid_up_capital1_ordinary).Index(45);
        Map(p => p.paid_up_capital1_preference).Index(46);
        Map(p => p.paid_up_capital1_others).Index(47);
        Map(p => p.paid_up_capital2_currency).Index(48);
        Map(p => p.paid_up_capital2_ordinary).Index(49);
        Map(p => p.paid_up_capital2_preference).Index(50);
        Map(p => p.paid_up_capital2_others).Index(51);
        Map(p => p.paid_up_capital3_currency).Index(52);
        Map(p => p.paid_up_capital3_ordinary).Index(53);
        Map(p => p.paid_up_capital3_preference).Index(54);
        Map(p => p.paid_up_capital3_others).Index(55);
        Map(p => p.paid_up_capital4_currency).Index(56);
        Map(p => p.paid_up_capital4_ordinary).Index(57);
        Map(p => p.paid_up_capital4_preference).Index(58);
        Map(p => p.paid_up_capital4_others).Index(59);
        Map(p => p.paid_up_capital5_currency).Index(60);
        Map(p => p.paid_up_capital5_ordinary).Index(61);
        Map(p => p.paid_up_capital5_preference).Index(62);
        Map(p => p.paid_up_capital5_others).Index(63);
        Map(p => p.paid_up_capital6_currency).Index(64);
        Map(p => p.paid_up_capital6_ordinary).Index(65);
        Map(p => p.paid_up_capital6_preference).Index(66);
        Map(p => p.paid_up_capital6_others).Index(67);
        Map(p => p.paid_up_capital7_currency).Index(68);
        Map(p => p.paid_up_capital7_ordinary).Index(69);
        Map(p => p.paid_up_capital7_preference).Index(70);
        Map(p => p.paid_up_capital7_others).Index(71);
        Map(p => p.paid_up_capital8_currency).Index(72);
        Map(p => p.paid_up_capital8_ordinary).Index(73);
        Map(p => p.paid_up_capital8_preference).Index(74);
        Map(p => p.paid_up_capital8_others).Index(75);
        Map(p => p.paid_up_capital9_currency).Index(76);
        Map(p => p.paid_up_capital9_ordinary).Index(77);
        Map(p => p.paid_up_capital9_preference).Index(78);
        Map(p => p.paid_up_capital9_others).Index(79);
        Map(p => p.paid_up_capital10_currency).Index(80);
        Map(p => p.paid_up_capital10_ordinary).Index(81);
        Map(p => p.paid_up_capital10_preference).Index(82);
        Map(p => p.paid_up_capital10_others).Index(83);
        Map(p => p.uen_of_audit_firm1).Index(84);
        Map(p => p.name_of_audit_firm1).Index(85);
        Map(p => p.uen_of_audit_firm2).Index(86);
        Map(p => p.name_of_audit_firm2).Index(87);
        Map(p => p.uen_of_audit_firm3).Index(88);
        Map(p => p.name_of_audit_firm3).Index(89);
        Map(p => p.uen_of_audit_firm4).Index(90);
        Map(p => p.name_of_audit_firm4).Index(91);
        Map(p => p.uen_of_audit_firm5).Index(92);
        Map(p => p.name_of_audit_firm5).Index(93);
    }
}