using Cripto_Cesar;
using System;
public class Program
{
    static void Main(string[] args)
    {
        // - Variaveis -
        string frase = "";

        // - Codigo -
        Console.Write("Escreva uma palavra: ");
        frase = Console.ReadLine();
        Secury.Encrypt(frase);

        // - Fim -
        Console.ReadKey();
    }
}