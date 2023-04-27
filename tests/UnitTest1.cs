namespace tests;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// This is simply a test unit for demo purpose only
public class UnitTest1
{
    const string case_state_1 = "case_state_1";
    const string case_state_2 = "case_state_2";

    [Fact]
    public void case_1()
    {
        Assert.True(getTestState(1));
    }


    [Fact]
    public void case_2()
    {
        Assert.True(getTestState(2));
    }

    public bool getTestState(int caseNo)
    {
        string test_state = (caseNo == 1 ? case_state_1 : case_state_2);

        // read JSON directly from a file
        using (StreamReader file = File.OpenText("../../../test_state_config.json"))
        using (JsonTextReader reader = new JsonTextReader(file))
        {
            JObject? o2 = (JObject)JToken.ReadFrom(reader);
            if (o2 != null && o2.ContainsKey(test_state))
            {
                JToken? state_token = o2.GetValue(test_state);
                if(state_token != null)
                {
                    return state_token.Value<bool>();
                }
            }
        }
        return false;
    }
}