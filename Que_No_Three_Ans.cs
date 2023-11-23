using System;
using System.Collections.Generic;

class Program
{
    static List<int> freqQuery(List<List<int>> queries)
    {
        Dictionary<int, int> freq = new Dictionary<int, int>();
        Dictionary<int, int> freqCount = new Dictionary<int, int>();
        List<int> result = new List<int>();

        foreach (List<int> query in queries)
        {
            int qType = query[0];
            int value = query[1];

            if (qType == 1)
            {
                // Type 1 query: Increment the frequency of the element
                if (!freq.ContainsKey(value)) freq[value] = 0;
                if (!freqCount.ContainsKey(freq[value])) freqCount[freq[value]] = 0;

                freqCount[freq[value]]--;
                freq[value]++;
                freqCount[freq[value]]++;
            }
            else if (qType == 2)
            {
                // Type 2 query: Decrement the frequency of the element
                if (freq.ContainsKey(value) && freq[value] > 0)
                {
                    freqCount[freq[value]]--;
                    freq[value]--;
                    freqCount[freq[value]]++;
                }
            }
            else if (qType == 3)
            {
                // Type 3 query: Check if there is an element with the queried frequency
                result.Add(freqCount.ContainsKey(value) && freqCount[value] > 0 ? 1 : 0);
            }
        }

        return result;
    }

    static void Main()
    {
        // Sample Input 2
        List<List<int>> queries2 = new List<List<int>> {
            new List<int> { 1, 3 },
            new List<int> { 2, 3 },
            new List<int> { 3, 2 },
            new List<int> { 1, 4 },
            new List<int> { 1, 5 },
            new List<int> { 1, 5 },
            new List<int> { 1, 4 },
            new List<int> { 3, 2 },
            new List<int> { 2, 4 },
            new List<int> { 3, 2 }
        };

        // Sample Output 2
        List<int> output2 = freqQuery(queries2);

        // Print the output
        foreach (int value in output2)
        {
            Console.WriteLine(value);
        }
    }
}

