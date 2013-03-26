using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevRsNet.UnitTestsVsTDD.VersaoUnitTests
{
    [TestClass]
    public class EncontroPresencialTest
    {
        [TestMethod]
        public void Adicionar_Participantes_Lista_Presenca()
        {
            // Arrange
            EncontroPresencial encontro = new EncontroPresencial();
            encontro.ListaPresenca = new List<string>();
            var participantes = new [] { "Participante 1", "Participante 2", "Participante 3", "Participante 4" };

            // Act
            encontro.ListaPresenca.Add(participantes[0]);
            encontro.ListaPresenca.Add(participantes[1]);
            encontro.ListaPresenca.Add(participantes[2]);

            // Assert
            CollectionAssert.Contains(encontro.ListaPresenca.ToList(), participantes[0]);
            CollectionAssert.Contains(encontro.ListaPresenca.ToList(), participantes[1]);
            CollectionAssert.Contains(encontro.ListaPresenca.ToList(), participantes[2]);
            CollectionAssert.DoesNotContain(encontro.ListaPresenca.ToList(), participantes[3]);
        }

        [TestMethod]
        public void Sortear_Brinde_Com_Nenhum_Participante_Deve_Retornar_Vazio()
        {
            // Arrange
            EncontroPresencial encontro = new EncontroPresencial();
            encontro.ListaPresenca = new List<string>();
            encontro.QtdeBrindes = 1;
            // Act
            string sorteado = encontro.SortearBrinde();
            // Arrange
            StringAssert.Equals(String.Empty, sorteado);
        }

        [TestMethod]
        public void Sortear_Brinde_Com_Somente_Um_Participante_Deve_Retornar_Ele_Proprio()
        {
            // Arrange
            string participante = "Sortudo!";
            EncontroPresencial encontro = new EncontroPresencial();
            encontro.ListaPresenca = new List<string>();
            encontro.QtdeBrindes = 1;
            encontro.ListaPresenca.Add(participante);
            // Act
            string sorteado = encontro.SortearBrinde();
            // Arrange
            StringAssert.Equals(participante, sorteado);
        }

        [TestMethod]
        public void Sortear_Brinde_Deve_Retornar_Algum_Dos_Participantes()
        {
            // Arrange
            EncontroPresencial encontro = new EncontroPresencial();
            encontro.ListaPresenca = new List<string>();
            encontro.QtdeBrindes = 1;
            var participantes = new[] { "Participante 1", "Participante 2", "Participante 3", "Participante 4" };
            encontro.ListaPresenca.Add(participantes[0]);
            encontro.ListaPresenca.Add(participantes[1]);
            encontro.ListaPresenca.Add(participantes[2]);

            // Act
            string sorteado = encontro.SortearBrinde();
            // Arrange
            CollectionAssert.Contains(participantes, sorteado);
        }

        [TestMethod]
        public void Sortear_Brinde_Deve_Adicionar_Sorteado_Na_Lista_Vencedores()
        {
            // Arrange
            EncontroPresencial encontro = new EncontroPresencial();
            encontro.ListaPresenca = new List<string>();
            encontro.QtdeBrindes = 1;
            var participantes = new[] { "Participante 1", "Participante 2", "Participante 3", "Participante 4" };
            encontro.ListaPresenca.Add(participantes[0]);
            encontro.ListaPresenca.Add(participantes[1]);
            encontro.ListaPresenca.Add(participantes[2]);

            // Act
            string sorteado = encontro.SortearBrinde();
            // Arrange
            CollectionAssert.Contains(encontro.Vencedores.ToList(), sorteado);
        }

        [TestMethod]
        public void Sortear_Brinde_Deve_Diminuir_Qtde_Brindes_Disponiveis()
        {
            // Arrange
            EncontroPresencial encontro = new EncontroPresencial();
            encontro.ListaPresenca = new List<string>();
            encontro.QtdeBrindes = 2;
            int qtdeBrindesEsperado = encontro.QtdeBrindes - 1;
            // Act
            string sorteado = encontro.SortearBrinde();
            // Arrange
            Assert.AreEqual(qtdeBrindesEsperado, encontro.QtdeBrindes); 
        }

        [TestMethod]
        public void Sortear_Brinde_Com_Participante_Que_Ja_Venceu_Deve_Retornar_Vazio()
        {
            // Arrange
            string participante = "Sortudo!";
            EncontroPresencial encontro = new EncontroPresencial();
            encontro.ListaPresenca = new List<string>();
            encontro.QtdeBrindes = 2;
            // Forçando apenas um participante para garantir o caso de teste
            encontro.ListaPresenca.Add(participante);

            // Act
            string primeiroSorteado = encontro.SortearBrinde();
            string segundoSorteado = encontro.SortearBrinde();
            // Arrange
            StringAssert.Equals(participante, primeiroSorteado);
            StringAssert.Equals(String.Empty, segundoSorteado);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Sortear_Brinde_Com_QtdeBrindes_Negativa_Deve_Lancar_Excecao()
        {
            // Arrange
            EncontroPresencial encontro = new EncontroPresencial();
            encontro.ListaPresenca = new List<string>();
            encontro.QtdeBrindes = -9;
            // Act
            string primeiroSorteado = encontro.SortearBrinde();
        }
    }
}