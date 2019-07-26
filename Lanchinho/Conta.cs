using System;
using System.Collections.Generic;
using System.Text;

namespace Lanchinho
{
    class Conta
    {

        public double total { get; set; }

        public override string ToString()
        {
            return $"Total: R$ {string.Format("{0:0.,00}", total)}";
        }
    }
}

