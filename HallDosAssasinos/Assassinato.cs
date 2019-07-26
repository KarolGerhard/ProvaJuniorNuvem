using System;
using System.Collections.Generic;
using System.Text;

namespace HallDosAssasinos
{
    class Assassinato
    {
        private string assassino;

        public string Assassino
        {
            get { return assassino; }
            set
            {
                if (value.Length > 10)
                    throw new ArgumentException("Devera ter no máximo 10 caracteres");
                assassino = value;
            }
        }
        private string assassinado;

        public string Assassinado
        {
            get { return assassinado; }
            set
            {
                if (value.Length > 10)
                    throw new ArgumentException("Devera ter no máximo 10 caracteres");
                assassinado = value;
            }
        }


    }
}
