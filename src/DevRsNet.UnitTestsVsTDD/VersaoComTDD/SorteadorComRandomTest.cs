using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevRsNet.UnitTestsVsTDD.VersaoComTDD
{
    [TestClass]
    public class SorteadorComRandomTest
    {
        [TestMethod]
        public void Criar_SorteadorComRandom_Com_NumeroMaximo_Para_Sorteio()
        {
            // Arrange
            int maximoParaSorteio = 99;
            // Act
            SorteadorComRandom sorteador = new SorteadorComRandom(maximoParaSorteio);
            // Assert
            Assert.AreEqual(maximoParaSorteio, sorteador.NumeroMaximo);
        }

        [TestMethod]
        public void SorteadorComRandom_Deve_Ter_NumeroMinimo_0()
        {
            // Arrange
            int minimoParaSorteio = 0;
            // Act
            SorteadorComRandom sorteador = new SorteadorComRandom(maximo: 99);
            // Assert
            Assert.AreEqual(minimoParaSorteio, sorteador.NumeroMinimo);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Criar_SorteadorComRandom_Com_NumeroMaximo_Negativa_Deve_Lancar_Excecao()
        {
            // Arrange
            int maximoParaSorteio = -88;
            // Act
            SorteadorComRandom sorteador = new SorteadorComRandom(maximoParaSorteio);
            // Assert
            Assert.AreEqual(maximoParaSorteio, sorteador.NumeroMaximo);
        }

        [TestMethod]
        public void Sortear_Numero_Entre_0_e_Maximo()
        {
            // Arrange
            int maximoParaSorteio = 99;
            SorteadorComRandom sorteador = new SorteadorComRandom(maximoParaSorteio);
            // Act
            int numeroSorteado = sorteador.Sortear();
            // Assert
            Assert.IsTrue(numeroSorteado >= 0 && numeroSorteado < 99);
        }
    }
}