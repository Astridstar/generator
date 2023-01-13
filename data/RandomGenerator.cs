using System.Text;

namespace data;

class RandomGenerator
{
    protected readonly Random _random = new();

    //Generates a random number
    public int randomNumber(int min, int max)
    {
        return _random.Next(min, max);
    }

    public string randomString(int size, bool lowercase = false)
    {
        var builder = new StringBuilder(size);
        // Unicode/ASCII letters are divided into 2 blocks
        // (Letters 65-90/97-122)
        // 1st gp uppercase letters
        // 2nd gp lowercase letters

        // char is a single Unicode character
        char offset = lowercase ? 'a' : 'A';
        const int lettersOffset = 26;

        for (var i = 0; i < size; i++)
        {
            var @char = (char)_random.Next(offset, offset + lettersOffset);
            builder.Append(@char);
        }
        return lowercase ? builder.ToString().ToLower() : builder.ToString();
    }

    public string randomNumerals(int size)
    {
        var builder = new StringBuilder(size);
        for (var i = 0; i < size; i++)
        {
            int rand = randomNumber(0, 9);
            builder.Append(rand);
        }
        return builder.ToString();
    }
}