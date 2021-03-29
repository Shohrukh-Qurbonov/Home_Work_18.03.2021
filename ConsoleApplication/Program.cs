using ConsoleApplication.Repositories.CustomerRepository;
using System;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomerRepository client = new CustomerRepository();
            while (true)
            {
                Console.Clear();
                Console.Write("1.Create\n2.Read\n3.Update\n4.Delete\nВаш выбор: ");
                switch (Console.ReadLine())
                {
                    case "1": { client.Create(); Console.ReadKey(); } break;
                    case "2": { client.Select(); Console.ReadKey(); } break;
                    case "3": { client.Update(); Console.ReadKey(); } break;
                    case "4": { client.Delete(); Console.ReadKey(); } break;
                    default:
                        break;
                }
            }
        }
    }
}
