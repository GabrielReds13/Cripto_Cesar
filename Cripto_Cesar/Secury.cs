using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cripto_Cesar
{
    public static class Secury
    {
        public static void Encrypt(string text)
        {
            try
            {
                // - Variaveis -
                char[] textoInArray = text.ToCharArray();
                char[] textoEncryptInArray = new char[textoInArray.Length];

                Random r = new Random();

                // Caracteres
                string[] alfabeto = {
                    "a", "A", "b", "B", "c", "C", "d", "D", "e", "E", "f", "F", "g", "G",
                    "h", "H", "i", "I", "j", "J", "k", "K", "l", "L", "m", "M", "n", "N", 
                    "o", "O", "p", "P", "q", "Q", "r", "R", "s", "S", "t", "T", "u", "U", 
                    "v", "V", "w", "W", "x", "X", "y", "Y", "z", "Z"
                },
                alfabetoAlt = {
                    "ã", "á", "à", "â", "Ã",  "Á",  "À",  "Â",  
                    "ç", "Ç", "é", "è", "ê", "É", "È", "Ê", 
                    "í", "ì", "î", "Í", "Ì", "Î", 
                    "õ", "ó", "ò", "ô", "Õ", "Ó", "Ò", "Ô", 
                    "ú", "ù", "û", "Ú", "Ù", "Û"
                },
                numeros = {
                    "0", "1", "2", "3", "4",
                    "5", "6", "7", "8", "9"
                };

                // - Codigo -
                MessageConsole.Show("Criptografando...");

                for(int i = 0; i < text.Length; i++)
                {
                    MessageConsole.Show("\nAnalisando correspondência...");

                    int j = 0, letraAtual = 0, rNum = r.Next(1, 200);

                    while(true)
                    {
                        if (alfabeto[letraAtual] == Convert.ToString(textoInArray[i]))
                        {
                            j = letraAtual;
                            MessageConsole.Show($"Letter: {alfabeto[letraAtual]}    |    Possible match: {Convert.ToString(textoInArray[i])}    |    ", true);
                            break;
                        }
                        else letraAtual++;
                        MessageConsole.Show($"Letter: {alfabeto[letraAtual]}    |    Possible match: {Convert.ToString(textoInArray[i])}    |    ", false);
                    }

                    MessageConsole.Show("\nConversão iniciada...");
                    while(true)
                    {
                        bool largaEscala = false;

                        // Curta escala
                        if (j > rNum && rNum >= 0 && rNum <= 51) j--;
                        else if (j < rNum && rNum >= 0 && rNum <= 51) j++;

                        // Larga escala
                        if (rNum > 51)
                        {
                            j++;
                            largaEscala = true;
                        }

                        // Criptografar
                        // Curta escala
                        if(largaEscala == false)
                        {
                            if(j == rNum)
                            {
                                textoEncryptInArray[i] = Convert.ToChar(alfabeto[j]);
                                MessageConsole.Show($"Find Letter: {alfabeto[j]}    |    Current Position: {j}    |    Preview Box Position: {rNum}    |    ", true);
                                break;
                            }
                        }

                        // Larga escala
                        else
                        {
                            if (j > 51)
                            {
                                rNum -= (j - 1);
                                j = 0;
                            }
                            else if (j == rNum)
                            {
                                textoEncryptInArray[i] = Convert.ToChar(alfabeto[j]);
                                MessageConsole.Show($"Find Letter: {alfabeto[j]}    |    Current Position: {j}    |    Preview Box Position: {rNum}    |    ", true);
                                break;
                            }
                        }

                        
                        MessageConsole.Show($"Find Letter: {alfabeto[j]}    |    Current Position: {j}    |    Preview Box Position: {rNum}    |    ", false);
                    }
                }

                string rst = "";
                for(int i = 0;i < textoEncryptInArray.Length;i++) rst += Convert.ToString(textoEncryptInArray[i]);

                Console.WriteLine("");
                
                MessageConsole.ShowResult(rst);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }   
        }
    }
}
