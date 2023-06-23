
using System;
using System.Reflection;
using System.Linq;
using System.IO;
using CalculoICMSeICMSST.CIIST;
using Newtonsoft.Json;

public class Aliquotas
{
    public Aliq[] aliqs { get; set; }

    private static Aliquotas PopularListaAliquota()
    {
        string jsonStr = "";
        using(StreamReader sr = new StreamReader(Constants.ARQUIVO_ALIQUOTAS))
        {
            jsonStr = sr.ReadToEnd();
        }

        Aliq[] aliquotas = JsonConvert.DeserializeObject<Aliq[]>(jsonStr);
        Aliquotas aliq = new Aliquotas();
        aliq.aliqs = aliquotas;

        return aliq;
    }

    public static double GetAliqs(string estadoOrigem, string estadoDestino)
    {
        Aliquotas ali = PopularListaAliquota();
        Aliq query = ali.aliqs.Where(x => x.UF == estadoOrigem).FirstOrDefault();
        if(query != null)
        {
            return VerificarPropriedadesVazias(query, estadoDestino);
        }
        return 0;
    }
    private static double VerificarPropriedadesVazias<T>(T value, string estadoDestino)
    {
        Type type = value.GetType();
        PropertyInfo[] property = type.GetProperties();
        foreach (PropertyInfo p in property)
        {
            if (p.Name == estadoDestino)
            {
                return Convert.ToDouble(p.GetValue(value));
            }
        }
        return 0;
    }

}

public class Aliq
{
    public string TO { get; set; }
    public string SE { get; set; }
    public string SP { get; set; }
    public string SC { get; set; }
    public string RR { get; set; }
    public string RO { get; set; }
    public string RJ { get; set; }
    public string RS { get; set; }
    public string RN { get; set; }
    public string PI { get; set; }
    public string PE { get; set; }
    public string PR { get; set; }
    public string PB { get; set; }
    public string PA { get; set; }
    public string MG { get; set; }
    public string MS { get; set; }
    public string MT { get; set; }
    public string MA { get; set; }
    public string GO { get; set; }
    public string ES { get; set; }
    public string DF { get; set; }
    public string CE { get; set; }
    public string BA { get; set; }
    public string AP { get; set; }
    public string AM { get; set; }
    public string AL { get; set; }
    public string AC { get; set; }
    public string UF { get; set; }
}
