using System;
using System.Collections.Generic;
using System.Text;

namespace DevRsNet.UnitTestsVsTDD.VersaoUnitTests
{
    public class EncontroPresencial
    {
        public string Nome { get; set; }
        public DateTime Data { get; set; }

        public IList<string> ListaPresenca { get; set; }

        public IList<string> Vencedores { get; set; }

        public int QtdeBrindes { get; set; }

        public string SortearBrinde()
        {
            if (this.QtdeBrindes <= 0)
                throw new InvalidOperationException("Sem brindes disponíveis");

            int posicaoAleatoria = new Random().Next(0, this.ListaPresenca.Count);
            string sorteado = posicaoAleatoria < this.ListaPresenca.Count ? this.ListaPresenca[posicaoAleatoria] : "";

            if (this.Vencedores == null)
                this.Vencedores = new List<string>();

            if (!this.Vencedores.Contains(sorteado))
            {
                this.Vencedores.Add(sorteado);
                this.QtdeBrindes--;
                return sorteado;
            }

            return "";
        }
    }
}