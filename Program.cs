using CalculoICMSeICMSST.CIIST;
using System;

namespace CalculoICMSeICMSST
{
    class Program
    {
        static void Main(string[] args)
        {
            TribICMS.CalculaICMS("BA", 300);
            TribICMS.CalculaICMSST(10,1200,50,"SP","PR");
            Console.WriteLine("Pressione qualquer tecla para continuar.....");
            Console.ReadKey(true);
        }
    }
}
