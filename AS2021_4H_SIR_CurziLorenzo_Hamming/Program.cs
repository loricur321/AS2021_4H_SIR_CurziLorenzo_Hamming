//using Pastel;
using AS2021_4H_SIR_CurziLorenzo_Hamming.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AS2021_4H_SIR_CurziLorenzo_Hamming
{
    public class Program
    {
        static void Main(string[] args)
        {
            CodiceHamming hamming = new CodiceHamming();

            Console.WriteLine("Codice di Hamming di Lorenzo curzi 4H, 23/04/2021");

            string bit = Richiestadati("Inserire la sequenza di bit (solo 0 e 1): ");

            Console.WriteLine($"Codifica di Hamming della parola in ingresso: {hamming.CalcolaCodiceHamming(bit)}");

            string bitRicevuti = Richiestadati("Inserire la sequenza di bit ricevuta: (solo 0 e 1)");

            Console.WriteLine($"La parola ricevuta corretta è: {hamming.Ricezione(bitRicevuti)}");
        }

        /// <summary>
        /// Metodo con cui richiedo in ingresso la sequenza di bit su cui dovrò calcolare la parità
        /// </summary>
        /// <param name="prompt">stringa da comunicare all'utente</param>
        /// <returns>stringa inserita dall'utente</returns>
        static string Richiestadati(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                string input = Console.ReadLine().Trim(); //Richiedo in input la seguenza di bit

                bool flag = false;

                foreach (char i in input) //controllo ogni valore della stringa
                    if (i != '1' && i != '0') //nel caso vi sia qualche carattere che non corrisponda a 0 o 1 cambio il valore del flag
                        flag = true;

                if (!flag)
                    return input;
                else
                    Console.WriteLine("Inserimento errato! La sequenza di bit deve essere composta solo da 0 e 1.");
            }
        }
    }
}
