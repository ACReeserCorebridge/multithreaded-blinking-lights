﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;

namespace MultithreadedBlinkingLights
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .BuildServiceProvider();

            Console.WriteLine("MULTITHREADED BLINKING LIGHTS V 1.0");
            Console.WriteLine("(c) ALEX REESER COREBRIDGE CORP");
            Console.WriteLine("------------");
            string input = "";
            while(input != "exit")
            {
            }
        }
    }
}
