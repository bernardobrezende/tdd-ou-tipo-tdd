using System;

namespace DevRsNet.UnitTestsVsTDD.VersaoComTDD
{
    public class SorteadorComRandom
    {
        public int NumeroMaximo { get; private set; }
        public int NumeroMinimo { get; private set; }

        public SorteadorComRandom(int maximo)
        {
            if (maximo < 0)
                throw new ArgumentOutOfRangeException("Número máximo para sorteio não pode ser negativo!");
            this.NumeroMaximo = maximo;
            this.NumeroMinimo = 0;
        }

        internal int Sortear()
        {
            return new Random().Next(this.NumeroMinimo, this.NumeroMaximo);
        }       
    }
}