namespace parser;

using System.Collections;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

class AddressesParser
{
    private readonly string _lvl1Token = "response";
    private readonly string _lvl2Token = "docs";
    private readonly string _addressToken = "address_s";
    private readonly string _postalCodeToken = "postal_code_s";

    public AddressesParser()
    {
    }

    public IEnumerable<string> parse(string filename)
    {
        //JObject o1 = JObject.Parse(File.ReadAllText(@filename));

        List<string> addresses = new List<string>();
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

                    //_postalCodeToken
                    addresses.Add("Address,Postal");
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
                            addresses.Add(String.Format("{0},{1}", addrToken, postToken));
                        }
                    }
                }
            }
        }
        return addresses;
    }
}