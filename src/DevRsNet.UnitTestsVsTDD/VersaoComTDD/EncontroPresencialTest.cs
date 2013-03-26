using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevRsNet.UnitTestsVsTDD.VersaoComTDD
{
    [TestClass]
    public class EncontroPresencialTest
    {
        [TestMethod]
        public void Criar_EncontroPresencial_Com_Nome_ListaPresenca_QtdeBrindes_Data()
        {
            // Assert
            string nomeEvento = "1o Evento DevRs.Net 2013";
            var listaPresenca = new []{ "Participante1", "Participante2" };
            DateTime data = new DateTime(2013, 03, 26);
            int qtdeBrindes = 6;
            // Act
            EncontroPresencialTDD encontroPresencial = new EncontroPresencialTDD(nomeEvento, listaPresenca, qtdeBrindes, data);
            // Arrange
            Assert.AreEqual(nomeEvento, encontroPresencial.Nome);
            Assert.AreEqual(listaPresenca.ElementAt(0), encontroPresencial.ListaPresenca.ElementAt(0));
            Assert.AreEqual(listaPresenca.ElementAt(1), encontroPresencial.ListaPresenca.ElementAt(1));
            Assert.AreEqual(qtdeBrindes, encontroPresencial.QtdeBrindes);
            Assert.AreEqual(data, encontroPresencial.Data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Criar_EncontroPresencial_Sem_Nome_Deve_Lancar_Excecao()
        {
            // Assert
            var listaPresenca = new[] { "Participante1", "Participante2" };
            DateTime data = new DateTime(2013, 03, 26);
            // Act
            EncontroPresencialTDD encontroPresencial = new EncontroPresencialTDD(null, listaPresenca, 6, data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Criar_EncontroPresencial_Sem_Participantes_Deve_Lancar_Excecao()
        {
            // Assert
            string nome = "1o Evento DevRs.Net 2013";
            DateTime data = new DateTime(2013, 03, 26);
            // Act
            EncontroPresencialTDD encontroPresencial = new EncontroPresencialTDD(nome, null, 6, data);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Criar_EncontroPresencial_Com_QtdeBrindes_Negativa_Deve_Lancar_Excecao()
        {
            // Assert
            string nome = "1o Evento DevRs.Net 2013";
            var listaPresenca = new[] { "Participante1", "Participante2" };
            DateTime data = new DateTime(2013, 03, 26);
            int qtdeBrindes = -16;
            // Act
            EncontroPresencialTDD encontroPresencial = new EncontroPresencialTDD(nome, listaPresenca, qtdeBrindes, data);
        }

        [TestMethod]
        public void Criar_EncontroPresencial_Sem_Informar_Data_Assume_Data_Atual()
        {
            // Assert
            string nomeEvento = "1o Evento DevRs.Net 2013";
            var listaPresenca = new[] { "Participante1", "Participante2" };
            int qtdeBrindes = 6;
            // Act
            EncontroPresencialTDD encontro = new EncontroPresencialTDD(nomeEvento, listaPresenca, qtdeBrindes);
            // Assert
            // TODO: Criar objeto próprio para fazer o stub de uma data
            // para garantir que a asserção de valores seja sempre a mesma
            Assert.AreEqual(DateTime.Today, encontro.Data);
        }

        [TestMethod]
        public void EncontroPresencial_Com_Sorteador_Pode_Sortear()
        {
            // Assert
            string nomeEvento = "1o Evento DevRs.Net 2013";
            var listaPresenca = new[] { "Participante1", "Participante2" };
            DateTime data = new DateTime(2013, 03, 26);
            int qtdeBrindes = 6;
            var sorteador = new SorteadorComRandom(maximo: listaPresenca.Length);
            // Act
            EncontroPresencialTDD encontro = new EncontroPresencialTDD(nomeEvento, listaPresenca, qtdeBrindes, data, sorteador);
            string sorteado = encontro.Sortear();
            // Assert
            Assert.AreEqual(expected: sorteador, actual: encontro.Sorteador);
        }

        [TestMethod]
        public void Sortear_Deve_Diminuir_Qtde_Brindes()
        {
            // Assert
            string nomeEvento = "1o Evento DevRs.Net 2013";
            var listaPresenca = new[] { "Participante1", "Participante2" };
            DateTime data = new DateTime(2013, 03, 26);
            int qtdeBrindes = 6;
            EncontroPresencialTDD encontro = new EncontroPresencialTDD(nomeEvento, listaPresenca, qtdeBrindes, data, new SorteadorComRandom(maximo: listaPresenca.Length));
            // Act
            string sorteado = encontro.Sortear();
            // Assert
            Assert.AreEqual(expected: qtdeBrindes - 1, actual: encontro.QtdeBrindes);
        }

        [TestMethod]
        public void Sortear_Com_Apenas_Um_Participante_Deve_Retornar_O_Proprio()
        {
            // Assert
            string nomeEvento = "1o Evento DevRs.Net 2013";
            var listaPresenca = new[] { "Participante1" };
            DateTime data = new DateTime(2013, 03, 26);
            int qtdeBrindes = 6;
            EncontroPresencialTDD encontro = new EncontroPresencialTDD(nomeEvento, listaPresenca, qtdeBrindes, data, new SorteadorComRandom(maximo: listaPresenca.Length));
            // Act
            string sorteado = encontro.Sortear();
            // Assert
            Assert.AreEqual(expected: listaPresenca.ElementAt(0), actual: sorteado);
        }

        [TestMethod]
        public void Sortear_Deve_Retornar_Um_Dos_Participantes()
        {
            // Assert
            string nomeEvento = "1o Evento DevRs.Net 2013";
            var listaPresenca = new[] { "Participante1", "Participante2", "Participante 3", "Participante 4" };
            DateTime data = new DateTime(2013, 03, 26);
            int qtdeBrindes = 6;
            EncontroPresencialTDD encontro = new EncontroPresencialTDD(nomeEvento, listaPresenca, qtdeBrindes, data, new SorteadorComRandom(maximo: listaPresenca.Length));
            // Act
            string sorteado = encontro.Sortear();
            // Assert
            CollectionAssert.Contains(listaPresenca, sorteado);
        }

        [TestMethod]
        public void Sortear_Brinde_Com_Participante_Que_Ja_Venceu_Deve_Retornar_Vazio()
        {
            // Assert
            string nomeEvento = "1o Evento DevRs.Net 2013";
            var listaPresenca = new[] { "Participante1" };
            DateTime data = new DateTime(2013, 03, 26);
            int qtdeBrindes = 6;
            EncontroPresencialTDD encontro = new EncontroPresencialTDD(nomeEvento, listaPresenca, qtdeBrindes, data, new SorteadorComRandom(maximo: listaPresenca.Length));
            // Act
            string sorteado1 = encontro.Sortear();
            // Forçando sorteio com o mesmo participante
            string sorteado2 = encontro.Sortear();
            // Assert
            Assert.AreEqual(expected: listaPresenca.ElementAt(0), actual: sorteado1);
            Assert.AreEqual(expected: String.Empty, actual: sorteado2);
        }
    }
}