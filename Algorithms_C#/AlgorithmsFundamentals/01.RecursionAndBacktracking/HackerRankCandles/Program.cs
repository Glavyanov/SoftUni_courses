using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'birthdayCakeCandles' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY candles as parameter.
     */
    /*Example
     * candles = [4, 4, 1, 3];
     * The maximum height candles are 4 units high. There are 2 of them, so return 2.*/

    public static int birthdayCakeCandles(List<int> candles)
    {
        return candles.Aggregate(
            new { Max = candles.Max(), Total = 0 }, (result, x) =>
            new { Max = result.Max, Total = result.Max == x ? result.Total + 1 : result.Total }, responce => responce.Total);
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        int candlesCount = Convert.ToInt32(Console.ReadLine()!.Trim());

        List<int> candles = Console.ReadLine()!.TrimEnd().Split(' ').ToList().Select(candlesTemp => Convert.ToInt32(candlesTemp)).ToList();

        int result = Result.birthdayCakeCandles(candles);
        Console.WriteLine(result);
    }
}
