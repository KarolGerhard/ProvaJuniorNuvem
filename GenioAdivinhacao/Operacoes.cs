using System;
using System.Collections.Generic;
using System.Text;

namespace GenioAdivinhacaoBonus
{
    class Operacoes
    {
        private int comando;

        public int Comando
        {
            get { return comando; }
            set {
                //if((value != 1)||(value != 2)){
                //    throw new ArgumentException("Elemento tem que ser 1 ou 2");
                //}
                comando = value; }
        }

        private int elemento;

        public int Elemento
        {
            get { return elemento; }
            set {
                //if (value > 100)
                //    throw new ArgumentException("Tem que possuir valor menor que 100");
                
                elemento = value;
            }
        }

    }
}
