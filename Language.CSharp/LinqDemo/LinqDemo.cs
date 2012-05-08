﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinqDemo
{
    class LinqDemo
    {
        public void Linq1()
        {
            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var lowNums =
                from n in numbers
                where n < 5
                select n;

            Console.WriteLine("Numbers < 5:");
            foreach (var x in lowNums)
            {
                Console.WriteLine(x);
            }
        }  
    }
}
