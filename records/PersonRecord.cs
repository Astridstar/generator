using data;

namespace records;

class PersonRecord
{
    public string sn { get; set; }
    public string gender { get; set; }
    public string fullname { get; set; }
    public string email1 { get; set; }
    public string email2 { get; set; }
    public string salutation { get; set; }
    public string birthday { get; set; }
    public string mobile { get; set; }
    public string phone2 { get; set; }
    public string fax { get; set; }
    public string id { get; set; } // nric - changed
    public string address1 { get; set; }
    public string address2 { get; set; }
    public string postcode { get; set; }
    public string citizenship { get; set; }
    public string nationality { get; set; }
    public string company { get; set; }
    public string company_id { get; set; } // removed
    public string car_plate { get; set; }
    public string deceased { get; set; } // added
    public string marital { get; set; } // added
    public string father_id { get; set; }
    public string mother_id { get; set; }

    // add
    public string spouse_id { get; set; }
    public string sibling1_id { get; set; }
    public string sibling2_id { get; set; }
    public string sibling3_id { get; set; }
    public string child1_id { get; set; }
    public string child2_id { get; set; }
    public string child3_id { get; set; }

    public PersonRecord()
    {

    }
    public string toCsvFormat()
    {
        return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{9},{10},{11},{12},{13},{14},{15},{16},{17},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},",
        sn, gender, fullname, email1, email2, salutation, birthday, mobile, phone2, fax, id, address1, address2, postcode,
        citizenship, nationality,
        company, company_id,
        car_plate, deceased,
        marital, father_id, mother_id, spouse_id, sibling1_id, sibling2_id, sibling3_id, child1_id, child2_id, child3_id);
    }

    public static string getRecordHeader()
    {
        return String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{9},{10},{11},{12},{13},{14},{15},{16},{17},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},",
        nameof(sn),
        nameof(gender),
        nameof(fullname),
        nameof(email1),
        nameof(email2),
        nameof(salutation),
        nameof(birthday),
        nameof(mobile),
        nameof(phone2),
        nameof(fax),
        nameof(id),
        nameof(address1),
        nameof(address2),
        nameof(postcode),
        nameof(citizenship),
        nameof(nationality),
        nameof(company),
        nameof(company_id),
        nameof(car_plate),
        nameof(deceased),
        nameof(marital),
        nameof(father_id),
        nameof(mother_id),
        nameof(spouse_id),
        nameof(sibling1_id),
        nameof(sibling2_id),
        nameof(sibling3_id),
        nameof(child1_id),
        nameof(child2_id),
        nameof(child3_id));
    }

    public PersonRecord(ScenarioRecord data, string email1, string email2, string mobile)
    {
        this.sn = data.sn;
        this.gender = data.gender;
        this.fullname = data.fullname;
        this.email1 = email1;
        this.email2 = email2;
        this.salutation = "";
        this.birthday = data.dob;
        this.mobile = mobile;
        this.phone2 = "";
        this.fax = "";
        this.id = data.id;
        this.address1 = data.address;
        this.address2 = "";
        this.postcode = data.postal;
        this.citizenship = data.citizenship;
        this.nationality = data.nationality;
        this.company = data.employer;
        this.company_id = "lookup";
        this.car_plate = data.vehicle_plate;
        this.deceased = data.deceased;
        this.marital = data.marital;
        this.father_id = data.father;//lookup
        this.mother_id = data.mother;//lookup
        this.spouse_id = data.spouse;//lookup
        this.sibling1_id = data.sib1;//lookup
        this.sibling2_id = data.sib2;//lookup
        this.sibling3_id = data.sib3;//lookup
        this.child1_id = data.child1;//lookup
        this.child2_id = data.child2;//lookup
        this.child3_id = data.child3;//lookup
    }
}