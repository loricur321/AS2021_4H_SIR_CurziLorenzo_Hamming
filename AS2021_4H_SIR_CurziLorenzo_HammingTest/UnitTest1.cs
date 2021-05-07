using Microsoft.VisualStudio.TestTools.UnitTesting;
using AS2021_4H_SIR_CurziLorenzo_Hamming;

namespace AS2021_4H_SIR_CurziLorenzo_HammingTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Test di invio che passa una sequenza di bit e verifica che il risultato sia conforme alla codifica di Hamming
        /// </summary>
        [TestMethod]
        public void TestInvio()
        {
            /*
                * sequenza di bit --> codifica di hamming
                
                * 010011 --> 0101100011

                * 0100 --> 1001100
             */

            CodiceHamming hamming = new CodiceHamming();

            string risultato = hamming.CalcolaCodiceHamming("010011"); 
            string risultatoAtteso = "0101100011";

            Assert.AreEqual(risultato, risultatoAtteso);
        }

        /// <summary>
        /// Invio un codice di Hamming errato in una sola posizione e verifico che il risultato sia conforme con la corretta verifica di Hamming
        /// </summary>
        [TestMethod]
        public void TestRicezione()
        {
            /*
             * * sequenza di bit errata --> codifica di hamming corretta
              
             * 1101100 --> 1001100
              
             * 0111100011 --> 0101100011
             */

            CodiceHamming hamming = new CodiceHamming();

            //invio un codice di Hamming con un errore nella posizione 2
            string risultato = hamming.Ricezione("0111100011");
            string risultatoAtteso = "0101100011"; //codice di Hamming atteso che il metodo dovrebbe correggere

            Assert.AreEqual(risultato, risultatoAtteso);
        }
    }
}
