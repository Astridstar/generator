namespace records;

using System.Text;
class AcraInformation : AcraInformationData
{
    public AcraInformation()
    {
        #region Initialization of parameters in constructor
        issuance_agency_id = "ACRA";
        uen = "";
        entity_name = "";
        entity_type_description = "";
        business_constitution_description = "";
        company_type_description = "";
        paf_constitution_description = "na";
        entity_status_description = "";
        registration_incorporation_date = "";
        uen_issue_date = "";
        address_type = "LOCAL";
        block = "na";
        street_name = "na";
        level_no = "na";
        unit_no = "na";
        building_name = "na";
        postal_code = "";
        other_address_line1 = "na";
        other_address_line2 = "na";
        account_due_date = "na";
        annual_return_date = "na";
        no_of_charges = "0";
        primary_ssic_code = "70201";
        primary_ssic_description = "MANAGEMENT CONSULTANCY SERVICES";
        primary_user_described_activity = "na";
        secondary_ssic_code = "46900";
        secondary_ssic_description = "WHOLESALE TRADE OF A VARIETY OF GOODS WITHOUT A DOMINANT PRODUCT";
        secondary_user_described_activity = "na";
        no_of_officers = "0";
        former_entity_name1 = "na";
        former_entity_name2 = "na";
        former_entity_name3 = "na";
        former_entity_name4 = "na";
        former_entity_name5 = "na";
        former_entity_name6 = "na";
        former_entity_name7 = "na";
        former_entity_name8 = "na";
        former_entity_name9 = "na";
        former_entity_name10 = "na";
        former_entity_name11 = "na";
        former_entity_name12 = "na";
        former_entity_name13 = "na";
        former_entity_name14 = "na";
        former_entity_name15 = "na";
        paid_up_capital1_currency = "na";
        paid_up_capital1_ordinary = "na";
        paid_up_capital1_preference = "na";
        paid_up_capital1_others = "na";
        paid_up_capital2_currency = "na";
        paid_up_capital2_ordinary = "na";
        paid_up_capital2_preference = "na";
        paid_up_capital2_others = "na";
        paid_up_capital3_currency = "na";
        paid_up_capital3_ordinary = "na";
        paid_up_capital3_preference = "na";
        paid_up_capital3_others = "na";
        paid_up_capital4_currency = "na";
        paid_up_capital4_ordinary = "na";
        paid_up_capital4_preference = "na";
        paid_up_capital4_others = "na";
        paid_up_capital5_currency = "na";
        paid_up_capital5_ordinary = "na";
        paid_up_capital5_preference = "na";
        paid_up_capital5_others = "na";
        paid_up_capital6_currency = "na";
        paid_up_capital6_ordinary = "na";
        paid_up_capital6_preference = "na";
        paid_up_capital6_others = "na";
        paid_up_capital7_currency = "na";
        paid_up_capital7_ordinary = "na";
        paid_up_capital7_preference = "na";
        paid_up_capital7_others = "na";
        paid_up_capital8_currency = "na";
        paid_up_capital8_ordinary = "na";
        paid_up_capital8_preference = "na";
        paid_up_capital8_others = "na";
        paid_up_capital9_currency = "na";
        paid_up_capital9_ordinary = "na";
        paid_up_capital9_preference = "na";
        paid_up_capital9_others = "na";
        paid_up_capital10_currency = "na";
        paid_up_capital10_ordinary = "na";
        paid_up_capital10_preference = "na";
        paid_up_capital10_others = "na";
        uen_of_audit_firm1 = "na";
        name_of_audit_firm1 = "na";
        uen_of_audit_firm2 = "na";
        name_of_audit_firm2 = "na";
        uen_of_audit_firm3 = "na";
        name_of_audit_firm3 = "na";
        uen_of_audit_firm4 = "na";
        name_of_audit_firm4 = "na";
        uen_of_audit_firm5 = "na";
        name_of_audit_firm5 = "na";
        #endregion
    }
    public new static string getRecordHeader()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            nameof(issuance_agency_id),
            nameof(uen),
            nameof(entity_name),
            nameof(entity_type_description),
            nameof(business_constitution_description),
            nameof(company_type_description),
            nameof(paf_constitution_description),
            nameof(entity_status_description),
            nameof(registration_incorporation_date),
            nameof(uen_issue_date)
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            nameof(address_type),
            nameof(block),
            nameof(street_name),
            nameof(level_no),
            nameof(unit_no),
            nameof(building_name),
            nameof(postal_code),
            nameof(other_address_line1),
            nameof(other_address_line2),
            nameof(account_due_date)
        );

        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            nameof(annual_return_date),
            nameof(no_of_charges),
            nameof(primary_ssic_code),
            nameof(primary_ssic_description),
            nameof(primary_user_described_activity),
            nameof(secondary_ssic_code),
            nameof(secondary_ssic_description),
            nameof(secondary_user_described_activity),
            nameof(no_of_officers),
            nameof(former_entity_name1)
        );

        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            nameof(former_entity_name2),
            nameof(former_entity_name3),
            nameof(former_entity_name4),
            nameof(former_entity_name5),
            nameof(former_entity_name6),
            nameof(former_entity_name7),
            nameof(former_entity_name8),
            nameof(former_entity_name9),
            nameof(former_entity_name10),
            nameof(former_entity_name11)
        );

        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            nameof(former_entity_name12),
            nameof(former_entity_name13),
            nameof(former_entity_name14),
            nameof(former_entity_name15),
            nameof(paid_up_capital1_currency),
            nameof(paid_up_capital1_ordinary),
            nameof(paid_up_capital1_preference),
            nameof(paid_up_capital1_others),
            nameof(paid_up_capital2_currency),
            nameof(paid_up_capital2_ordinary)
        );

        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            nameof(paid_up_capital2_preference),
            nameof(paid_up_capital2_others),
            nameof(paid_up_capital3_currency),
            nameof(paid_up_capital3_ordinary),
            nameof(paid_up_capital3_preference),
            nameof(paid_up_capital3_others),
            nameof(paid_up_capital4_currency),
            nameof(paid_up_capital4_ordinary),
            nameof(paid_up_capital4_preference),
            nameof(paid_up_capital4_others)
        );

        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            nameof(paid_up_capital5_currency),
            nameof(paid_up_capital5_ordinary),
            nameof(paid_up_capital5_preference),
            nameof(paid_up_capital5_others),
            nameof(paid_up_capital6_currency),
            nameof(paid_up_capital6_ordinary),
            nameof(paid_up_capital6_preference),
            nameof(paid_up_capital6_others),
            nameof(paid_up_capital7_currency),
            nameof(paid_up_capital7_ordinary)
        );

        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            nameof(paid_up_capital7_preference),
            nameof(paid_up_capital7_others),
            nameof(paid_up_capital8_currency),
            nameof(paid_up_capital8_ordinary),
            nameof(paid_up_capital8_preference),
            nameof(paid_up_capital8_others),
            nameof(paid_up_capital9_currency),
            nameof(paid_up_capital9_ordinary),
            nameof(paid_up_capital9_preference),
            nameof(paid_up_capital9_others)
        );

        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            nameof(paid_up_capital10_currency),
            nameof(paid_up_capital10_ordinary),
            nameof(paid_up_capital10_preference),
            nameof(paid_up_capital10_others),
            nameof(uen_of_audit_firm1),
            nameof(name_of_audit_firm1),
            nameof(uen_of_audit_firm2),
            nameof(name_of_audit_firm2),
            nameof(uen_of_audit_firm3),
            nameof(name_of_audit_firm3)
        );

        builder.AppendFormat("{0},{1},{2},{3}",
            nameof(uen_of_audit_firm4),
            nameof(name_of_audit_firm4),
            nameof(uen_of_audit_firm5),
            nameof(name_of_audit_firm5)
        );
        return builder.ToString();
    }
    public new string toCsvFormat()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendFormat("{0},{1},\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",{8},{9},",
            issuance_agency_id,
            uen,
            entity_name,
            entity_type_description,
            business_constitution_description,
            company_type_description,
            paf_constitution_description,
            entity_status_description,
            registration_incorporation_date,
            uen_issue_date
        );
        builder.AppendFormat("{0},{1},\"{2}\",{3},{4},\"{5}\",{6},\"{7}\",\"{8}\",{9},",
            address_type,
            block,
            street_name,
            level_no,
            unit_no,
            building_name,
            postal_code,
            other_address_line1,
            other_address_line2,
            account_due_date
        );
        builder.AppendFormat("{0},{1},{2},\"{3}\",\"{4}\",{5},\"{6}\",\"{7}\",{8},{9},",
            annual_return_date,
            no_of_charges,
            primary_ssic_code,
            primary_ssic_description,
            primary_user_described_activity,
            secondary_ssic_code,
            secondary_ssic_description,
            secondary_user_described_activity,
            no_of_officers,
            former_entity_name1
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            former_entity_name2,
            former_entity_name3,
            former_entity_name4,
            former_entity_name5,
            former_entity_name6,
            former_entity_name7,
            former_entity_name8,
            former_entity_name9,
            former_entity_name10,
            former_entity_name11
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            former_entity_name12,
            former_entity_name13,
            former_entity_name14,
            former_entity_name15,
            paid_up_capital1_currency,
            paid_up_capital1_ordinary,
            paid_up_capital1_preference,
            paid_up_capital1_others,
            paid_up_capital2_currency,
            paid_up_capital2_ordinary
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            paid_up_capital2_preference,
            paid_up_capital2_others,
            paid_up_capital3_currency,
            paid_up_capital3_ordinary,
            paid_up_capital3_preference,
            paid_up_capital3_others,
            paid_up_capital4_currency,
            paid_up_capital4_ordinary,
            paid_up_capital4_preference,
            paid_up_capital4_others
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            paid_up_capital5_currency,
            paid_up_capital5_ordinary,
            paid_up_capital5_preference,
            paid_up_capital5_others,
            paid_up_capital6_currency,
            paid_up_capital6_ordinary,
            paid_up_capital6_preference,
            paid_up_capital6_others,
            paid_up_capital7_currency,
            paid_up_capital7_ordinary
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            paid_up_capital7_preference,
            paid_up_capital7_others,
            paid_up_capital8_currency,
            paid_up_capital8_ordinary,
            paid_up_capital8_preference,
            paid_up_capital8_others,
            paid_up_capital9_currency,
            paid_up_capital9_ordinary,
            paid_up_capital9_preference,
            paid_up_capital9_others
        );
        builder.AppendFormat("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},",
            paid_up_capital10_currency,
            paid_up_capital10_ordinary,
            paid_up_capital10_preference,
            paid_up_capital10_others,
            uen_of_audit_firm1,
            name_of_audit_firm1,
            uen_of_audit_firm2,
            name_of_audit_firm2,
            uen_of_audit_firm3,
            name_of_audit_firm3
        );
        builder.AppendFormat("{0},{1},{2},{3}",
            uen_of_audit_firm4,
            name_of_audit_firm4,
            uen_of_audit_firm5,
            name_of_audit_firm5
        );
        return builder.ToString();
    }
}