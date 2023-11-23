

using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<int> ProcessQueries(List<(int, int)> queries)
    {
        List<int> result = new List<int>();
        Dictionary<int, int> freqDict = new Dictionary<int, int>();

        foreach (var query in queries)
        {
            int operation = query.Item1;
            int value = query.Item2;

            if (operation == 1)
            {
                // Insert operation
                if (freqDict.ContainsKey(value))
                    freqDict[value]++;
                else
                    freqDict[value] = 1;
            }
            else if (operation == 2)
            {
                // Delete operation
                if (freqDict.ContainsKey(value) && freqDict[value] > 0)
                    freqDict[value]--;
            }
            else if (operation == 3)
            {
                // Check frequency operation
                result.Add(freqDict.ContainsValue(value) ? 1 : 0);
            }
        }

        return result;
    }

    static void Main()
    {
        List<(int, int)> queries = new List<(int, int)>
        {
            (1, 1), (2, 2), (3, 2), (1, 1), (1, 1), (2, 1), (3, 2)
        };

        List<int> output = ProcessQueries(queries);

        Console.WriteLine(string.Join(" ", output));
    }
}