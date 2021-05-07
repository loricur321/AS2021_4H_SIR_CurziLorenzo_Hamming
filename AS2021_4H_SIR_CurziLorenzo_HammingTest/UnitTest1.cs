using Microsoft.VisualStudio.TestTools.UnitTesting;
using AS2021_4H_SIR_CurziLorenzo_Hamming;

namespace AS2021_4H_SIR_CurziLorenzo_HammingTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestInvio()
        {
            string risultato = Program.Hamming("0100"); 
            string risultatoAtteso = "1001100";

            Assert.AreEqual(risultato, risultatoAtteso);
        }

        [TestMethod]
        public void TestRicezione()
        {
            //invio un codice di Hamming con un errore nella posizione 2
            string risultato = Program.Ricezione("1101100");
            string risultatoAtteso = "1001100"; //codice di Hamming atteso che il metodo dovrebbe correggere

            Assert.AreEqual(risultato, risultatoAtteso);
        }
    }
}
