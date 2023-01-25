using System.Text;
using System;

namespace parser;

class RandomGenerator
{
    protected readonly Random _random = new();
    protected DateTime _starDt = new DateTime(1950, 1, 1);
    protected DateTime _endDt = new DateTime(2010, 12, 31);

    protected readonly int _dataTimeRange = 0;

    public RandomGenerator()
    {
        _dataTimeRange = (_endDt - _starDt).Days;
    }
    public RandomGenerator(DateTime startDt, DateTime endDt)
    {
        _starDt = new DateTime(startDt.Year, startDt.Month, startDt.Day);
        _endDt = new DateTime(endDt.Year, endDt.Month, endDt.Day);

        _dataTimeRange = (_endDt - _starDt).Days;
    }

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
    public DateTime randomDateTime()
    {
        return _starDt.AddDays(_random.Next(_dataTimeRange)).AddHours(randomNumber(0, 24)).AddMinutes(randomNumber(0, 60)).AddSeconds(randomNumber(0, 60));
    }
}