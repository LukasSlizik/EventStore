﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client();
            c.Test();
        }
    }
}
