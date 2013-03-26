using System;
using System.Collections.Generic;
using System.Linq;

namespace DevRsNet.UnitTestsVsTDD.VersaoComTDD
{
    public class EncontroPresencialTDD
    {
        public string Nome { get; private set; }
        private IList<string> listaPresenca;        
        public IEnumerable<string> ListaPresenca { get { return this.listaPresenca; } }
        public int QtdeBrindes { get; private set; }
        public DateTime Data { get; private set; }
        public SorteadorComRandom Sorteador { get; private set; }

        private IList<int> numerosJaSorteados;

        public EncontroPresencialTDD(string nome, IEnumerable<string> listaPresenca, int qtdeBrindes, DateTime data = default(DateTime), SorteadorComRandom sorteador = default(SorteadorComRandom))
        {
            if (nome == null)
                throw new ArgumentNullException("Nome do evento deve ser informado!");

            if (listaPresenca == null)
                throw new ArgumentNullException("Lista de presenças deve ser informada!");

            if (qtdeBrindes < 0)
                throw new ArgumentOutOfRangeException("Quantidade de brindes não pode ser negativa!");

            this.Nome = nome;
            this.listaPresenca = listaPresenca.ToList();
            this.Data = data != default(DateTime) ? data : DateTime.Today;
            this.QtdeBrindes = qtdeBrindes;
            this.Sorteador = sorteador;
            this.numerosJaSorteados = new List<int>();
        }

        internal string Sortear()
        {
            var numeroSorteado = this.Sorteador.Sortear();

            if (!this.numerosJaSorteados.Contains(numeroSorteado))
            {
                this.numerosJaSorteados.Add(numeroSorteado);
                this.QtdeBrindes--;
                return this.listaPresenca[numeroSorteado];
            }

            return String.Empty;
        }
    }
}