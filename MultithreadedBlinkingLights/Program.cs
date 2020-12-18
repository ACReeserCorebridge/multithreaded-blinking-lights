using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;

namespace MultithreadedBlinkingLights
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ILightHardwareSource, LightHardwareSource>()
                .AddSingleton<IPowerSupply, PowerSupply>()
                .AddSingleton<IFixtureProvider, FixtureProvider>()
                .AddTransient<ILightEmittingFixture, LightEmittingFixture>()
                .AddTransient<IPhotonExciter, PhotonExciter>()
                .BuildServiceProvider();

            Console.WriteLine("MULTITHREADED BLINKING LIGHTS V 1.0");
            Console.WriteLine("(c) ALEX REESER COREBRIDGE CORP");
            Console.WriteLine("------------");
            serviceProvider.GetService<IPowerSupply>().TurnOn();
            serviceProvider.GetService<IFixtureProvider>().Start();
            string input = "";
            while(input != "exit")
            {
            }
        }
    }
}
