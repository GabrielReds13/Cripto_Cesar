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
                string[] allCaracteres = {
                    // Letras
                    "a", "A", "b", "B", "c", "C", "d", "D", "e", "E", "f", "F", "g", "G",
                    "h", "H", "i", "I", "j", "J", "k", "K", "l", "L", "m", "M", "n", "N",
                    "o", "O", "p", "P", "q", "Q", "r", "R", "s", "S", "t", "T", "u", "U",
                    "v", "V", "w", "W", "x", "X", "y", "Y", "z", "Z",

                    // Numeros
                    "0", "1", "2", "3", "4", "5", "6", "7", "8", "9",

                    // Outros
                    " "
                },
                // Caracteres Extras
                letrasAlt =
                {
                    "ã", "á", "à", "â", "Ã", "Á", "À", "Â",
                    "ç", "Ç", "é", "è", "ê", "É", "È", "Ê",
                    "í", "ì", "î", "Í", "Ì", "Î",
                    "õ", "ó", "ò", "ô", "Õ", "Ó", "Ò", "Ô",
                    "ú", "ù", "û", "Ú", "Ù", "Û"
                },
                caracteresEspeciais1 = {
                    "@", "&", "%", "!", "?", "_", "-", "+",
                    "=", "$", ":", ";", 
                },
                caracteresEspeciais2 = {
                    ".", ",", "´", "`", "~", "^", "'", Convert.ToString('"'), "(", ")"
                };

                // - Codigo -
                MessageConsole.Show("Criptografando...");

                for(int i = 0; i < text.Length; i++)
                {
                    MessageConsole.Show("\nAnalisando correspondência...");

                    int j = 0, caractereAtual = 0, rNum = r.Next(1, 400), rCEs = r.Next(0, caracteresEspeciais1.Length - 1);
                    bool criptografarCaractere = true;

                    // Capturar caractere
                    while(true)
                    {
                        // Letras
                        if (allCaracteres[caractereAtual] == Convert.ToString(textoInArray[i]))
                        {
                            j = caractereAtual;
                            MessageConsole.Show($"Letter: {allCaracteres[caractereAtual]}    |    Possible match: {Convert.ToString(textoInArray[i])}    |    ", true);
                            break;
                        }
                        // Letras alt.
                        else if 
                        (
                            caractereAtual >= 0 && caractereAtual <= (letrasAlt.Length - 1) && letrasAlt[caractereAtual] == Convert.ToString(textoInArray[i]) ||
                            caractereAtual >= 0 && caractereAtual <= (caracteresEspeciais1.Length - 1) && caracteresEspeciais1[caractereAtual] == Convert.ToString(textoInArray[i]) ||
                            caractereAtual >= 0 && caractereAtual <= (caracteresEspeciais2.Length - 1) && caracteresEspeciais2[caractereAtual] == Convert.ToString(textoInArray[i]) ||
                            " " == Convert.ToString(textoInArray[i])
                        )
                        {
                            criptografarCaractere = false;
                            textoEncryptInArray[i] = Convert.ToChar(caracteresEspeciais1[rCEs]);
                            MessageConsole.Show($"Find Letter: ERROR!    |    Current Position: {j}    |    Preview Box Position: {rNum}    |    ", true);
                            break;
                        }
                        else caractereAtual++;
                        MessageConsole.Show($"Letter: {allCaracteres[caractereAtual]}    |    Possible match: {Convert.ToString(textoInArray[i])}    |    ", false);
                    }

                    MessageConsole.Show("\nConversão iniciada...");
                    while(criptografarCaractere == true)
                    {
                        bool largaEscala = false;

                        // Curta escala
                        if (j > rNum && rNum >= 0 && rNum <= allCaracteres.Length) j--;
                        else if (j < rNum && rNum >= 0 && rNum <= allCaracteres.Length) j++;

                        // Larga escala
                        if (rNum > 61)
                        {
                            j++;
                            largaEscala = true;
                        }

                        // Criptografar
                        // Curta escala
                        if(largaEscala == false) { }

                        // Larga escala
                        else
                        {
                            if (j > 61)
                            {
                                rNum -= (j - 1);
                                j = 0;
                            }
                        }

                        // Validar caractere
                        if (j == rNum)
                        {
                            textoEncryptInArray[i] = Convert.ToChar(allCaracteres[j]);
                            MessageConsole.Show($"Find Letter: {allCaracteres[j]}    |    Current Position: {j}    |    Preview Box Position: {rNum}    |    ", true);
                            break;
                        }

                        MessageConsole.Show($"Find Letter: {allCaracteres[j]}    |    Current Position: {j}    |    Preview Box Position: {rNum}    |    ", false);
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
