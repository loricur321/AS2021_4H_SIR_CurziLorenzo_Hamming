using Pastel;
using System;
using System.Collections.Generic;
using System.Text;

namespace AS2021_4H_SIR_CurziLorenzo_Hamming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Codice di Hamming di Lorenzo curzi 4H, 23/04/2021");

            string bit = Richiestadati("Inserire la sequenza di bit (solo 0 e 1): ");

            Console.WriteLine($"Codifica di Hamming della parola in ingresso: {Hamming(bit)}");

            string bitRicevuti = Richiestadati("Inserire la sequenza di bit ricevuta: (solo 0 e 1)");

            Console.WriteLine(Ricezione(bitRicevuti));
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
                    Console.WriteLine("Inserimento errato! La sequenza di bit deve essere composta solo da 0 e 1.".Pastel("FF0000"));
            }
        }

        /// <summary>
        /// Metodo in cui è possibile calcolare la parità secondo il codice di Hamming
        /// </summary>
        /// <param name="bit">sequenza di bit su cui calcolare la parità</param>
        /// <returns>sequenza di bit con bit di parità</returns>
        static string Hamming(string bit)
        {
            List<string> sequenza = ImpostaPosizioniParita(bit);

            //lista in cui mi salverò tutte le posizione di parità da calcolare a seconda
            //della lunghezza della sequenza di bit e delle potenze di 2
            List<int> posizioniParita = new List<int>();

            for (int i = 0; i < bit.Length; i++)
                posizioniParita.Add(Convert.ToInt32(Math.Pow(2, i)) - 1);

            for(int i = 0; i < sequenza.Count; i++)
            {
                foreach(int p in posizioniParita)
                    if(p == i)
                    {
                        sequenza[i] = CalcolaParita(sequenza, p);
                        break;
                    }
            }

            string retVal = "";

            foreach (string s in sequenza)
                retVal += s;

            return retVal;
        }

        /// <summary>
        /// Metodo che riceve in ingresso una seguenza di bit e inserisce dei caratteri "_" nei punti in cui vi dovranno essere dei bit di parità
        /// </summary>
        /// <param name="bit">sequenza di bit</param>
        /// <returns>sequenza di bit con parità segnate da "_"</returns>
        static List<string> ImpostaPosizioniParita(string bit)
        {
            List<string> sequenza = new List<string>();

            //con contaBit calcolo quanti bit di codice ci sono nella sequenza,
            //mentre con contaParita conto quanti di bit di parità saranno presenti nel messaggio
            int contaBit = 0, contaParita = 0;

            //faccio scorrere la lista di bit e aggiungo dei posti vuoti segnati con il -1 basandomi sulle potende del 2
            for (int i = 0; contaBit < bit.Length; i++)
            {
                if (i == Math.Pow(2, contaParita) - 1)
                {
                    sequenza.Add("_"); //aggiungo un posto vuoto nella lista che mi rappresenterà poi il bit di parità
                    contaParita++;
                }
                else
                {
                    sequenza.Add(bit[contaBit].ToString());
                    contaBit++;
                }
            }

            return sequenza;
        }

        /// <summary>
        /// Metodo che conta i bit per vericarne la parità
        /// </summary>
        /// <param name="sequenza">sequenza di bit</param>
        /// <returns>0 se i bit sono pari, 1 se i bit sono dispari</returns>
        static string CalcolaParita(List<string> sequenza, int posizioneParita)
        {
            int contatore = 0;

            //parto dalla posizione del bit di parità e controllo le posizioni a seconda di esso
            for(int i = posizioneParita; i < sequenza.Count; i = i + posizioneParita + 1)
            {
                int j = 0;
                //utilizzo un do while per poter saltare ai bit successivi al bit di partenza
                do
                {
                    //conto i bit 1
                    if (sequenza[i] == "1")
                        contatore++;

                    j++;
                    i++;
                } while ((j < posizioneParita + 1) && (i < sequenza.Count));
            }

            if (contatore % 2 == 0)
                return "0".Pastel("00FF00");
            else
                return "1".Pastel("00FF00");
        }

        /// <summary>
        /// Metodo che verificare la parità dei bit in ricezione a seconda del bit di parità
        /// </summary>
        /// <param name="sequenza">sequenza ricevuta</param>
        /// <param name="posizioneParita">parità da verificare</param>
        /// <returns>numero di bit 1 presenti</returns>
        static int CalcolaParitaRicezione(List<string> sequenza, int posizioneParita)
        {
            int contatore = 0;

            //parto dalla posizione del bit di parità e controllo le posizioni a seconda di esso
            for (int i = posizioneParita; i < sequenza.Count; i = i + posizioneParita + 1)
            {
                int j = 0;
                //utilizzo un do while per poter saltare ai bit successivi al bit di partenza
                do
                {
                    //conto i bit 1
                    if (sequenza[i] == "1")
                        contatore++;

                    j++;
                    i++;
                } while ((j < posizioneParita + 1) && (i < sequenza.Count));
            }

            return contatore;
        }

        /// <summary>
        /// Metodo che verifica che la parola in ingresso non abbia errori
        /// </summary>
        /// <param name="bitRicevuti">parola ricevuta</param>
        /// <returns></returns>
        static string Ricezione(string bitRicevuti)
        {
            List<string> sequenzaRicevuta = new List<string>();

            foreach (var b in bitRicevuti)
                sequenzaRicevuta.Add(b.ToString());

            //lista in cui mi salverò tutte le posizione di parità da calcolare a seconda
            //della lunghezza della sequenza di bit e delle potenze di 2
            List<int> posizioniParita = new List<int>();

            for (int i = 0; i < bitRicevuti.Length; i++)
                posizioniParita.Add(Convert.ToInt32(Math.Pow(2, i)) - 1);

            int sindromeErrore = -1; //in caso di errore nella ricezione viene aggiunta in questa variabile il valore della parità errato in modo da individuare la posizone errata

            for(int i = 0; i < sequenzaRicevuta.Count; i++)
            {
                foreach(var p in posizioniParita)
                    if(i == p)
                    {
                        int bitUnoPresenti = CalcolaParitaRicezione(sequenzaRicevuta, p);

                        //in caso il numero di uno sia dispari significa che vi è stato un errore nella parità
                        if (bitUnoPresenti % 2 != 0)
                        {
                            sindromeErrore += p + 1; //perciò mi salvo il numero della parità 
                            break;
                        }
                        else
                            break;
                    }
            }

            StringBuilder sb = new StringBuilder();

            //se la sindrome d'errore ha un valore diverso da -1 allora devo invertire il bit indicato da essa
            if (sindromeErrore != -1)
            {
                sindromeErrore += 1; //aggiungo 1 in quanto partendo da -1 se non lo facessi invertirei il bit sbagliato

                if (sequenzaRicevuta[sindromeErrore - 1] == "0")
                    sequenzaRicevuta[sindromeErrore - 1] = "1".Pastel("FFFF00");
                else
                    sequenzaRicevuta[sindromeErrore - 1] = "0".Pastel("FFFF00");

                sb.AppendLine($"Vi era un errore nella posizione: {sindromeErrore}".Pastel("FF0000"));
                sb.AppendLine($"La sequenza di bit corretta è: \n");
                foreach (string s in sequenzaRicevuta)
                    sb.Append(s);
            }
            else
                sb.AppendLine("Non vi è stato alcun errore nella ricezione!".Pastel("00FF00"));

            return sb.ToString();
        }
    }
}
