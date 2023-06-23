using System;

namespace CalculoICMSeICMSST.CIIST
{
    internal static class TribICMS
    {
        public static double CalculaICMS(string estadoOrigem,double baseCalculo)
        {
            double aliquota;
            double icms;

            if (baseCalculo == 0)
            {
                Console.WriteLine("Base de calculo zerada!");
                return 0;
            }

            aliquota = Aliquotas.GetAliqs(estadoOrigem, estadoOrigem);

            icms = baseCalculo * (aliquota / 100);

            Console.WriteLine($"A aliquota é {aliquota}%");
            Console.WriteLine($"O ICMS é {icms.ToString("C2")}");
            return icms;
        }

        public static double CalculaICMSST(double valorIpi,double baseDeCalculo, 
            double mva, string estadoOrigem, string estadoDestino)
        {
            double aliquota;
            double icmsSt;
            double icmsInter;
            double baseIcmsSt;

            if (baseDeCalculo == 0)
            {
                Console.WriteLine("Base de calculo zerada!");
                return 0;
            }

            mva = mva / 100;
            aliquota = Aliquotas.GetAliqs(estadoOrigem, estadoDestino) / 100;

            icmsInter = baseDeCalculo * aliquota;

            aliquota = Aliquotas.GetAliqs(estadoOrigem, estadoOrigem) / 100;

            baseIcmsSt = (baseDeCalculo + valorIpi) * (1 + mva);
            icmsSt = (baseIcmsSt * aliquota) - icmsInter;

            Console.WriteLine($"O Valor do ICMS ST {icmsSt.ToString("C2")}");
            Console.WriteLine($"O Valor do ICMS Interestadual {icmsInter.ToString("C2")}");
            return icmsSt;
        }
    }
}
