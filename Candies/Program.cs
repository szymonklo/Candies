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

class Solution
{

    // Complete the candies function below.
    static long candies(int n, int[] arr)
    {
        int first = arr[0] + arr[0] - arr[1];
        int last = arr[n - 1] + arr[n - 1] - arr[n - 2];
        int[] newArr = new int[n + 2];
        newArr[0] = arr[0] + Math.Abs(arr[0] - arr[1]);
        newArr[n + 1] = arr[n - 1] + Math.Abs(arr[n - 1] - arr[n - 2]);
        Array.Copy(arr, 0, newArr, 1, n);
        int[] candies = new int[n + 2];

        //add logic for first and last (define if itis local extrem.)
        //add logic for equal neighbour
        for (int i = 1; i < n + 1; i++)
        {
            if (newArr[i - 1] >= newArr[i] && newArr[i] <= newArr[i + 1])
            {
                candies[i] = 1;
                for (int j = i - 1; j >= 1 ; j--)
                {
                    if (newArr[j] > newArr[j + 1] && newArr[j - 1] >= newArr[j])
                    {
                        candies[j] = candies[j + 1] + 1;
                    }
                }
                for (int j = i + 1; j < n + 1 ; j++)
                {
                    if (newArr[j] > newArr[j - 1] && newArr[j + 1] >= newArr[j])
                    {
                        candies[j] = candies[j - 1] + 1;
                    }
                }
            }
        }
        for (int i = 1; i < n + 1; i++)
        {
            if (newArr[i - 1] < newArr[i] && newArr[i] > newArr[i + 1])
            {
                candies[i] = 1 + Math.Max(candies[i - 1], candies[i + 1]);
            }
        }
        /*
        if (newArr[0] < newArr[1])
            candies[0]=1;
        if (newArr[0] > newArr[1])
            candies[0]=candies[1]+1;
        if (newArr[n-1] < newArr[n-2])
            candies[n-1]=1;
        if (newArr[n-1] > newArr[n-2])
            candies[n-1]=candies[n-2]+1;
            */
        long suma = candies.Sum();
        Console.WriteLine(suma);
        return suma;
    }

    static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine());

        int[] newArr = new int[n];

        for (int i = 0; i < n; i++)
        {
            int newArrItem = Convert.ToInt32(Console.ReadLine());
            newArr[i] = newArrItem;
        }

        long result = candies(n, newArr);

        //textWriter.WriteLine(result);

        //textWriter.Flush();
        //textWriter.Close();
    }
}
