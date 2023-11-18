using Cripto_Cesar;
using System;
public class Program
{
    static void Main(string[] args)
    {
        // - Variaveis -
        string frase = "";

        // - Codigo -
        while (true)
        {
            Console.Write("Escreva uma palavra: ");
            frase = Console.ReadLine();
            Secury.Encrypt(frase);

            Console.WriteLine("\n\n- CLIQUE PARA CRIPTOGRAFAR OUTRA PALAVRA - ");
            Console.ReadKey();
            Console.Clear();
        }

        // - Fim -
        Console.ReadKey();
    }
}