using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Lanchinho
{
    public struct Pedido
    {
        public int codigo, quantidade;

        public Pedido(int cod, int qtd)
        {
            codigo = cod;
            quantidade = qtd;
        }
       
    }
}