namespace parser;

using System.Text;
using data;

class IUGenerator : RandomGenerator
{
    private readonly int DEF_PREFIX_GEN_LEN = 3;
    private readonly int DEF_PREFIX_STEM_LEN = 5;
    private readonly int DEF_SUFFIX_STEM_LEN = 2;
    private readonly int UNIQUENESS_RETRY = 5;

    List<string> _generated = new();

    bool isUnique(string item)
    {
        return _generated.Where(i => String.Equals(i, item)).Count() == 0 ? true : false;
    }

    public string getRandomIuNumber()
    {
        var builder = new StringBuilder();
        for (int i = 0; i < UNIQUENESS_RETRY; i++)
        {
            builder.Append(randomString(DEF_PREFIX_GEN_LEN));
            builder.Append(randomNumerals(DEF_PREFIX_STEM_LEN));
            builder.Append(randomString(DEF_PREFIX_GEN_LEN));
            if (!isUnique(builder.ToString()))
            {
                builder = new StringBuilder();
                Console.WriteLine("Found duplicates for {0}", builder.ToString());
            }
            else
            {
                _generated.Add(builder.ToString());
                break;
            }
        }
        return builder.ToString();
    }
}