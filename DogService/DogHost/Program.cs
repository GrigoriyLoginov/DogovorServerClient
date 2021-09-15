using System;
using System.ServiceModel;

namespace DogHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(DogService.DogService)))
            {
                host.Open();
                
                Console.WriteLine("Host start ...");
                Console.ReadLine();
            }
        }
    }
}
