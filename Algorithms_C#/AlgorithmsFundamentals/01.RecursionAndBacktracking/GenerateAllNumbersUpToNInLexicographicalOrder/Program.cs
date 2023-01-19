// C# program to implement the
// above approach
using System;
using System.Collections.Generic;

class GFG
{

    // Function to print all the
    // numbers up to n in
    // lexicographical order
    static void lexNumbers(int n)
    {
        List<String> s = new List<String>();

        for (int i = 1; i <= n; i++)
        {
            s.Add(String.Join("", i));
        }

        s.Sort();
        List<int> ans = new List<int>();

        for (int i = 0; i < n; i++)
            ans.Add(Int32.Parse(s[i]));

        for (int i = 0; i < n; i++)
            Console.Write(ans[i] + " ");
    }

    // Driver code
    public static void Main(String[] args)
    {
        int n = int.Parse(Console.ReadLine());

        lexNumbers(n);
    }
}

// This code is contributed by Rajput-Ji
