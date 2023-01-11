namespace parser;

using System.Collections;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using CsvHelper;

class AddressesParser
{
    internal class AddressRecord
    {
        public AddressRecord(string Address, string Postal)
        {
            this.Address = Address;
            this.Postal = Postal;
        }
        public string Address { get; set; }
        public string Postal { get; set; }
    }

    private readonly string _lvl1Token = "response";
    private readonly string _lvl2Token = "docs";
    private readonly string _addressToken = "address_s";
    private readonly string _postalCodeToken = "postal_code_s";

    public AddressesParser()
    {
    }

    public IEnumerable<AddressRecord> parse(string filename)
    {
        //JObject o1 = JObject.Parse(File.ReadAllText(@filename));

        List<AddressRecord> addresses = new();
        // read JSON directly from a file
        using (StreamReader file = File.OpenText(@filename))
        using (JsonTextReader reader = new JsonTextReader(file))
        {
            JObject? o2 = (JObject)JToken.ReadFrom(reader);
            if (o2 != null && o2.ContainsKey(_lvl1Token))
            {
                JToken? lvl1token = o2.GetValue(_lvl1Token);
                if (lvl1token != null)
                {
                    //JToken lvl2token = lvl1token.SelectToken(_lvl2Token);
                    IEnumerable<JToken>? children = lvl1token.SelectToken(_lvl2Token);

                    if (children != null)
                    {
                        foreach (JToken child in children)
                        {
                            if (child == null)
                            {
                                continue;
                            }
                            string addrToken = child.SelectToken(_addressToken).Value<string>();
                            string postToken = child.SelectToken(_postalCodeToken).Value<string>();
                            Console.WriteLine("{0}, {1}", addrToken, postToken);
                            addresses.Add(new AddressRecord(addrToken, postToken));
                        }
                    }
                }
            }
        }
        return addresses;
    }

    public void generateCsv(string filename, IEnumerable<AddressRecord> dataList)
    {
        using (var writer = new StreamWriter(@filename))
        using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            csv.WriteRecords(dataList);
    }
}