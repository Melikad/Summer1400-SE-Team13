﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Phase5
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileAddress = "EnglishData";
            Console.WriteLine(Directory.GetFiles(fileAddress).Length);
        }
    }
}