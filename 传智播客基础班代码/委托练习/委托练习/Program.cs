using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 委托练习
{
    public delegate bool del<T>(T a,T b);
    class Program
    {
        
        static void Main(string[] args)
        {
            string[] sums = { "1", "12", "123", "1234", "12345", "123456" };
            string max = GetMax<string>(sums, (string a, string b) => 
            { 
                if (a.Length < b.Length)
                    return true; 
                else 
                    return false; 
            });
            
            Console.WriteLine(max);
            Console.ReadKey();
        }
        static T GetMax<T>(T[] sums, del<T> d)
        {
            T max=sums[0];
            for (int i = 0; i < sums.Length; i++)
            {
                if(d(max,sums[i]))
                {
                    max=sums[i];
                }
            }
            return max;
        }
    }
}
